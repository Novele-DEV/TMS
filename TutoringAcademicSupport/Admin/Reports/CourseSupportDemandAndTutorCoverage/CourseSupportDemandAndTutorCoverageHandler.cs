using System.Data.OleDb;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Admin.Reports.CourseSupportDemandAndTutorCoverage
{
    // Report 5.3: requests per course in the chosen period compared with the verified tutors for each course.
    public static class CourseSupportDemandAndTutorCoverageHandler
    {
        // Thresholds from the Milestone 2 flag rules (configurable by the Academic Coordinator).
        private const int CoursesShown = 7;
        private const double RecruitRequestsPerTutor = 12.0;
        private const int NotifyLecturerRequests = 20;

        public static CourseSupportDemandAndTutorCoverageResult Handle(CourseSupportDemandAndTutorCoverageRequest request)
        {
            DateTime startDate = request.StartDate.Date;
            DateTime endDate = request.EndDate.Date;

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            // The faculty filter narrows the requests before anything is counted,
            // so the totals, overall ratio and flags all describe that faculty only.
            List<RequestRecord> requests = LoadRequests(connection, startDate, endDate, request.Faculty);
            List<QualificationRecord> qualifications = LoadQualifications(connection);

            // One row per course with requests in the period; only the busiest courses are listed.
            var courses = requests
                .GroupBy(r => (r.CourseCode, r.CourseName))
                .Select(g => new
                {
                    g.Key.CourseCode,
                    g.Key.CourseName,
                    Total = g.Count(),
                    ContentClarification = g.Count(r => r.SupportType == "Content Clarification"),
                    ExamPreparation = g.Count(r => r.SupportType == "Exam Preparation"),
                    AssignmentAssistance = g.Count(r => r.SupportType == "Assignment Assistance"),
                    StudySkills = g.Count(r => r.SupportType == "Study Skills"),
                    Urgent = g.Count(r => r.Priority == "Urgent"),
                    Unfulfilled = g.Count(r => r.Status == "Unfulfilled"),
                    Verified = qualifications
                        .Where(q => q.CourseCode == g.Key.CourseCode && q.Verified)
                        .Select(q => q.TutorId)
                        .Distinct()
                        .Count(),
                    Pending = qualifications.Count(q => q.CourseCode == g.Key.CourseCode && !q.Verified)
                })
                .OrderByDescending(c => c.Total)
                .ThenBy(c => c.CourseCode)
                .Take(CoursesShown)
                .ToList();

            // The overall ratio uses the listed courses only and is compared unrounded.
            int totalRequests = courses.Sum(c => c.Total);
            int totalVerified = courses.Sum(c => c.Verified);
            double? overallRatio = totalVerified == 0 ? null : (double)totalRequests / totalVerified;

            List<CourseDemandRow> rows = courses
                .Select(c =>
                {
                    double? ratio = c.Verified == 0 ? null : (double)c.Total / c.Verified;

                    return new CourseDemandRow
                    {
                        CourseCode = c.CourseCode,
                        CourseName = c.CourseName,
                        TotalRequests = c.Total,
                        ContentClarification = c.ContentClarification,
                        ExamPreparation = c.ExamPreparation,
                        AssignmentAssistance = c.AssignmentAssistance,
                        StudySkills = c.StudySkills,
                        Urgent = c.Urgent,
                        Unfulfilled = c.Unfulfilled,
                        VerifiedTutors = c.Verified,
                        PendingQualifications = c.Pending,
                        RequestsPerTutor = ratio,

                        // Recruit tutors: 12+ requests per tutor, or no verified tutor at all.
                        RecruitTutors = ratio is null || ratio >= RecruitRequestsPerTutor,

                        // Verify pending first: a pending qualification and demand per tutor at or above the overall ratio.
                        // A course with no verified tutor counts as above the overall ratio.
                        VerifyPendingFirst = c.Pending >= 1 && (ratio is null || overallRatio is null || ratio >= overallRatio),

                        // Notify lecturer: Content Clarification + Exam Preparation requests reach 20.
                        NotifyLecturer = c.ContentClarification + c.ExamPreparation >= NotifyLecturerRequests
                    };
                })
                .ToList();

            return new CourseSupportDemandAndTutorCoverageResult
            {
                StartDate = startDate,
                EndDate = endDate,
                Rows = rows,
                OverallRequestsPerTutor = overallRatio
            };
        }

        // The faculties offered in the Faculty filter.
        public static List<ReportFilterOption> LoadFacultyOptions()
        {
            const string query = "SELECT DISTINCT [Course_Faculty] FROM [Course] ORDER BY [Course_Faculty]";

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using OleDbCommand command = new(query, connection);
            using OleDbDataReader reader = command.ExecuteReader();

            List<ReportFilterOption> faculties = new();
            while (reader.Read())
            {
                string faculty = Text(reader, "Course_Faculty");
                faculties.Add(new ReportFilterOption(faculty, faculty));
            }

            return faculties;
        }

        private static List<RequestRecord> LoadRequests(OleDbConnection connection, DateTime startDate, DateTime endDate, string? faculty)
        {
            string query = """
                SELECT r.[Course_Code], c.[Course_Name], r.[Request_SupportType],
                       r.[Request_PriorityLevel], r.[Request_Status]
                FROM [TutoringRequest] AS r
                    INNER JOIN [Course] AS c ON r.[Course_Code] = c.[Course_Code]
                WHERE r.[Request_SubmissionDate] >= ? AND r.[Request_SubmissionDate] < ?
                """;

            if (faculty is not null) query += " AND c.[Course_Faculty] = ?";

            // OleDb parameters are matched by position, so they are added in the same order as the conditions.
            using OleDbCommand command = new(query, connection);
            command.Parameters.Add("@StartDate", OleDbType.Date).Value = startDate;
            command.Parameters.Add("@EndDateExclusive", OleDbType.Date).Value = endDate.AddDays(1); // includes the whole end date
            if (faculty is not null)
                command.Parameters.Add("@Faculty", OleDbType.VarWChar, 100).Value = faculty;

            List<RequestRecord> requests = new();
            using OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                requests.Add(new RequestRecord(
                    Text(reader, "Course_Code"),
                    Text(reader, "Course_Name"),
                    Text(reader, "Request_SupportType"),
                    Text(reader, "Request_PriorityLevel"),
                    Text(reader, "Request_Status")));
            }

            return requests;
        }

        // A qualification is verified when Verification_Date is filled in, and pending when it is empty.
        private static List<QualificationRecord> LoadQualifications(OleDbConnection connection)
        {
            const string query = "SELECT [Tutor_ID], [Course_Code], [Verification_Date] FROM [TutorQualifications]";

            using OleDbCommand command = new(query, connection);
            using OleDbDataReader reader = command.ExecuteReader();

            List<QualificationRecord> qualifications = new();
            while (reader.Read())
            {
                qualifications.Add(new QualificationRecord(
                    Text(reader, "Tutor_ID"),
                    Text(reader, "Course_Code"),
                    reader["Verification_Date"] is not DBNull));
            }

            return qualifications;
        }

        private static string Text(OleDbDataReader reader, string column)
        {
            return reader[column] as string ?? string.Empty;
        }

        private sealed record RequestRecord(string CourseCode, string CourseName, string SupportType, string Priority, string Status);

        private sealed record QualificationRecord(string TutorId, string CourseCode, bool Verified);
    }
}

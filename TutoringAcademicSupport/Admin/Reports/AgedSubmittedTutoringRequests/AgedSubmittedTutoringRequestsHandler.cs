using System.Data.OleDb;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Admin.Reports.AgedSubmittedTutoringRequests
{
    // Report 5.1: Submitted requests that have waited 7 days or more, oldest first.
    public static class AgedSubmittedTutoringRequestsHandler
    {
        public const string Escalate = "Escalate";
        public const string VerifyNow = "Verify now";
        public const string FollowUp = "Follow up";

        // Thresholds from the Milestone 2 flag rules.
        private const int MinimumAgeDays = 7;
        private const int EscalateAgeDays = 14;

        public static AgedSubmittedTutoringRequestsResult Handle(AgedSubmittedTutoringRequestsRequest request)
        {
            DateTime runDate = request.RunDate.Date;

            // Age is counted in whole days, so a request is old enough when it was
            // submitted before midnight at the start of (run date - 6 days).
            DateTime submittedBefore = runDate.AddDays(-(MinimumAgeDays - 1));

            // The course and priority filters narrow the query itself.
            string query = """
                SELECT r.[Request_ID], r.[Request_SubmissionDate], r.[Request_SupportType],
                       r.[Request_PriorityLevel], r.[Student_ID], s.[Student_FName], s.[Student_LName],
                       s.[Student_Faculty], s.[Student_Email], s.[Student_AcademicRiskLevel],
                       r.[Course_Code], c.[Course_Name]
                FROM ([TutoringRequest] AS r
                    INNER JOIN [Student] AS s ON r.[Student_ID] = s.[Student_ID])
                    INNER JOIN [Course] AS c ON r.[Course_Code] = c.[Course_Code]
                WHERE r.[Request_Status] = 'Submitted'
                  AND r.[Request_SubmissionDate] < ?
                """;

            if (request.CourseCode is not null) query += " AND r.[Course_Code] = ?";
            if (request.Priority is not null) query += " AND r.[Request_PriorityLevel] = ?";
            query += " ORDER BY r.[Request_SubmissionDate], r.[Request_ID]";

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            // OleDb parameters are matched by position, so they are added in the same order as the conditions.
            using OleDbCommand command = new(query, connection);
            command.Parameters.Add("@SubmittedBefore", OleDbType.Date).Value = submittedBefore;
            if (request.CourseCode is not null)
                command.Parameters.Add("@Course_Code", OleDbType.VarWChar, 9).Value = request.CourseCode;
            if (request.Priority is not null)
                command.Parameters.Add("@Priority", OleDbType.VarWChar, 10).Value = request.Priority;

            List<AgedRequestRow> rows = new();
            using OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime submitted = Convert.ToDateTime(reader["Request_SubmissionDate"]);
                int ageDays = (runDate - submitted.Date).Days;
                string priority = Text(reader, "Request_PriorityLevel");
                string actionFlag = ActionFlag(ageDays, priority);

                // The action is worked out per request, so it is filtered after it has been calculated.
                if (request.ActionFlag is not null && actionFlag != request.ActionFlag) continue;

                rows.Add(new AgedRequestRow
                {
                    RequestId = Convert.ToInt32(reader["Request_ID"]),
                    SubmissionDate = submitted,
                    AgeDays = ageDays,
                    StudentId = Convert.ToInt32(reader["Student_ID"]),
                    StudentName = $"{Text(reader, "Student_FName")} {Text(reader, "Student_LName")}",
                    Faculty = Text(reader, "Student_Faculty"),
                    Email = Text(reader, "Student_Email"),
                    RiskLevel = Text(reader, "Student_AcademicRiskLevel"),
                    CourseCode = Text(reader, "Course_Code"),
                    CourseName = Text(reader, "Course_Name"),
                    SupportType = Text(reader, "Request_SupportType"),
                    Priority = priority,
                    ActionFlag = actionFlag
                });
            }

            return new AgedSubmittedTutoringRequestsResult
            {
                RunDate = runDate,
                Rows = rows
            };
        }

        // The courses offered in the Course filter.
        public static List<ReportFilterOption> LoadCourseOptions()
        {
            const string query = "SELECT [Course_Code], [Course_Name] FROM [Course] ORDER BY [Course_Code]";

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            using OleDbCommand command = new(query, connection);
            using OleDbDataReader reader = command.ExecuteReader();

            List<ReportFilterOption> courses = new();
            while (reader.Read())
            {
                string code = Text(reader, "Course_Code");
                courses.Add(new ReportFilterOption($"{code} {Text(reader, "Course_Name")}", code));
            }

            return courses;
        }

        // Escalate: 14+ days or Urgent. Verify now: High and 7-13 days. Follow up: all others.
        private static string ActionFlag(int ageDays, string priority)
        {
            if (ageDays >= EscalateAgeDays || priority == "Urgent") return Escalate;
            if (priority == "High") return VerifyNow;
            return FollowUp;
        }

        private static string Text(OleDbDataReader reader, string column)
        {
            return reader[column] as string ?? string.Empty;
        }
    }
}

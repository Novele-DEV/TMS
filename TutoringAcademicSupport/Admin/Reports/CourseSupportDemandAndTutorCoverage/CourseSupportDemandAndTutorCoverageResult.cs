namespace TutoringAcademicSupport.Admin.Reports.CourseSupportDemandAndTutorCoverage
{
    public sealed class CourseSupportDemandAndTutorCoverageResult
    {
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        // The courses with the most requests in the period, highest first.
        public IReadOnlyList<CourseDemandRow> Rows { get; init; } = Array.Empty<CourseDemandRow>();

        // Total requests divided by total verified tutors over the listed courses; null when there are no verified tutors.
        public double? OverallRequestsPerTutor { get; init; }

        // KPI strip and totals row (listed courses only)
        public int TotalRequests => Rows.Sum(r => r.TotalRequests);
        public int ContentClarification => Rows.Sum(r => r.ContentClarification);
        public int ExamPreparation => Rows.Sum(r => r.ExamPreparation);
        public int AssignmentAssistance => Rows.Sum(r => r.AssignmentAssistance);
        public int StudySkills => Rows.Sum(r => r.StudySkills);
        public int Urgent => Rows.Sum(r => r.Urgent);
        public int Unfulfilled => Rows.Sum(r => r.Unfulfilled);
        public int VerifiedTutors => Rows.Sum(r => r.VerifiedTutors);
        public int PendingQualifications => Rows.Sum(r => r.PendingQualifications);
        public int CoursesFlaggedRecruit => Rows.Count(r => r.RecruitTutors);
    }

    public sealed class CourseDemandRow
    {
        public string CourseCode { get; init; } = string.Empty;
        public string CourseName { get; init; } = string.Empty;
        public int TotalRequests { get; init; }
        public int ContentClarification { get; init; }
        public int ExamPreparation { get; init; }
        public int AssignmentAssistance { get; init; }
        public int StudySkills { get; init; }
        public int Urgent { get; init; }
        public int Unfulfilled { get; init; }
        public int VerifiedTutors { get; init; }
        public int PendingQualifications { get; init; }

        // null when the course has no verified tutor (shown as "No tutor")
        public double? RequestsPerTutor { get; init; }

        public bool RecruitTutors { get; init; }
        public bool VerifyPendingFirst { get; init; }
        public bool NotifyLecturer { get; init; }

        // Flags in the order Recruit tutors, Verify pending first, Notify lecturer; "-" when none apply.
        public string Flags
        {
            get
            {
                List<string> flags = new();
                if (RecruitTutors) flags.Add("Recruit tutors");
                if (VerifyPendingFirst) flags.Add("Verify pending first");
                if (NotifyLecturer) flags.Add("Notify lecturer");
                return flags.Count == 0 ? "-" : string.Join("; ", flags);
            }
        }
    }
}

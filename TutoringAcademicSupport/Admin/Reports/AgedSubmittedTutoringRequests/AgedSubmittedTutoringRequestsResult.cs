namespace TutoringAcademicSupport.Admin.Reports.AgedSubmittedTutoringRequests
{
    public sealed class AgedSubmittedTutoringRequestsResult
    {
        public DateTime RunDate { get; init; }

        // Ordered oldest first.
        public IReadOnlyList<AgedRequestRow> Rows { get; init; } = Array.Empty<AgedRequestRow>();

        // KPI strip
        public int OutstandingCount => Rows.Count;
        public int OldestAgeDays => Rows.Count == 0 ? 0 : Rows.Max(r => r.AgeDays);
        public double AverageAgeDays => Rows.Count == 0 ? 0 : Rows.Average(r => r.AgeDays);
        public int UrgentOrHighCount => Rows.Count(r => r.Priority is "Urgent" or "High");

        public int CountWithFlag(string actionFlag) => Rows.Count(r => r.ActionFlag == actionFlag);
    }

    // One Submitted request aged 7 days or more.
    public sealed class AgedRequestRow
    {
        public int RequestId { get; init; }
        public DateTime SubmissionDate { get; init; }
        public int AgeDays { get; init; }
        public int StudentId { get; init; }
        public string StudentName { get; init; } = string.Empty;
        public string Faculty { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string RiskLevel { get; init; } = string.Empty;
        public string CourseCode { get; init; } = string.Empty;
        public string CourseName { get; init; } = string.Empty;
        public string SupportType { get; init; } = string.Empty;
        public string Priority { get; init; } = string.Empty;
        public string ActionFlag { get; init; } = string.Empty;
    }
}

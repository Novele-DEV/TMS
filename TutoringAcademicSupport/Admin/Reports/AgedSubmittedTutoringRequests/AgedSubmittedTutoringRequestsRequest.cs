namespace TutoringAcademicSupport.Admin.Reports.AgedSubmittedTutoringRequests
{
    // Carries the date the report is run for (request ages are measured up to this date)
    // and the optional filters. A null filter means "All".
    public sealed class AgedSubmittedTutoringRequestsRequest
    {
        public DateTime RunDate { get; }
        public string? CourseCode { get; }
        public string? Priority { get; }
        public string? ActionFlag { get; }

        public AgedSubmittedTutoringRequestsRequest(DateTime runDate, string? courseCode, string? priority, string? actionFlag)
        {
            RunDate = runDate;
            CourseCode = courseCode;
            Priority = priority;
            ActionFlag = actionFlag;
        }
    }
}

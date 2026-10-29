namespace TutoringAcademicSupport.Admin.Reports.TutorWorkloadAndCompletionRates
{
    // Carries the reporting period chosen by the administrator (both dates included)
    // and the optional workload flag filter. A null filter means "All".
    public sealed class TutorWorkloadAndCompletionRatesRequest
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string? WorkloadFlag { get; }

        public TutorWorkloadAndCompletionRatesRequest(DateTime startDate, DateTime endDate, string? workloadFlag)
        {
            StartDate = startDate;
            EndDate = endDate;
            WorkloadFlag = workloadFlag;
        }
    }
}

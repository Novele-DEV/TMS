namespace TutoringAcademicSupport.Admin.Reports.TutorWorkloadAndCompletionRates
{
    public static class TutorWorkloadAndCompletionRatesValidator
    {
        public static readonly string[] WorkloadFlags =
        {
            TutorWorkloadAndCompletionRatesHandler.HighLoad,
            TutorWorkloadAndCompletionRatesHandler.LowLoad,
            TutorWorkloadAndCompletionRatesHandler.LowCompletion,
            TutorWorkloadAndCompletionRatesHandler.NoFlagFilter
        };

        public static string Validate(TutorWorkloadAndCompletionRatesRequest request)
        {
            if (request.StartDate.Date > request.EndDate.Date)
            {
                return "The start date must not be after the end date.";
            }

            if (request.WorkloadFlag is not null && Array.IndexOf(WorkloadFlags, request.WorkloadFlag) < 0)
            {
                return "Please select a valid workload flag.";
            }

            return string.Empty;
        }
    }
}

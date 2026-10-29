namespace TutoringAcademicSupport.Admin.Reports.AgedSubmittedTutoringRequests
{
    public static class AgedSubmittedTutoringRequestsValidator
    {
        // the priority values allowed by the TutoringRequest table
        public static readonly string[] Priorities = { "Urgent", "High", "Medium", "Low" };

        public static readonly string[] ActionFlags =
        {
            AgedSubmittedTutoringRequestsHandler.Escalate,
            AgedSubmittedTutoringRequestsHandler.VerifyNow,
            AgedSubmittedTutoringRequestsHandler.FollowUp
        };

        public static string Validate(AgedSubmittedTutoringRequestsRequest request)
        {
            if (request.RunDate.Date > DateTime.Today)
            {
                return "The run date cannot be in the future.";
            }

            if (request.CourseCode is { Length: 0 or > 9 })
            {
                return "Please select a valid course.";
            }

            if (request.Priority is not null && Array.IndexOf(Priorities, request.Priority) < 0)
            {
                return "Please select a valid priority.";
            }

            if (request.ActionFlag is not null && Array.IndexOf(ActionFlags, request.ActionFlag) < 0)
            {
                return "Please select a valid action.";
            }

            return string.Empty;
        }
    }
}

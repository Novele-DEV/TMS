namespace TutoringAcademicSupport.Admin.Reports.CourseSupportDemandAndTutorCoverage
{
    public static class CourseSupportDemandAndTutorCoverageValidator
    {
        public static string Validate(CourseSupportDemandAndTutorCoverageRequest request)
        {
            if (request.StartDate.Date > request.EndDate.Date)
            {
                return "The start date must not be after the end date.";
            }

            if (request.Faculty is { Length: 0 or > 100 })
            {
                return "Please select a valid faculty.";
            }

            return string.Empty;
        }
    }
}

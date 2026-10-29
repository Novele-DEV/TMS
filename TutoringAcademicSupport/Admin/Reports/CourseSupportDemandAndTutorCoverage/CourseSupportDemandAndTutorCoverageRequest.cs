namespace TutoringAcademicSupport.Admin.Reports.CourseSupportDemandAndTutorCoverage
{
    // Carries the reporting period chosen by the administrator (both dates included)
    // and the optional faculty filter. A null filter means "All".
    public sealed class CourseSupportDemandAndTutorCoverageRequest
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string? Faculty { get; }

        public CourseSupportDemandAndTutorCoverageRequest(DateTime startDate, DateTime endDate, string? faculty)
        {
            StartDate = startDate;
            EndDate = endDate;
            Faculty = faculty;
        }
    }
}

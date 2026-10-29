namespace TutoringAcademicSupport.Student.ViewTutorAvailability;

public static class ViewTutorAvailabilityValidator
{
    public static string Validate(ViewTutorAvailabilityRequest request)
    {
        return request.TutorId.Trim().Length <= 8
            ? string.Empty
            : "Tutor ID must be 8 characters or fewer.";
    }
}
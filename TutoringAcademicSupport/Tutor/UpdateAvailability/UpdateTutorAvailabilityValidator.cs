namespace TutoringAcademicSupport.Tutor.UpdateAvailability;

public static class UpdateTutorAvailabilityValidator
{
    public static string Validate(UpdateTutorAvailabilityRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.TutorId) || request.TutorId.Trim().Length > 8)
        {
            return "Enter a valid tutor ID.";
        }

        if (!Enum.TryParse(request.Day, true, out DayOfWeek day) || !Enum.IsDefined(day))
        {
            return "Select a valid day of the week.";
        }

        if (request.EndTime.TimeOfDay <= request.StartTime.TimeOfDay)
        {
            return "The end time must be after the start time.";
        }

        return string.Empty;
    }
}

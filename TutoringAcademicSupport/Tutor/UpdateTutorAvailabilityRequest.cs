namespace TutoringAcademicSupport.Tutor;

public sealed class UpdateTutorAvailabilityRequest
{
    public string TutorId { get; init; } = string.Empty;
    public int? AvailabilityId { get; init; }
    public string Day { get; init; } = string.Empty;
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }
}

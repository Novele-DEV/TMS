namespace TutoringAcademicSupport.Admin.AddTutor;

public sealed class AddTutorResult
{
    public bool Success { get; init; }

    public string Message { get; init; } = string.Empty;

    // The ID generated for the new tutor, e.g. TUT00007.
    public string TutorId { get; init; } = string.Empty;
}

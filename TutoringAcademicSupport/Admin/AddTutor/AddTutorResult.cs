namespace TutoringAcademicSupport.Admin.AddTutor;

public sealed class AddTutorResult
{
    public bool Success { get; init; }

    public string Message { get; init; } = string.Empty;

    // The ID generated for the new tutor, e.g. TUT00007.
    public string TutorId { get; init; } = string.Empty;

    // The tutor's first password, shown once to the admin to pass on; only its hash is stored.
    public string StartingPassword { get; init; } = string.Empty;
}

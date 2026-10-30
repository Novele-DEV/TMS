namespace TutoringAcademicSupport.EntryPoint.Login
{
    public sealed class LoginResult
    {
        public bool Success { get; init; }

        public string Message { get; init; } = string.Empty;

        public string Role { get; init; } = string.Empty;

        public int UserId { get; init; }

        // Tutor IDs are text (e.g. TUT00001), so a tutor's ID is returned here instead of in UserId.
        public string TutorId { get; init; } = string.Empty;

        public string FirstName { get; init; } = string.Empty;
    }
}
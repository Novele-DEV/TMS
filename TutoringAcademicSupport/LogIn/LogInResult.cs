namespace TutoringAcademicSupport.LogIn
{
    public sealed class LoginResult
    {
        public bool Success { get; init; }

        public string Message { get; init; } = string.Empty;

        public string Role { get; init; } = string.Empty;

        public int UserId { get; init; }

        public string FirstName { get; init; } = string.Empty;
    }
}
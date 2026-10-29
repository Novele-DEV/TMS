namespace TutoringAcademicSupport.EntryPoint.Login
{
    public sealed class LoginRequest
    {
        public string UserId { get; }
        public string Password { get; }
        public string Role { get; }

        public LoginRequest(string userId, string password, string role)
        {
            UserId = userId;
            Password = password;
            Role = role;
        }
    }
}
namespace TutoringAcademicSupport.LogIn
{
    public sealed class LoginRequest
    {
        public string UserId { get; }
        public string Password { get; }

        public LoginRequest(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }
    }
}
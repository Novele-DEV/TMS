namespace TutoringAcademicSupport.LogIn
{
    public static class LoginHandler
    {
        public static LoginResult Handle(LoginRequest request)
        {
            // Database table validation will be added after the exact
            // Access table and column names are confirmed.
            return new LoginResult
            {
                Success = false,
                Message = "Login database validation has not been configured yet."
            };
        }
    }
}
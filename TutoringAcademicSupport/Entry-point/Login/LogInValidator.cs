namespace TutoringAcademicSupport.EntryPoint.Login
{
    public static class LoginValidator
    {
        public static string Validate(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserId))
            {
                return "Please enter your ID.";
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return "Please enter your password.";
            }

            return string.Empty;
        }
    }
}
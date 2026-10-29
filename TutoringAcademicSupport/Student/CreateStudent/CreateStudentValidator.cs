namespace TutoringAcademicSupport.Student.CreateStudent;

public static class CreateStudentValidator
{
    public static string Validate(CreateStudentRequest request)
    {
        if (request.StudentId < 1_000_000 || request.StudentId > 9_999_999)
        {
            return "The student number must include 7 digits.";
        }

        if (string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName))
        {
            return "Please enter the student's first and last name.";
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            return "Please enter an email address.";
        }

        if (string.IsNullOrWhiteSpace(request.Faculty) ||
            string.IsNullOrWhiteSpace(request.Programme))
        {
            return "Please select a faculty and programme.";
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            return "Please enter a password.";
        }

        if (request.Password.Length > 64)
        {
            return "Password must be 64 characters or fewer.";
        }

        if (request.Password != request.ConfirmPassword)
        {
            return "The passwords do not match.";
        }

        return string.Empty;
    }
}

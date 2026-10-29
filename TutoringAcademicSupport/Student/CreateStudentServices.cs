using System;

namespace TutoringAcademicSupport.Student
{
    public sealed class CreateStudentRequest
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Faculty { get; set; } = string.Empty;
        public string Programme { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public sealed class CreateStudentResult
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;
    }

    public static class CreateStudentValidator
    {
        public static string Validate(CreateStudentRequest request)
        {
            if (request.StudentId <= 0)
            {
                return "Please enter a valid student ID.";
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

            return string.Empty;
        }
    }

    public static class CreateStudentHandler
    {
        public static CreateStudentResult Handle(CreateStudentRequest request)
        {
            return new CreateStudentResult
            {
                Success = false,
                Message = "Student database saving has not been configured yet."
            };
        }
    }
}
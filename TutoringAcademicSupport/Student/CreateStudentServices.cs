using System;
using System.Data.OleDb;
using TutoringAcademicSupport.Common.Database;


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
        public string ConfirmPassword { get; set; } = string.Empty;
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

            if (request.StudentId < 1_000_000 || request.StudentId > 9_999_999)
            {
                return "The student number must include 7 digits.";
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return "Please enter a password.";
            }

            if (request.Password.Length > 64)
            {
                return "Password must be fewer than 64 characters.";
            }

            if (request.Password != request.ConfirmPassword)
            {
                return "The passwords do not match.";
            }

            return string.Empty;
        }
    }

    public static class CreateStudentHandler
    {
        public static CreateStudentResult Handle(CreateStudentRequest request)
        {
            string problem = CreateStudentValidator.Validate(request);
            if (problem.Length > 0)
            {
                return new CreateStudentResult { Message = problem };
            }

            DatabaseConnection.EnsureStudentPasswordSchema();
            string passwordHash = PasswordService.HashPassword(request.ConfirmPassword);

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using OleDbTransaction transaction = connection.BeginTransaction();

            if (ValueExists(connection, transaction, "Student", "Student_ID", OleDbType.Integer, request.StudentId))
            {
                return new CreateStudentResult { Message = "A student with this student number already exists." };
            }

            if (ValueExists(connection, transaction, "Student", "Student_Email", OleDbType.VarWChar, request.Email))
            {
                return new CreateStudentResult { Message = "A student with this email address already exists." };
            }

            const string studentInsert = """
                INSERT INTO [Student]
                    ([Student_ID], [Student_FName], [Student_LName], [Student_DoB],
                     [Student_Email], [Student_Phone], [Student_Faculty], [Student_ProgrammeOfStudy],
                     [Student_Password])
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)
                """;

            using (OleDbCommand command = new(studentInsert, connection, transaction))
            {
                command.Parameters.Add("@Student_ID", OleDbType.Integer).Value = request.StudentId;
                command.Parameters.Add("@Student_FName", OleDbType.VarWChar, 50).Value = request.FirstName;
                command.Parameters.Add("@Student_LName", OleDbType.VarWChar, 50).Value = request.LastName;
                command.Parameters.Add("@Student_DoB", OleDbType.Date).Value = request.DateOfBirth;
                command.Parameters.Add("@Student_Email", OleDbType.VarWChar, 100).Value = request.Email;
                command.Parameters.Add("@Student_Phone", OleDbType.VarWChar, 12).Value = request.Phone;
                command.Parameters.Add("@Student_Faculty", OleDbType.VarWChar, 100).Value = request.Faculty;
                command.Parameters.Add("@Student_ProgrammeOfStudy", OleDbType.VarWChar, 100).Value = request.Programme;
                command.Parameters.Add("@Student_Password", OleDbType.VarWChar, 255).Value = passwordHash;
                command.ExecuteNonQuery();
            }

            transaction.Commit();

            return new CreateStudentResult
            {
                Success = true,
                Message = "Student account created successfully."
            };
        }

        private static bool ValueExists(
            OleDbConnection connection,
            OleDbTransaction transaction,
            string table,
            string column,
            OleDbType parameterType,
            object value)
        {
            using OleDbCommand command = new(
                $"SELECT COUNT(*) FROM [{table}] WHERE [{column}] = ?",
                connection,
                transaction);
            command.Parameters.Add("@Value", parameterType).Value = value;
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }
    }
}
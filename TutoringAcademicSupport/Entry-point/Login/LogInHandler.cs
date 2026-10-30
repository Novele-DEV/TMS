using System.Data.OleDb;
using System.Globalization;
using TutoringAcademicSupport.Common.Authentication;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.EntryPoint.Login
{
    public static class LoginHandler
    {
        public static LoginResult Handle(LoginRequest request)
        {
            if (string.Equals(request.Role, "Administrator", StringComparison.OrdinalIgnoreCase))
            {
                return HandleAdministratorLogin(request);
            }

            if (string.Equals(request.Role, "Tutor", StringComparison.OrdinalIgnoreCase))
            {
                return HandleTutorLogin(request);
            }

            if (!string.Equals(request.Role, "Student", StringComparison.OrdinalIgnoreCase))
            {
                return InvalidCredentials();
            }

            return HandleStudentLogin(request);
        }

        private static LoginResult HandleStudentLogin(LoginRequest request)
        {
            if (!int.TryParse(request.UserId, NumberStyles.None, CultureInfo.InvariantCulture, out int studentId) ||
                studentId <= 0)
            {
                return InvalidCredentials();
            }

            const string query = """
                SELECT [Student_FName], [Student_Password]
                FROM [Student]
                WHERE [Student_ID] = ?
                """;

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            using OleDbCommand command = new(query, connection);
            command.Parameters.Add("@Student_ID", OleDbType.Integer).Value = studentId;

            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();
            if (!reader.Read() || reader.IsDBNull(1))
            {
                return InvalidCredentials();
            }

            string firstName = reader.GetString(0);
            string passwordHash = reader.GetString(1);
            if (!PasswordService.VerifyPassword(passwordHash, request.Password))
            {
                return InvalidCredentials();
            }

            return new LoginResult
            {
                Success = true,
                Role = "Student",
                UserId = studentId,
                FirstName = firstName
            };
        }

        private static LoginResult HandleAdministratorLogin(LoginRequest request)
        {
            const string query = """
                SELECT [Admin_FName], [Admin_Password]
                FROM [Administrator]
                WHERE [Admin_ID] = ?
                """;

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            using OleDbCommand command = new(query, connection);
            command.Parameters.Add("@Admin_ID", OleDbType.VarWChar, 8).Value = request.UserId.Trim();

            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();
            if (!reader.Read() || reader.IsDBNull(1))
            {
                return InvalidCredentials();
            }

            string firstName = reader.GetString(0);
            string passwordHash = reader.GetString(1);
            if (!PasswordService.VerifyPassword(passwordHash, request.Password))
            {
                return InvalidCredentials();
            }

            return new LoginResult
            {
                Success = true,
                Role = "Administrator",
                FirstName = firstName
            };
        }

        // Same checks as the administrator login, against the Tutor table.
        private static LoginResult HandleTutorLogin(LoginRequest request)
        {
            const string query = """
                SELECT [Tutor_ID], [Tutor_FName], [Tutor_Password]
                FROM [Tutor]
                WHERE [Tutor_ID] = ?
                """;

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            using OleDbCommand command = new(query, connection);
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = request.UserId.Trim();

            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();
            if (!reader.Read() || reader.IsDBNull(2))
            {
                return InvalidCredentials();
            }

            string tutorId = reader.GetString(0); // as stored, e.g. TUT00001 even if typed tut00001
            string firstName = reader.GetString(1);
            string passwordHash = reader.GetString(2);
            if (!PasswordService.VerifyPassword(passwordHash, request.Password))
            {
                return InvalidCredentials();
            }

            return new LoginResult
            {
                Success = true,
                Role = "Tutor",
                TutorId = tutorId,
                FirstName = firstName
            };
        }

        private static LoginResult InvalidCredentials()
        {
            return new LoginResult
            {
                Message = "Incorrect ID or password. Please try again."
            };
        }
    }
}
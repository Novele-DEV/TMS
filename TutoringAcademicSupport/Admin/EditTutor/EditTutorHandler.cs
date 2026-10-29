using System.Data.OleDb;
using System.Globalization;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Admin.EditTutor
{
    public static class EditTutorHandler
    {
        public static EditTutorResult Handle(EditTutorRequest request)
        {
            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            // Email and phone are unique in the Tutor table, so check them against
            // every other tutor first to give a clear message instead of a database error.
            if (UsedByAnotherTutor(connection, "Tutor_Email", request.Email, request.TutorId))
            {
                return new EditTutorResult { Message = "Another tutor already uses this email address." };
            }

            if (UsedByAnotherTutor(connection, "Tutor_Phone", request.Phone, request.TutorId))
            {
                return new EditTutorResult { Message = "Another tutor already uses this phone number." };
            }

            const string update = """
                UPDATE [Tutor]
                SET [Tutor_FName] = ?,
                    [Tutor_LName] = ?,
                    [Tutor_Email] = ?,
                    [Tutor_Phone] = ?,
                    [Tutor_AcademicAverage] = ?,
                    [Tutor_PreferredMode] = ?
                WHERE [Tutor_ID] = ?
                """;

            // OleDb parameters are matched by position, so they must be added in the same order as the query.
            using OleDbCommand command = new(update, connection);
            command.Parameters.Add("@Tutor_FName", OleDbType.VarWChar, 50).Value = request.FirstName;
            command.Parameters.Add("@Tutor_LName", OleDbType.VarWChar, 50).Value = request.LastName;
            command.Parameters.Add("@Tutor_Email", OleDbType.VarWChar, 100).Value = request.Email;
            command.Parameters.Add("@Tutor_Phone", OleDbType.VarWChar, 12).Value = request.Phone;
            command.Parameters.Add("@Tutor_AcademicAverage", OleDbType.Double).Value = ParseAverage(request.AcademicAverage);
            command.Parameters.Add("@Tutor_PreferredMode", OleDbType.VarWChar, 20).Value = request.PreferredMode;
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = request.TutorId;

            if (command.ExecuteNonQuery() == 0)
            {
                return new EditTutorResult { Message = "The selected tutor could not be found." };
            }

            return new EditTutorResult
            {
                Success = true,
                Message = $"Tutor {request.TutorId} was updated successfully."
            };
        }

        private static bool UsedByAnotherTutor(OleDbConnection connection, string column, string value, string tutorId)
        {
            // column is only ever one of the fixed names above, never user input
            using OleDbCommand command = new(
                $"SELECT COUNT(*) FROM [Tutor] WHERE [{column}] = ? AND [Tutor_ID] <> ?", connection);
            command.Parameters.Add("@Value", OleDbType.VarWChar).Value = value;
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        private static object ParseAverage(string academicAverage)
        {
            if (academicAverage.Length == 0) return DBNull.Value;
            return double.Parse(academicAverage, NumberStyles.Number, CultureInfo.CurrentCulture);
        }
    }
}

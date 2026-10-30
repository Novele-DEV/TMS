using System.IO;
using System.Data.OleDb;
using System.Globalization;
using System.Security;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Admin.EditTutor
{
    public static class EditTutorHandler
    {
        public static EditTutorResult Handle(EditTutorRequest request)
        {
            if (!TryReadCurriculumVitae(request.CurriculumVitaePath, out byte[]? curriculumVitae, out string fileError))
            {
                return new EditTutorResult { Message = fileError };
            }

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

            if (curriculumVitae is not null)
            {
                const string updateCurriculumVitae = """
                    UPDATE [Tutor]
                    SET [CurriculumVitae] = ?
                    WHERE [Tutor_ID] = ?
                    """;

                using OleDbCommand cvCommand = new(updateCurriculumVitae, connection);
                cvCommand.Parameters.Add("@CurriculumVitae", OleDbType.LongVarBinary).Value = curriculumVitae;
                cvCommand.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = request.TutorId;
                if (cvCommand.ExecuteNonQuery() == 0)
                {
                    return new EditTutorResult { Message = "The selected tutor could not be found." };
                }
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

        private static bool TryReadCurriculumVitae(string? path, out byte[]? bytes, out string error)
        {
            bytes = null;
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(path))
                return true;

            try
            {
                if (!string.Equals(Path.GetExtension(path), ".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    error = "The Curriculum Vitae file must be a PDF.";
                    return false;
                }

                FileInfo file = new(path);
                if (!file.Exists)
                {
                    error = "The selected Curriculum Vitae file no longer exists.";
                    return false;
                }

                if (file.Length > EditTutorValidator.MaximumCurriculumVitaeSizeBytes)
                {
                    error = "The Curriculum Vitae PDF must be 5 MB or smaller.";
                    return false;
                }

                bytes = File.ReadAllBytes(path);
            }
            catch (FileNotFoundException)
            {
                error = "The selected Curriculum Vitae file no longer exists.";
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                error = "The selected Curriculum Vitae file no longer exists.";
                return false;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or SecurityException or ArgumentException or NotSupportedException)
            {
                error = "The selected Curriculum Vitae file could not be read. Check that it is not in use and that you have access.";
                return false;
            }

            if (bytes.Length > EditTutorValidator.MaximumCurriculumVitaeSizeBytes)
            {
                error = "The Curriculum Vitae PDF must be 5 MB or smaller.";
                return false;
            }

            if (bytes.Length < 4 ||
                bytes[0] != (byte)'%' ||
                bytes[1] != (byte)'P' ||
                bytes[2] != (byte)'D' ||
                bytes[3] != (byte)'F')
            {
                error = "The selected file does not have a valid PDF signature.";
                return false;
            }

            return true;
        }
    }
}

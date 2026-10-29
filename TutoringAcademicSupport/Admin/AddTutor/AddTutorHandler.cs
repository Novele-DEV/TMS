using System.Data.OleDb;
using System.Globalization;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Admin.AddTutor;

public static class AddTutorHandler
{
    private const string IdPrefix = "TUT";

    public static AddTutorResult Handle(AddTutorRequest request)
    {
        using OleDbConnection connection = DatabaseConnection.GetConnection();
        connection.Open();

        // Email and phone are unique in the Tutor table, so check them first
        // to give a clear message instead of a database error.
        if (ValueExists(connection, "Tutor_Email", request.Email))
        {
            return new AddTutorResult { Message = "Another tutor already uses this email address." };
        }

        if (ValueExists(connection, "Tutor_Phone", request.Phone))
        {
            return new AddTutorResult { Message = "Another tutor already uses this phone number." };
        }

        string tutorId = NextTutorId(connection);

        const string insert = """
            INSERT INTO [Tutor]
                ([Tutor_ID], [Tutor_FName], [Tutor_LName], [Tutor_Email],
                 [Tutor_Phone], [Tutor_AcademicAverage], [Tutor_PreferredMode])
            VALUES (?, ?, ?, ?, ?, ?, ?)
            """;

        // OleDb parameters are matched by position, so they must be added in the same order as the columns.
        using OleDbCommand command = new(insert, connection);
        command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
        command.Parameters.Add("@Tutor_FName", OleDbType.VarWChar, 50).Value = request.FirstName;
        command.Parameters.Add("@Tutor_LName", OleDbType.VarWChar, 50).Value = request.LastName;
        command.Parameters.Add("@Tutor_Email", OleDbType.VarWChar, 100).Value = request.Email;
        command.Parameters.Add("@Tutor_Phone", OleDbType.VarWChar, 12).Value = request.Phone;
        command.Parameters.Add("@Tutor_AcademicAverage", OleDbType.Double).Value = ParseAverage(request.AcademicAverage);
        command.Parameters.Add("@Tutor_PreferredMode", OleDbType.VarWChar, 20).Value = request.PreferredMode;

        command.ExecuteNonQuery();

        return new AddTutorResult
        {
            Success = true,
            TutorId = tutorId,
            Message = $"Tutor {tutorId} was added successfully."
        };
    }

    private static bool ValueExists(OleDbConnection connection, string column, string value)
    {
        // column is only ever one of the fixed names above, never user input
        using OleDbCommand command = new($"SELECT COUNT(*) FROM [Tutor] WHERE [{column}] = ?", connection);
        command.Parameters.Add("@Value", OleDbType.VarWChar).Value = value;
        return Convert.ToInt32(command.ExecuteScalar()) > 0;
    }

    // Tutor IDs are stored as text in the form TUT00001, so the next one is worked out here.
    private static string NextTutorId(OleDbConnection connection)
    {
        using OleDbCommand command = new("SELECT MAX([Tutor_ID]) FROM [Tutor] WHERE [Tutor_ID] LIKE 'TUT%'", connection);
        object? highest = command.ExecuteScalar();

        int nextNumber = 1;
        if (highest is string highestId && int.TryParse(highestId.AsSpan(IdPrefix.Length), out int number))
        {
            nextNumber = number + 1;
        }

        if (nextNumber > 99999)
        {
            throw new InvalidOperationException("No more tutor IDs are available.");
        }

        return IdPrefix + nextNumber.ToString("D5", CultureInfo.InvariantCulture);
    }

    private static object ParseAverage(string academicAverage)
    {
        if (academicAverage.Length == 0) return DBNull.Value;
        return double.Parse(academicAverage, NumberStyles.Number, CultureInfo.CurrentCulture);
    }
}

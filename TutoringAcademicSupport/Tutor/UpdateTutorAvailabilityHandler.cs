using System.Data;
using System.Data.OleDb;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Tutor;

public static class UpdateTutorAvailabilityHandler
{
    private static readonly DateTime AccessTimeOrigin = new(1899, 12, 30);

    public static DataTable LoadForTutor(string tutorId)
    {
        const string query = """
            SELECT [Avail_ID], [Tutor_ID], [Avail_Day], [Avail_StartTime], [Avail_EndTime]
            FROM [TutorAvailability]
            WHERE [Tutor_ID] = ?
            ORDER BY [Avail_Day], [Avail_StartTime]
            """;

        using OleDbConnection connection = DatabaseConnection.GetConnection();
        using OleDbCommand command = new(query, connection);
        command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
        using OleDbDataAdapter adapter = new(command);

        DataTable availability = new();
        connection.Open();
        adapter.Fill(availability);
        return availability;
    }

    public static UpdateTutorAvailabilityResult Save(UpdateTutorAvailabilityRequest request)
    {
        string validationMessage = UpdateTutorAvailabilityValidator.Validate(request);
        if (validationMessage.Length > 0)
        {
            return new UpdateTutorAvailabilityResult { Message = validationMessage };
        }

        using OleDbConnection connection = DatabaseConnection.GetConnection();
        connection.Open();
        using OleDbTransaction transaction = connection.BeginTransaction();

        if (!TutorExists(connection, transaction, request.TutorId.Trim()))
        {
            return new UpdateTutorAvailabilityResult { Message = "The tutor ID was not found." };
        }

        if (HasOverlappingAvailability(connection, transaction, request))
        {
            return new UpdateTutorAvailabilityResult
            {
                Message = "This time overlaps another availability slot for the tutor."
            };
        }

        if (request.AvailabilityId.HasValue)
        {
            const string update = """
                UPDATE [TutorAvailability]
                SET [Avail_Day] = ?, [Avail_StartTime] = ?, [Avail_EndTime] = ?
                WHERE [Avail_ID] = ? AND [Tutor_ID] = ?
                """;

            using OleDbCommand command = new(update, connection, transaction);
            command.Parameters.Add("@Avail_Day", OleDbType.VarWChar, 10).Value = request.Day;
            command.Parameters.Add("@Avail_StartTime", OleDbType.Date).Value = ToAccessTime(request.StartTime);
            command.Parameters.Add("@Avail_EndTime", OleDbType.Date).Value = ToAccessTime(request.EndTime);
            command.Parameters.Add("@Avail_ID", OleDbType.Integer).Value = request.AvailabilityId.Value;
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = request.TutorId.Trim();

            if (command.ExecuteNonQuery() != 1)
            {
                return new UpdateTutorAvailabilityResult { Message = "The availability slot was not found." };
            }
        }
        else
        {
            const string insert = """
                INSERT INTO [TutorAvailability]
                    ([Avail_ID], [Tutor_ID], [Avail_Day], [Avail_StartTime], [Avail_EndTime])
                VALUES (?, ?, ?, ?, ?)
                """;

            using OleDbCommand command = new(insert, connection, transaction);
            command.Parameters.Add("@Avail_ID", OleDbType.Integer).Value = NextAvailabilityId(connection, transaction);
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = request.TutorId.Trim();
            command.Parameters.Add("@Avail_Day", OleDbType.VarWChar, 10).Value = request.Day;
            command.Parameters.Add("@Avail_StartTime", OleDbType.Date).Value = ToAccessTime(request.StartTime);
            command.Parameters.Add("@Avail_EndTime", OleDbType.Date).Value = ToAccessTime(request.EndTime);
            command.ExecuteNonQuery();
        }

        transaction.Commit();
        return new UpdateTutorAvailabilityResult
        {
            Success = true,
            Message = "Tutor availability was saved."
        };
    }

    public static UpdateTutorAvailabilityResult Delete(string tutorId, int availabilityId)
    {
        if (string.IsNullOrWhiteSpace(tutorId) || tutorId.Trim().Length > 8 || availabilityId <= 0)
        {
            return new UpdateTutorAvailabilityResult { Message = "Select a valid availability slot to delete." };
        }

        const string delete = """
            DELETE FROM [TutorAvailability]
            WHERE [Avail_ID] = ? AND [Tutor_ID] = ?
            """;

        using OleDbConnection connection = DatabaseConnection.GetConnection();
        using OleDbCommand command = new(delete, connection);
        command.Parameters.Add("@Avail_ID", OleDbType.Integer).Value = availabilityId;
        command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId.Trim();
        connection.Open();

        if (command.ExecuteNonQuery() != 1)
        {
            return new UpdateTutorAvailabilityResult { Message = "The availability slot was not found." };
        }

        return new UpdateTutorAvailabilityResult
        {
            Success = true,
            Message = "Tutor availability was deleted."
        };
    }

    private static bool TutorExists(
        OleDbConnection connection,
        OleDbTransaction transaction,
        string tutorId)
    {
        using OleDbCommand command = new(
            "SELECT COUNT(*) FROM [Tutor] WHERE [Tutor_ID] = ?",
            connection,
            transaction);
        command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
        return Convert.ToInt32(command.ExecuteScalar()) > 0;
    }

    private static bool HasOverlappingAvailability(
        OleDbConnection connection,
        OleDbTransaction transaction,
        UpdateTutorAvailabilityRequest request)
    {
        string query = request.AvailabilityId.HasValue
            ? """
              SELECT COUNT(*) FROM [TutorAvailability]
              WHERE [Tutor_ID] = ? AND [Avail_Day] = ? AND [Avail_ID] <> ?
                AND [Avail_StartTime] < ? AND [Avail_EndTime] > ?
              """
            : """
              SELECT COUNT(*) FROM [TutorAvailability]
              WHERE [Tutor_ID] = ? AND [Avail_Day] = ?
                AND [Avail_StartTime] < ? AND [Avail_EndTime] > ?
              """;

        using OleDbCommand command = new(query, connection, transaction);
        command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = request.TutorId.Trim();
        command.Parameters.Add("@Avail_Day", OleDbType.VarWChar, 10).Value = request.Day;
        if (request.AvailabilityId.HasValue)
        {
            command.Parameters.Add("@Avail_ID", OleDbType.Integer).Value = request.AvailabilityId.Value;
        }

        command.Parameters.Add("@EndTime", OleDbType.Date).Value = ToAccessTime(request.EndTime);
        command.Parameters.Add("@StartTime", OleDbType.Date).Value = ToAccessTime(request.StartTime);
        return Convert.ToInt32(command.ExecuteScalar()) > 0;
    }

    private static int NextAvailabilityId(OleDbConnection connection, OleDbTransaction transaction)
    {
        using OleDbCommand command = new("SELECT MAX([Avail_ID]) FROM [TutorAvailability]", connection, transaction);
        object? highestId = command.ExecuteScalar();
        if (highestId == null || highestId == DBNull.Value)
        {
            return 1;
        }

        int highest = Convert.ToInt32(highestId);
        if (highest == int.MaxValue)
        {
            throw new InvalidOperationException("No more availability IDs are available.");
        }

        return highest + 1;
    }

    private static DateTime ToAccessTime(DateTime time)
    {
        return AccessTimeOrigin.Add(time.TimeOfDay);
    }
}

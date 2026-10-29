using System.Data;
using System.Data.OleDb;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Student.ViewTutorAvailability;

public static class ViewTutorAvailabilityHandler
{
    public static ViewTutorAvailabilityResult Handle(ViewTutorAvailabilityRequest request)
    {
        string validationMessage = ViewTutorAvailabilityValidator.Validate(request);
        if (validationMessage.Length > 0)
        {
            return new ViewTutorAvailabilityResult { Message = validationMessage };
        }

        const string query = """
            SELECT [TutorAvailability].[Tutor_ID],
                   [Tutor].[Tutor_FName],
                   [Tutor].[Tutor_LName],
                   [TutorAvailability].[Avail_Day],
                   [TutorAvailability].[Avail_StartTime],
                   [TutorAvailability].[Avail_EndTime]
            FROM [Tutor]
            INNER JOIN [TutorAvailability]
                ON [Tutor].[Tutor_ID] = [TutorAvailability].[Tutor_ID]
            WHERE (? = '' OR [TutorAvailability].[Tutor_ID] = ?)
            ORDER BY [TutorAvailability].[Avail_Day],
                     [TutorAvailability].[Avail_StartTime],
                     [TutorAvailability].[Tutor_ID]
            """;

        using OleDbConnection connection = DatabaseConnection.GetConnection();
        using OleDbCommand command = new(query, connection);
        string tutorId = request.TutorId.Trim();
        command.Parameters.Add("@FilterEmpty", OleDbType.VarWChar, 8).Value = tutorId;
        command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
        using OleDbDataAdapter adapter = new(command);

        DataTable availability = new();
        connection.Open();
        adapter.Fill(availability);

        return new ViewTutorAvailabilityResult
        {
            Success = true,
            Availability = availability,
            Message = availability.Rows.Count == 0
                ? "No tutor availability was found."
                : $"Loaded {availability.Rows.Count} availability slot(s)."
        };
    }
}
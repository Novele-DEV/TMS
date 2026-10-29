using System.Data.OleDb;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Admin.Reports.TutorWorkloadAndCompletionRates
{
    // Report 5.2: sessions scheduled and completed per tutor in the chosen period.
    public static class TutorWorkloadAndCompletionRatesHandler
    {
        public const string HighLoad = "High load";
        public const string LowLoad = "Low load";
        public const string LowCompletion = "Low completion";

        // filter value for tutors that carry no flag
        public const string NoFlagFilter = "No flag";

        // Thresholds from the Milestone 2 flag rules (configurable by the Academic Coordinator).
        private const double HighLoadShareOfAverage = 1.30;
        private const double LowLoadShareOfAverage = 0.50;
        private const double LowCompletionRate = 0.85;

        public static TutorWorkloadAndCompletionRatesResult Handle(TutorWorkloadAndCompletionRatesRequest request)
        {
            DateTime startDate = request.StartDate.Date;
            DateTime endDate = request.EndDate.Date;

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            List<(string Id, string Name)> tutors = LoadTutors(connection);
            Dictionary<string, (int Scheduled, int Completed, double Hours)> totals =
                LoadSessionTotals(connection, startDate, endDate);

            int totalScheduled = totals.Values.Sum(t => t.Scheduled);
            double averageScheduled = tutors.Count == 0 ? 0 : (double)totalScheduled / tutors.Count;

            // Every tutor gets a row, so tutors with no sessions (the underutilised ones) still appear.
            List<TutorWorkloadRow> rows = tutors
                .Select(tutor =>
                {
                    totals.TryGetValue(tutor.Id, out var t);
                    double? rate = t.Scheduled == 0 ? null : (double)t.Completed / t.Scheduled;

                    return new TutorWorkloadRow
                    {
                        TutorId = tutor.Id,
                        TutorName = tutor.Name,
                        Scheduled = t.Scheduled,
                        Completed = t.Completed,
                        CompletionRate = rate,
                        HoursDelivered = t.Hours,
                        Flags = WorkloadFlags(t.Scheduled, rate, averageScheduled)
                    };
                })
                .Where(row => MatchesFilter(row, request.WorkloadFlag))
                .OrderByDescending(r => r.Scheduled)
                .ThenBy(r => r.TutorId)
                .ToList();

            return new TutorWorkloadAndCompletionRatesResult
            {
                StartDate = startDate,
                EndDate = endDate,
                Rows = rows,
                AllTutorCount = tutors.Count,
                AverageScheduledAllTutors = averageScheduled
            };
        }

        // The flag filter is applied after the flags are calculated, so it only hides rows.
        private static bool MatchesFilter(TutorWorkloadRow row, string? workloadFlag)
        {
            return workloadFlag switch
            {
                null => true,
                NoFlagFilter => row.Flags.Count == 0,
                _ => row.Flags.Contains(workloadFlag)
            };
        }

        private static List<(string Id, string Name)> LoadTutors(OleDbConnection connection)
        {
            const string query = "SELECT [Tutor_ID], [Tutor_FName], [Tutor_LName] FROM [Tutor] ORDER BY [Tutor_ID]";

            using OleDbCommand command = new(query, connection);
            using OleDbDataReader reader = command.ExecuteReader();

            List<(string Id, string Name)> tutors = new();
            while (reader.Read())
            {
                tutors.Add((Text(reader, "Tutor_ID"), $"{Text(reader, "Tutor_FName")} {Text(reader, "Tutor_LName")}"));
            }

            return tutors;
        }

        // Scheduled = sessions in the period that are not Cancelled.
        // Completed = those with status Completed; hours are summed over completed sessions only.
        private static Dictionary<string, (int Scheduled, int Completed, double Hours)> LoadSessionTotals(
            OleDbConnection connection, DateTime startDate, DateTime endDate)
        {
            const string query = """
                SELECT [Tutor_ID], [Session_Status], [Session_StartTime], [Session_EndTime]
                FROM [TutoringSession]
                WHERE [Session_Date] >= ? AND [Session_Date] < ?
                  AND [Session_Status] <> 'Cancelled'
                """;

            using OleDbCommand command = new(query, connection);
            command.Parameters.Add("@StartDate", OleDbType.Date).Value = startDate;
            command.Parameters.Add("@EndDateExclusive", OleDbType.Date).Value = endDate.AddDays(1); // includes the whole end date

            Dictionary<string, (int Scheduled, int Completed, double Hours)> totals = new();
            using OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string tutorId = Text(reader, "Tutor_ID");
                totals.TryGetValue(tutorId, out var t);
                t.Scheduled++;

                if (Text(reader, "Session_Status") == "Completed")
                {
                    t.Completed++;
                    TimeSpan length = Convert.ToDateTime(reader["Session_EndTime"]) - Convert.ToDateTime(reader["Session_StartTime"]);
                    t.Hours += length.TotalHours;
                }

                totals[tutorId] = t;
            }

            return totals;
        }

        // High load: 130%+ of the average scheduled. Low load: 50% or less. Low completion: under 85%.
        private static List<string> WorkloadFlags(int scheduled, double? completionRate, double averageScheduled)
        {
            List<string> flags = new();

            if (averageScheduled > 0 && scheduled >= HighLoadShareOfAverage * averageScheduled) flags.Add(HighLoad);
            if (scheduled <= LowLoadShareOfAverage * averageScheduled) flags.Add(LowLoad);
            if (completionRate < LowCompletionRate) flags.Add(LowCompletion);

            return flags;
        }

        private static string Text(OleDbDataReader reader, string column)
        {
            return reader[column] as string ?? string.Empty;
        }
    }
}

namespace TutoringAcademicSupport.Admin.Reports.TutorWorkloadAndCompletionRates
{
    public sealed class TutorWorkloadAndCompletionRatesResult
    {
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        // The tutors shown after the workload flag filter, busiest first.
        public IReadOnlyList<TutorWorkloadRow> Rows { get; init; } = Array.Empty<TutorWorkloadRow>();

        // The flags compare each tutor with the average of ALL tutors, so filtering never changes a flag.
        public int AllTutorCount { get; init; }
        public double AverageScheduledAllTutors { get; init; }

        // KPI strip and totals row: these cover the tutors shown.
        public int TotalScheduled => Rows.Sum(r => r.Scheduled);
        public int TotalCompleted => Rows.Sum(r => r.Completed);
        public double HoursDelivered => Rows.Sum(r => r.HoursDelivered);
        public double? CompletionRate => TotalScheduled == 0 ? null : (double)TotalCompleted / TotalScheduled;
    }

    public sealed class TutorWorkloadRow
    {
        public string TutorId { get; init; } = string.Empty;
        public string TutorName { get; init; } = string.Empty;
        public int Scheduled { get; init; }
        public int Completed { get; init; }

        // null when the tutor had no scheduled sessions (shown as "n/a")
        public double? CompletionRate { get; init; }

        public double HoursDelivered { get; init; }

        // e.g. "High load; Low completion"; empty when no flag applies
        public IReadOnlyList<string> Flags { get; init; } = Array.Empty<string>();
    }
}

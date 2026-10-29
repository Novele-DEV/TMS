namespace TutoringAcademicSupport.Admin.Reports
{
    // The parts of a generated report shown around its table: title, period, active filters,
    // KPI strip and summary lines. Captured when the report is generated so the export
    // and printout always match what is on screen.
    public sealed class ReportDetails
    {
        public string Title { get; init; } = string.Empty;

        // the period heading, e.g. "As at 29 October 2026" or "Period: October 2026"
        public string PeriodLine { get; init; } = string.Empty;

        // e.g. "Filters: Course = All; Priority = Urgent"
        public string FiltersLine { get; init; } = string.Empty;

        public IReadOnlyList<(string Value, string Caption)> Kpis { get; init; } = Array.Empty<(string, string)>();

        public IReadOnlyList<string> SummaryLines { get; init; } = Array.Empty<string>();

        // printed after the summary; null when the report has no chart or no rows
        public ReportChart? Chart { get; init; }
    }
}

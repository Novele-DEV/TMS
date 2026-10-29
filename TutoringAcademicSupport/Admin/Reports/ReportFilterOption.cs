namespace TutoringAcademicSupport.Admin.Reports
{
    // One entry in a report filter drop-down. Value is null for the "All ..." entry.
    public sealed record ReportFilterOption(string Text, string? Value)
    {
        public override string ToString() => Text;
    }
}

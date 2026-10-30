using System.Globalization;
using System.Text;

namespace TutoringAcademicSupport.Admin.Reports
{
    // Output code shared by the three report forms: grid set-up, filters, KPI tiles,
    // CSV export (opens in Excel) and print preview.
    public static class ReportOutput
    {
        public const string NoRecordsText = "No records match the selected period and filters.";
        public const string NotGeneratedText = "Report not generated: the data could not be retrieved from the database. No figures are shown.";

        public static readonly Color HeaderColour = Color.FromArgb(31, 56, 100);
        public static readonly Color FlagColour = Color.FromArgb(252, 228, 214);
        public static readonly Color TotalsColour = Color.FromArgb(226, 230, 243);
        public static readonly Color ErrorColour = Color.FromArgb(198, 40, 40);

        private const string TotalsRowTag = "Totals";

        // Period heading for a report over a date range. Whole calendar months read as
        // "October 2026" or "September to October 2026"; other ranges show both dates.
        public static string PeriodHeading(DateTime startDate, DateTime endDate)
        {
            DateTime start = startDate.Date;
            DateTime end = endDate.Date;
            bool wholeMonths = start.Day == 1 && end.AddDays(1).Day == 1;

            if (wholeMonths && start.Year == end.Year && start.Month == end.Month)
                return $"Period: {start:MMMM yyyy}";

            if (wholeMonths)
                return start.Year == end.Year
                    ? $"Period: {start:MMMM} to {end:MMMM yyyy}"
                    : $"Period: {start:MMMM yyyy} to {end:MMMM yyyy}";

            return start == end
                ? $"Period: {start:dd MMMM yyyy}"
                : $"Period: {start:dd MMM yyyy} to {end:dd MMM yyyy}";
        }

        // Period heading for a report that shows the position on one date.
        public static string AsAtHeading(DateTime date)
        {
            return $"As at {date:dd MMMM yyyy}";
        }

        public static void SetUpGrid(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 248, 252);
            grid.BackgroundColor = SystemColors.Window;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = HeaderColour;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        public static void AddColumn(DataGridView grid, string name, string header, float fillWeight, bool alignRight = false)
        {
            DataGridViewTextBoxColumn column = new()
            {
                Name = name,
                HeaderText = header,
                FillWeight = fillWeight,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            if (alignRight)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            grid.Columns.Add(column);
        }

        public static void MarkFlagCell(DataGridViewCell cell)
        {
            cell.Style.BackColor = FlagColour;
            cell.Style.Font = new Font(cell.DataGridView!.Font, FontStyle.Bold);
        }

        public static void MarkTotalsRow(DataGridViewRow row)
        {
            row.Tag = TotalsRowTag;
            row.DefaultCellStyle.BackColor = TotalsColour;
            row.DefaultCellStyle.Font = new Font(row.DataGridView!.Font, FontStyle.Bold);
        }

        public static bool IsTotalsRow(DataGridViewRow row)
        {
            return Equals(row.Tag, TotalsRowTag);
        }

        // Fills a filter drop-down with an "All ..." entry followed by the given options.
        public static void FillFilter(ComboBox combo, string allText, IEnumerable<ReportFilterOption> options)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Items.Clear();
            combo.Items.Add(new ReportFilterOption(allText, null));
            combo.Items.AddRange(options.Cast<object>().ToArray());
            combo.SelectedIndex = 0;
        }

        // The selected filter value, or null when "All ..." is selected.
        public static string? FilterValue(ComboBox combo)
        {
            return (combo.SelectedItem as ReportFilterOption)?.Value;
        }

        public static string FilterText(ComboBox combo)
        {
            return (combo.SelectedItem as ReportFilterOption)?.Text ?? string.Empty;
        }

        // Shows the KPI strip as a row of tiles: a large value with a caption under it.
        public static void ShowKpis(FlowLayoutPanel panel, IEnumerable<(string Value, string Caption)> kpis)
        {
            panel.Controls.Clear();

            // tiles take their height from the panel, so they scale with it at any display setting
            int tileHeight = Math.Max(40, panel.ClientSize.Height - 4);

            foreach ((string value, string caption) in kpis)
            {
                panel.Controls.Add(new Label
                {
                    AutoSize = false,
                    Size = new Size(215, tileHeight),
                    Margin = new Padding(0, 0, 10, 0),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = TotalsColour,
                    ForeColor = HeaderColour,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Text = value + Environment.NewLine + caption
                });
            }
        }

        // Clears a report after a failed query, so a failure never looks like a report with zero results.
        public static void ShowNotGenerated(DataGridView grid, FlowLayoutPanel kpiPanel, Label statusLabel, Label summaryLabel,
            Label periodLabel, ReportChartPanel? chartPanel = null)
        {
            grid.Rows.Clear();
            kpiPanel.Controls.Clear();
            periodLabel.Text = string.Empty;
            if (chartPanel is not null) chartPanel.Chart = null;
            statusLabel.ForeColor = ErrorColour;
            statusLabel.Text = NotGeneratedText;
            summaryLabel.Text = string.Empty;
        }

        public static void ShowPreview(IWin32Window owner, DataGridView grid, ReportDetails details)
        {
            using ReportPrintDocument document = new(details, grid, DateTime.Now);
            using ReportPreviewForm preview = new(document);
            preview.ShowDialog(owner);
        }

        // Writes the report heading, KPIs, table and summary to a CSV file that Excel opens directly.
        public static void ExportCsv(IWin32Window owner, DataGridView grid, string defaultFileName, ReportDetails details)
        {
            using SaveFileDialog dialog = new()
            {
                Title = "Export Report",
                Filter = "CSV file (opens in Excel)|*.csv",
                FileName = defaultFileName
            };

            if (dialog.ShowDialog(owner) != DialogResult.OK) return;

            // Excel splits CSV columns on the Windows list separator, which is ';' in regions that use a decimal comma.
            string separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
            List<DataGridViewColumn> columns = grid.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();
            StringBuilder csv = new();

            csv.AppendLine(CsvField(details.Title, separator));
            csv.AppendLine(CsvField(details.PeriodLine, separator));
            csv.AppendLine(CsvField(details.FiltersLine, separator));
            csv.AppendLine(CsvField(string.Join("  |  ", details.Kpis.Select(k => $"{k.Caption}: {k.Value}")), separator));
            csv.AppendLine();
            csv.AppendLine(string.Join(separator, columns.Select(c => CsvField(c.HeaderText, separator))));

            foreach (DataGridViewRow row in grid.Rows)
            {
                csv.AppendLine(string.Join(separator,
                    columns.Select(c => CsvField(row.Cells[c.Index].FormattedValue?.ToString() ?? string.Empty, separator))));
            }

            csv.AppendLine();
            if (grid.Rows.Count == 0)
            {
                csv.AppendLine(CsvField(NoRecordsText, separator));
            }

            foreach (string line in details.SummaryLines)
            {
                csv.AppendLine(CsvField(line, separator));
            }

            try
            {
                // the byte order mark tells Excel the file is UTF-8, so characters such as ≥ display correctly
                File.WriteAllText(dialog.FileName, csv.ToString(), new UTF8Encoding(true));
                MessageBox.Show(owner, "The report was exported successfully.", "Export Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(owner, "The file could not be saved. Close it in Excel if it is open, then try again.",
                    "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string CsvField(string value, string separator)
        {
            bool needsQuotes = value.Contains(separator) || value.Contains('"') || value.Contains('\n') || value.Contains('\r');
            return needsQuotes ? "\"" + value.Replace("\"", "\"\"") + "\"" : value;
        }
    }
}

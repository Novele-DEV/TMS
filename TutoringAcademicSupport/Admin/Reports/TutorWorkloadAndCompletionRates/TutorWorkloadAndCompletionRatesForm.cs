using System.Data.OleDb;
using System.Diagnostics;
using TutoringAcademicSupport.Admin.Branding;

namespace TutoringAcademicSupport.Admin.Reports.TutorWorkloadAndCompletionRates
{
    // Report 5.2: Tutor Workload by Period.
    public partial class TutorWorkloadAndCompletionRatesForm : Form
    {
        private const string ReportTitle = "Tutor Workload by Period";

        // the last successfully generated report, used for export and print preview; null when there is none
        private ReportDetails? details;

        public TutorWorkloadAndCompletionRatesForm()
        {
            InitializeComponent();
            ByteBetterBrand.AddLogo(this, 80);

            // the period defaults to the current month so far
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Today;

            ReportOutput.FillFilter(cmbWorkloadFlag, "All tutors",
                TutorWorkloadAndCompletionRatesValidator.WorkloadFlags.Select(f => new ReportFilterOption(f, f)));

            ReportOutput.SetUpGrid(dgvReport);
            ReportOutput.AddColumn(dgvReport, "colTutorId", "Tutor ID", 10);
            ReportOutput.AddColumn(dgvReport, "colTutor", "Tutor", 18);
            ReportOutput.AddColumn(dgvReport, "colScheduled", "Scheduled (sessions)", 10, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colCompleted", "Completed (sessions)", 10, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colRate", "Completion rate", 10, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colHours", "Hours delivered", 10, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colFlag", "Workload flag", 22);

            UpdateOutputButtons();
        }

        private void TutorWorkloadAndCompletionRatesForm_Load(object sender, EventArgs e)
        { // the report opens already generated for the default period
            GenerateReport();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbWorkloadFlag.SelectedIndex = 0;
            GenerateReport();
        }

        private void GenerateReport()
        {
            var request = new TutorWorkloadAndCompletionRatesRequest(
                dtpStartDate.Value.Date,
                dtpEndDate.Value.Date,
                ReportOutput.FilterValue(cmbWorkloadFlag));

            string problem = TutorWorkloadAndCompletionRatesValidator.Validate(request);
            if (problem.Length > 0)
            {
                MessageBox.Show(problem, "Check Report Criteria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TutorWorkloadAndCompletionRatesResult result;
            try
            {
                result = TutorWorkloadAndCompletionRatesHandler.Handle(request);
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                ShowNotGenerated();
                return;
            }

            ShowResult(result);
        }

        private void ShowResult(TutorWorkloadAndCompletionRatesResult result)
        {
            string periodLine = ReportOutput.PeriodHeading(result.StartDate, result.EndDate);
            string filtersLine = $"Filters: Workload flag = {ReportOutput.FilterText(cmbWorkloadFlag)}; " +
                                 "Scheduled excludes Cancelled sessions  |  Sorted by sessions scheduled, highest first";

            (string, string)[] kpis =
            {
                (result.TotalScheduled.ToString(), "Sessions scheduled"),
                (result.TotalCompleted.ToString(), "Sessions completed"),
                (Rate(result.CompletionRate), "Completion rate"),
                (result.HoursDelivered.ToString("0.0"), "Hours delivered")
            };

            lblFilter.ForeColor = SystemColors.GrayText;
            lblPeriod.Text = periodLine;
            lblFilter.Text = $"Filters: Workload flag: {ReportOutput.FilterText(cmbWorkloadFlag)}";
            ReportOutput.ShowKpis(pnlKpis, kpis);

            dgvReport.Rows.Clear();
            foreach (TutorWorkloadRow row in result.Rows)
            {
                bool flagged = row.Flags.Count > 0;
                int index = dgvReport.Rows.Add(
                    row.TutorId,
                    row.TutorName,
                    row.Scheduled,
                    row.Completed,
                    Rate(row.CompletionRate),
                    row.HoursDelivered.ToString("0.0"),
                    flagged ? string.Join("; ", row.Flags) : "-");

                if (flagged)
                {
                    ReportOutput.MarkFlagCell(dgvReport.Rows[index].Cells["colFlag"]);
                }
            }

            if (result.Rows.Count > 0)
            {
                int totalsIndex = dgvReport.Rows.Add(
                    $"Total ({result.Rows.Count} tutors)",
                    string.Empty,
                    result.TotalScheduled,
                    result.TotalCompleted,
                    Rate(result.CompletionRate),
                    result.HoursDelivered.ToString("0.0"),
                    string.Empty);
                ReportOutput.MarkTotalsRow(dgvReport.Rows[totalsIndex]);
            }

            // the average used by the flags always covers all tutors, so it is stated separately from the totals
            string basis = $"Flags compare each tutor with the average of all {result.AllTutorCount} tutors: " +
                           $"{result.AverageScheduledAllTutors:0.0} sessions scheduled.";
            lblSummary.Text = result.Rows.Count == 0 ? ReportOutput.NoRecordsText : basis;

            // clustered columns compare scheduled with completed sessions for each tutor shown
            ReportChart chart = new()
            {
                Title = "Sessions scheduled vs completed per tutor",
                PeriodHeading = periodLine,
                ValueAxisTitle = "Sessions",
                Categories = result.Rows.Select(r => r.TutorName).ToList(),
                Series = new[]
                {
                    new ChartSeries("Scheduled", ReportChart.Blue, result.Rows.Select(r => (double)r.Scheduled).ToList()),
                    new ChartSeries("Completed", ReportChart.Orange, result.Rows.Select(r => (double)r.Completed).ToList())
                }
            };
            chartPanel.Chart = chart;

            details = new ReportDetails
            {
                Title = ReportTitle,
                PeriodLine = periodLine,
                FiltersLine = filtersLine,
                Kpis = kpis,
                SummaryLines = new[]
                {
                    basis,
                    "Flag rules: High load = 130% or more of the average; Low load = 50% or less of the average; " +
                    "Low completion = completion rate under 85%."
                },
                Chart = result.Rows.Count == 0 ? null : chart
            };

            UpdateOutputButtons();
        }

        // A failed query clears the report, so it can never look like a period with no sessions.
        private void ShowNotGenerated()
        {
            ReportOutput.ShowNotGenerated(dgvReport, pnlKpis, lblFilter, lblSummary, lblPeriod, chartPanel);
            details = null;
            UpdateOutputButtons();

            MessageBox.Show(
                "The report could not be loaded from the database. Please try again.",
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static string Rate(double? rate)
        {
            return rate.HasValue ? rate.Value.ToString("0.0%") : "n/a";
        }

        private void UpdateOutputButtons()
        {
            btnExport.Enabled = btnPreview.Enabled = details is not null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (details is null) return;
            ReportOutput.ExportCsv(this, dgvReport,
                $"TutorWorkload_{dtpStartDate.Value:yyyyMMdd}_{dtpEndDate.Value:yyyyMMdd}.csv", details);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (details is null) return;
            ReportOutput.ShowPreview(this, dgvReport, details);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

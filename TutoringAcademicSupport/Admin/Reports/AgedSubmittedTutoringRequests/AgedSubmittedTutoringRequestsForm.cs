using System.Data.OleDb;
using System.Diagnostics;
using TutoringAcademicSupport.Admin.Branding;

namespace TutoringAcademicSupport.Admin.Reports.AgedSubmittedTutoringRequests
{
    // Report 5.1: Aged Submitted Tutoring Requests (7+ Days).
    public partial class AgedSubmittedTutoringRequestsForm : Form
    {
        private const string ReportTitle = "Aged Submitted Tutoring Requests (7+ Days)";

        // the last successfully generated report, used for export and print preview; null when there is none
        private ReportDetails? details;

        public AgedSubmittedTutoringRequestsForm()
        {
            InitializeComponent();
            ByteBetterBrand.AddLogo(this, 80);

            dtpRunDate.Value = DateTime.Today;
            dtpRunDate.MaxDate = DateTime.Today; // a report cannot be run for a future date

            ReportOutput.FillFilter(cmbPriority, "All priorities",
                AgedSubmittedTutoringRequestsValidator.Priorities.Select(p => new ReportFilterOption(p, p)));
            ReportOutput.FillFilter(cmbAction, "All actions",
                AgedSubmittedTutoringRequestsValidator.ActionFlags.Select(a => new ReportFilterOption(a, a)));
            ReportOutput.FillFilter(cmbCourse, "All courses", Array.Empty<ReportFilterOption>());

            ReportOutput.SetUpGrid(dgvReport);
            ReportOutput.AddColumn(dgvReport, "colRequestId", "Request ID", 7, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colSubmitted", "Submitted", 9);
            ReportOutput.AddColumn(dgvReport, "colAge", "Age (days)", 6, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colStudent", "Student", 11);
            ReportOutput.AddColumn(dgvReport, "colStudentId", "Student ID", 8);
            ReportOutput.AddColumn(dgvReport, "colFaculty", "Faculty", 8);
            ReportOutput.AddColumn(dgvReport, "colEmail", "Email", 21);
            ReportOutput.AddColumn(dgvReport, "colCourse", "Course", 14);
            ReportOutput.AddColumn(dgvReport, "colSupportType", "Support type", 10);
            ReportOutput.AddColumn(dgvReport, "colPriority", "Priority", 7);
            ReportOutput.AddColumn(dgvReport, "colRisk", "Risk level", 7);
            ReportOutput.AddColumn(dgvReport, "colAction", "Action", 8);

            UpdateOutputButtons();
        }

        private void AgedSubmittedTutoringRequestsForm_Load(object sender, EventArgs e)
        { // load the course filter, then show the report for today
            try
            {
                ReportOutput.FillFilter(cmbCourse, "All courses", AgedSubmittedTutoringRequestsHandler.LoadCourseOptions());
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                ShowNotGenerated();
                return;
            }

            GenerateReport();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbCourse.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 0;
            cmbAction.SelectedIndex = 0;
            GenerateReport();
        }

        private void GenerateReport()
        {
            var request = new AgedSubmittedTutoringRequestsRequest(
                dtpRunDate.Value.Date,
                ReportOutput.FilterValue(cmbCourse),
                ReportOutput.FilterValue(cmbPriority),
                ReportOutput.FilterValue(cmbAction));

            string problem = AgedSubmittedTutoringRequestsValidator.Validate(request);
            if (problem.Length > 0)
            {
                MessageBox.Show(problem, "Check Report Criteria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AgedSubmittedTutoringRequestsResult result;
            try
            {
                result = AgedSubmittedTutoringRequestsHandler.Handle(request);
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                ShowNotGenerated();
                return;
            }

            ShowResult(result);
        }

        private void ShowResult(AgedSubmittedTutoringRequestsResult result)
        {
            // an exception report shows the position on one date, so its period heading is an as-at date
            string periodLine = ReportOutput.AsAtHeading(result.RunDate);
            string filtersLine = "Filters: Request_Status = Submitted; Age ≥ 7 days; " +
                                 $"Course = {ReportOutput.FilterText(cmbCourse)}; Priority = {ReportOutput.FilterText(cmbPriority)}; " +
                                 $"Action = {ReportOutput.FilterText(cmbAction)}  |  Sorted by age, oldest first";

            (string, string)[] kpis =
            {
                (result.OutstandingCount.ToString(), "Outstanding requests"),
                ($"{result.OldestAgeDays} days", "Oldest request"),
                ($"{result.AverageAgeDays:0.0} days", "Average age"),
                (result.UrgentOrHighCount.ToString(), "Urgent or High priority")
            };

            lblFilter.ForeColor = SystemColors.GrayText;
            lblPeriod.Text = periodLine;
            lblFilter.Text = $"Filters: Course: {ReportOutput.FilterText(cmbCourse)}  |  " +
                             $"Priority: {ReportOutput.FilterText(cmbPriority)}  |  Action: {ReportOutput.FilterText(cmbAction)}";
            ReportOutput.ShowKpis(pnlKpis, kpis);

            dgvReport.Rows.Clear();
            foreach (AgedRequestRow row in result.Rows)
            {
                int index = dgvReport.Rows.Add(
                    row.RequestId,
                    row.SubmissionDate.ToString("dd MMM yyyy"),
                    row.AgeDays,
                    row.StudentName,
                    row.StudentId,
                    row.Faculty,
                    row.Email,
                    $"{row.CourseCode} {row.CourseName}",
                    row.SupportType,
                    row.Priority,
                    row.RiskLevel,
                    row.ActionFlag);

                if (row.ActionFlag == AgedSubmittedTutoringRequestsHandler.Escalate)
                {
                    ReportOutput.MarkFlagCell(dgvReport.Rows[index].Cells["colAction"]);
                }
            }

            string summary = result.OutstandingCount == 0
                ? ReportOutput.NoRecordsText
                : $"Total outstanding: {result.OutstandingCount} requests     " +
                  $"Escalate: {result.CountWithFlag(AgedSubmittedTutoringRequestsHandler.Escalate)} | " +
                  $"Verify now: {result.CountWithFlag(AgedSubmittedTutoringRequestsHandler.VerifyNow)} | " +
                  $"Follow up: {result.CountWithFlag(AgedSubmittedTutoringRequestsHandler.FollowUp)}";
            lblSummary.Text = summary;

            details = new ReportDetails
            {
                Title = ReportTitle,
                PeriodLine = periodLine,
                FiltersLine = filtersLine,
                Kpis = kpis,
                SummaryLines = result.OutstandingCount == 0
                    ? Array.Empty<string>()
                    : new[]
                    {
                        summary,
                        "Action rules: Escalate = aged 14+ days or Urgent; Verify now = High and aged 7-13 days; Follow up = all others."
                    }
            };

            UpdateOutputButtons();
        }

        // A failed query clears the report, so it can never look like a report with no outstanding requests.
        private void ShowNotGenerated()
        {
            ReportOutput.ShowNotGenerated(dgvReport, pnlKpis, lblFilter, lblSummary, lblPeriod);
            details = null;
            UpdateOutputButtons();

            MessageBox.Show(
                "The report could not be loaded from the database. Please try again.",
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void UpdateOutputButtons()
        {
            btnExport.Enabled = btnPreview.Enabled = details is not null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (details is null) return;
            ReportOutput.ExportCsv(this, dgvReport, $"AgedSubmittedRequests_{dtpRunDate.Value:yyyyMMdd}.csv", details);
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

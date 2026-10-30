using System.Data.OleDb;
using System.Diagnostics;
using TutoringAcademicSupport.Admin.Branding;

namespace TutoringAcademicSupport.Admin.Reports.CourseSupportDemandAndTutorCoverage
{
    // Report 5.3: Course Support Demand and Tutor Coverage.
    public partial class CourseSupportAndTutorCoverageForm : Form
    {
        private const string ReportTitle = "Course Support Demand and Tutor Coverage";

        // the last successfully generated report, used for export and print preview; null when there is none
        private ReportDetails? details;

        public CourseSupportAndTutorCoverageForm()
        {
            InitializeComponent();
            ByteBetterBrand.AddLogo(this, 80);

            // the period defaults to the current month so far
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Today;

            ReportOutput.FillFilter(cmbFaculty, "All faculties", Array.Empty<ReportFilterOption>());

            ReportOutput.SetUpGrid(dgvReport);
            ReportOutput.AddColumn(dgvReport, "colCourse", "Course", 18);
            ReportOutput.AddColumn(dgvReport, "colTotal", "Total requests", 7, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colContent", "Content Clarif.", 7, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colExam", "Exam Prep.", 7, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colAssignment", "Assign. Assist.", 7, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colStudySkills", "Study Skills", 7, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colUrgent", "Urgent", 6, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colUnfulfilled", "Unfulfilled", 9, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colVerified", "Verified tutors", 7, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colPending", "Pending quals.", 7, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colPerTutor", "Requests per tutor", 7, alignRight: true);
            ReportOutput.AddColumn(dgvReport, "colFlag", "Flag", 22);

            UpdateOutputButtons();
        }

        private void CourseSupportAndTutorCoverageForm_Load(object sender, EventArgs e)
        { // load the faculty filter, then show the report for the default period
            try
            {
                ReportOutput.FillFilter(cmbFaculty, "All faculties", CourseSupportDemandAndTutorCoverageHandler.LoadFacultyOptions());
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
            cmbFaculty.SelectedIndex = 0;
            GenerateReport();
        }

        private void GenerateReport()
        {
            var request = new CourseSupportDemandAndTutorCoverageRequest(
                dtpStartDate.Value.Date,
                dtpEndDate.Value.Date,
                ReportOutput.FilterValue(cmbFaculty));

            string problem = CourseSupportDemandAndTutorCoverageValidator.Validate(request);
            if (problem.Length > 0)
            {
                MessageBox.Show(problem, "Check Report Criteria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CourseSupportDemandAndTutorCoverageResult result;
            try
            {
                result = CourseSupportDemandAndTutorCoverageHandler.Handle(request);
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                ShowNotGenerated();
                return;
            }

            ShowResult(result);
        }

        private void ShowResult(CourseSupportDemandAndTutorCoverageResult result)
        {
            string periodLine = ReportOutput.PeriodHeading(result.StartDate, result.EndDate);
            string filtersLine = $"Filters: Faculty = {ReportOutput.FilterText(cmbFaculty)}  |  " +
                                 "Up to 7 courses with the most requests, highest first";

            (string, string)[] kpis =
            {
                (result.TotalRequests.ToString(), "Requests received"),
                (result.Urgent.ToString(), "Urgent requests"),
                (result.Unfulfilled.ToString(), "Unfulfilled requests"),
                (result.PendingQualifications.ToString(), "Pending tutor qualifications"),
                (result.CoursesFlaggedRecruit.ToString(), "Courses flagged Recruit tutors")
            };

            lblFilter.ForeColor = SystemColors.GrayText;
            lblPeriod.Text = periodLine;
            lblFilter.Text = $"Filters: Faculty: {ReportOutput.FilterText(cmbFaculty)}";
            ReportOutput.ShowKpis(pnlKpis, kpis);

            dgvReport.Rows.Clear();
            foreach (CourseDemandRow row in result.Rows)
            {
                int index = dgvReport.Rows.Add(
                    $"{row.CourseCode} {row.CourseName}",
                    row.TotalRequests,
                    row.ContentClarification,
                    row.ExamPreparation,
                    row.AssignmentAssistance,
                    row.StudySkills,
                    row.Urgent,
                    row.Unfulfilled,
                    row.VerifiedTutors,
                    row.PendingQualifications,
                    PerTutor(row.RequestsPerTutor),
                    row.Flags);

                if (row.Flags != "-")
                {
                    ReportOutput.MarkFlagCell(dgvReport.Rows[index].Cells["colFlag"]);
                }
            }

            if (result.Rows.Count > 0)
            {
                int totalsIndex = dgvReport.Rows.Add(
                    $"Total ({result.Rows.Count} courses)",
                    result.TotalRequests,
                    result.ContentClarification,
                    result.ExamPreparation,
                    result.AssignmentAssistance,
                    result.StudySkills,
                    result.Urgent,
                    result.Unfulfilled,
                    result.VerifiedTutors,
                    result.PendingQualifications,
                    PerTutor(result.OverallRequestsPerTutor),
                    string.Empty);
                ReportOutput.MarkTotalsRow(dgvReport.Rows[totalsIndex]);
            }

            lblSummary.Text = result.Rows.Count == 0
                ? ReportOutput.NoRecordsText
                : $"Overall requests per tutor: {PerTutor(result.OverallRequestsPerTutor)} " +
                  "(total requests ÷ total verified tutors for the courses listed)";

            // stacked columns show how each course's requests split across the four support types
            ReportChart chart = new()
            {
                Title = "Requests by support type per course",
                PeriodHeading = periodLine,
                ValueAxisTitle = "Requests",
                Stacked = true,
                Categories = result.Rows.Select(r => r.CourseCode).ToList(),
                Series = new[]
                {
                    new ChartSeries("Content Clarification", ReportChart.Blue, result.Rows.Select(r => (double)r.ContentClarification).ToList()),
                    new ChartSeries("Exam Preparation", ReportChart.Orange, result.Rows.Select(r => (double)r.ExamPreparation).ToList()),
                    new ChartSeries("Assignment Assistance", ReportChart.Aqua, result.Rows.Select(r => (double)r.AssignmentAssistance).ToList()),
                    new ChartSeries("Study Skills", ReportChart.Yellow, result.Rows.Select(r => (double)r.StudySkills).ToList())
                }
            };
            chartPanel.Chart = chart;

            details = new ReportDetails
            {
                Title = ReportTitle,
                PeriodLine = periodLine,
                FiltersLine = filtersLine,
                Kpis = kpis,
                SummaryLines = result.Rows.Count == 0
                    ? Array.Empty<string>()
                    : new[]
                    {
                        lblSummary.Text,
                        "Flag rules: Recruit tutors = 12 or more requests per tutor, or no verified tutor; " +
                        "Verify pending first = at least 1 pending qualification and requests per tutor at or above the overall ratio; " +
                        "Notify lecturer = Content Clarification + Exam Preparation requests of 20 or more."
                    },
                Chart = result.Rows.Count == 0 ? null : chart
            };

            UpdateOutputButtons();
        }

        // A failed query clears the report, so it can never look like a period with no requests.
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

        private static string PerTutor(double? requestsPerTutor)
        {
            return requestsPerTutor.HasValue ? requestsPerTutor.Value.ToString("0.0") : "No tutor";
        }

        private void UpdateOutputButtons()
        {
            btnExport.Enabled = btnPreview.Enabled = details is not null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (details is null) return;
            ReportOutput.ExportCsv(this, dgvReport,
                $"CourseSupportDemand_{dtpStartDate.Value:yyyyMMdd}_{dtpEndDate.Value:yyyyMMdd}.csv", details);
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

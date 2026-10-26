using System.Data;
using System.Drawing.Printing;
using System.Globalization;

namespace TutoringManagementSystem
{
    public partial class frmReports : Form
    {
        private readonly ReportDataService reportService = new();
        private readonly BindingSource bindingSource = new();

        private readonly DataGridView dgvReport = new();
        private readonly ComboBox cmbReport = new();
        private readonly Button btnRunReport = new();
        private readonly Button btnPrintPreview = new();
        private readonly Button btnCancel = new();
        private readonly Button btnBack = new();
        private readonly Button btnApplyFilter = new();
        private readonly Button btnClearFilter = new();

        private readonly Label lblStatus = new();
        private readonly Label lblReport = new();
        private readonly Label lblStartDate = new();
        private readonly Label lblEndDate = new();
        private readonly Label lblFilterField = new();
        private readonly Label lblFilterValue = new();

        private readonly DateTimePicker dtpStartDate = new();
        private readonly DateTimePicker dtpEndDate = new();
        private readonly ComboBox cmbFilterField = new();
        private readonly ComboBox cmbFilterValue = new();

        private readonly Dictionary<string, string> reportQueries = new()
        {
            { "Aged Submitted Tutoring Requests (7+ Days)", "qryAgedSubmittedRequests" },
            { "Tutor Workload and Completion Rates", "qryTutorWorkload" },
            { "Course Support Demand and Tutor Coverage", "qryCourseDemandCoverage" }
        };

        private readonly PrintDocument printDocument = new();
        private readonly PrintPreviewDialog printPreviewDialog = new();

        private DataTable? currentReport;
        private string currentReportTitle = "Report";
        private string activeFilterDescription = "None";
        private int printRowIndex;
        private int printPageNumber;

        public frmReports()
        {
            InitializeComponent();

            Text = "ByteBetter Tutoring - Reports";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1000, 650);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            BuildInterface();
            ConfigurePrinting();

            if (cmbReport.Items.Count > 0)
                cmbReport.SelectedIndex = 0;

            cmbReport.SelectedIndexChanged += (_, _) =>
            {
                UpdateDateControls();
                LoadFilterOptions();
            };

            dtpStartDate.ValueChanged += (_, _) => LoadFilterOptions();
            dtpEndDate.ValueChanged += (_, _) => LoadFilterOptions();

            UpdateDateControls();
            dgvReport.DataSource = bindingSource;
            LoadFilterOptions();
        }

        private void BuildInterface()
        {
            lblReport.Text = "Select report:";
            lblReport.SetBounds(20, 20, 95, 28);

            cmbReport.SetBounds(115, 15, 390, 32);
            cmbReport.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (string name in reportQueries.Keys)
                cmbReport.Items.Add(name);

            btnRunReport.Text = "Run Report";
            btnRunReport.SetBounds(520, 15, 120, 32);
            btnRunReport.Click += BtnRunReport_Click;

            lblStatus.SetBounds(655, 20, 450, 28);
            lblStatus.ForeColor = Color.DarkGreen;
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left |
                               AnchorStyles.Right;

            lblStartDate.Text = "Start date:";
            lblStartDate.SetBounds(20, 62, 75, 28);

            dtpStartDate.SetBounds(95, 57, 180, 32);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd MMM yyyy";
            dtpStartDate.Value = new DateTime(
                DateTime.Today.Year, DateTime.Today.Month, 1);

            lblEndDate.Text = "End date:";
            lblEndDate.SetBounds(300, 62, 75, 28);

            dtpEndDate.SetBounds(375, 57, 180, 32);
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "dd MMM yyyy";
            dtpEndDate.Value = DateTime.Today;

            lblFilterField.Text = "Filter by:";
            lblFilterField.SetBounds(20, 102, 75, 28);

            cmbFilterField.SetBounds(95, 97, 250, 32);
            cmbFilterField.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterField.SelectedIndexChanged +=
                (_, _) => PopulateFilterValues();

            lblFilterValue.Text = "Value:";
            lblFilterValue.SetBounds(360, 102, 45, 28);

            cmbFilterValue.SetBounds(405, 97, 260, 32);
            cmbFilterValue.DropDownStyle = ComboBoxStyle.DropDownList;

            btnApplyFilter.Text = "Apply Filter";
            btnApplyFilter.SetBounds(680, 97, 110, 32);
            btnApplyFilter.Click += BtnApplyFilter_Click;

            btnClearFilter.Text = "Clear Filter";
            btnClearFilter.SetBounds(800, 97, 110, 32);
            btnClearFilter.Click += BtnClearFilter_Click;

            btnPrintPreview.Text = "Print Preview";
            btnPrintPreview.SetBounds(20, 140, 125, 34);
            btnPrintPreview.Click += BtnPrintPreview_Click;

            btnCancel.Text = "Cancel";
            btnCancel.SetBounds(155, 140, 100, 34);
            btnCancel.Click += BtnCancel_Click;

            btnBack.Text = "Back";
            btnBack.SetBounds(265, 140, 100, 34);
            btnBack.Click += (_, _) => Close();

            dgvReport.SetBounds(20, 190, 1200, 600);
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                               AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AllowUserToOrderColumns = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.MultiSelect = false;
            dgvReport.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvReport.AutoSizeColumnsMode =
    DataGridViewAutoSizeColumnsMode.None;
            dgvReport.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.FixedSingle;
            dgvReport.GridColor = Color.LightGray;
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(31, 78, 121);
            dgvReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReport.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvReport.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.True;
            dgvReport.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;
            dgvReport.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 245, 250);
            dgvReport.Dock = DockStyle.None;
            dgvReport.Anchor = AnchorStyles.Top
                | AnchorStyles.Bottom
                | AnchorStyles.Left
                | AnchorStyles.Right;

            dgvReport.AutoSize = false;
            dgvReport.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgvReport.ScrollBars = ScrollBars.Both;
            dgvReport.Width = ClientSize.Width - 40;
            dgvReport.Height = ClientSize.Height - 210;
            dgvReport.DataError += (_, e) => e.ThrowException = false;

            Controls.AddRange(new Control[]
            {
                lblReport, cmbReport, btnRunReport, lblStatus,
                lblStartDate, dtpStartDate,
                lblEndDate, dtpEndDate,
                lblFilterField, cmbFilterField,
                lblFilterValue, cmbFilterValue,
                btnApplyFilter, btnClearFilter,
                btnPrintPreview, btnCancel, btnBack, dgvReport
            });
        }

        private void UpdateDateControls()
        {
            string selected = cmbReport.SelectedItem?.ToString() ?? "";

            bool usesDates =
                selected == "Tutor Workload and Completion Rates" ||
                selected == "Course Support Demand and Tutor Coverage";

            lblStartDate.Visible = usesDates;
            dtpStartDate.Visible = usesDates;
            lblEndDate.Visible = usesDates;
            dtpEndDate.Visible = usesDates;

            lblFilterField.Visible = true;
            cmbFilterField.Visible = true;
            lblFilterValue.Visible = true;
            cmbFilterValue.Visible = true;
        }

        private string? GetSelectedQueryName()
        {
            string? reportName = cmbReport.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(reportName))
                return null;

            return reportQueries.TryGetValue(
                reportName, out string? queryName)
                ? queryName
                : null;
        }

        private DataTable LoadSelectedReportData()
        {
            string? queryName = GetSelectedQueryName();

            if (string.IsNullOrWhiteSpace(queryName))
                return new DataTable();

            if (queryName == "qryTutorWorkload" ||
                queryName == "qryCourseDemandCoverage")
            {
                return reportService.LoadReport(
                    queryName,
                    dtpStartDate.Value.Date,
                    dtpEndDate.Value.Date);
            }

            return reportService.LoadReport(queryName);
        }

        private void LoadFilterOptions()
        {
            if (cmbReport.SelectedIndex < 0)
                return;

            try
            {
                if (dtpStartDate.Visible &&
                    dtpStartDate.Value.Date > dtpEndDate.Value.Date)
                {
                    cmbFilterField.Items.Clear();
                    cmbFilterValue.Items.Clear();
                    return;
                }

                DataTable filterData = LoadSelectedReportData();

                string previousField =
                    cmbFilterField.SelectedItem?.ToString() ?? "";
                string previousValue =
                    cmbFilterValue.SelectedItem?.ToString() ?? "";

                cmbFilterField.BeginUpdate();
                cmbFilterField.Items.Clear();
                cmbFilterField.Items.Add("All fields");

                foreach (DataColumn column in filterData.Columns)
                    cmbFilterField.Items.Add(column.ColumnName);

                int fieldIndex =
                    cmbFilterField.Items.IndexOf(previousField);

                cmbFilterField.SelectedIndex =
                    fieldIndex >= 0 ? fieldIndex : 0;

                cmbFilterField.EndUpdate();

                PopulateFilterValues(previousValue);

                lblStatus.ForeColor = Color.DarkGreen;
                lblStatus.Text =
                    "Choose an optional filter, then click Run Report.";
            }
            catch (Exception ex)
            {
                cmbFilterField.Items.Clear();
                cmbFilterValue.Items.Clear();

                lblStatus.ForeColor = Color.DarkRed;
                lblStatus.Text = "Filter options could not be loaded.";

                MessageBox.Show(
                    "Unable to load filter options for this report.\n\n" +
                    ex.Message,
                    "Filter Options Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void PopulateFilterValues(string preferredValue = "")
        {
            if (cmbFilterField.SelectedItem == null)
                return;

            DataTable? sourceTable = currentReport;

            if (sourceTable == null ||
                !string.Equals(
                    GetSelectedQueryName(),
                    GetQueryForLoadedReport(),
                    StringComparison.Ordinal))
            {
                try
                {
                    sourceTable = LoadSelectedReportData();
                }
                catch
                {
                    sourceTable = null;
                }
            }

            cmbFilterValue.BeginUpdate();
            cmbFilterValue.Items.Clear();
            cmbFilterValue.Items.Add("All values");

            if (sourceTable != null)
            {
                string selectedField =
                    cmbFilterField.SelectedItem.ToString() ?? "All fields";

                if (selectedField == "All fields")
                {
                    cmbFilterValue.Items.Add("Contains...");
                }
                else if (sourceTable.Columns.Contains(selectedField))
                {
                    DataColumn column =
                        sourceTable.Columns[selectedField]!;

                    var values = sourceTable.AsEnumerable()
                        .Where(row => !row.IsNull(column))
                        .Select(row =>
                            Convert.ToString(
                                row[column],
                                CultureInfo.CurrentCulture) ?? "")
                        .Where(value =>
                            !string.IsNullOrWhiteSpace(value))
                        .Distinct(
                            StringComparer.CurrentCultureIgnoreCase)
                        .OrderBy(
                            value => value,
                            StringComparer.CurrentCultureIgnoreCase)
                        .ToList();

                    foreach (string value in values)
                        cmbFilterValue.Items.Add(value);
                }
            }

            int preferredIndex =
                cmbFilterValue.Items.IndexOf(preferredValue);

            cmbFilterValue.SelectedIndex =
                preferredIndex >= 0 ? preferredIndex : 0;

            cmbFilterValue.EndUpdate();
        }

        private string? GetQueryForLoadedReport()
        {
            if (string.IsNullOrWhiteSpace(currentReportTitle))
                return null;

            return reportQueries.TryGetValue(
                currentReportTitle, out string? query)
                ? query
                : null;
        }

        private void BtnRunReport_Click(object? sender, EventArgs e)
        {
            string? reportName = cmbReport.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(reportName) ||
                !reportQueries.TryGetValue(
                    reportName, out string? queryName) ||
                string.IsNullOrWhiteSpace(queryName))
            {
                MessageBox.Show(
                    "Please select one of the three reports.",
                    "Report Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dtpStartDate.Visible &&
                dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show(
                    "The start date cannot be after the end date.",
                    "Invalid Date Range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string selectedField =
                    cmbFilterField.SelectedItem?.ToString() ?? "All fields";
                string selectedValue =
                    cmbFilterValue.SelectedItem?.ToString() ?? "All values";

                DataTable report = LoadSelectedReportData();

                currentReport = report;
                currentReportTitle = reportName;

                bindingSource.DataSource = report;
                bindingSource.RemoveFilter();
                activeFilterDescription = "None";

                FormatGridColumns();

                if (selectedValue != "All values" &&
                    selectedField != "All fields")
                {
                    ApplyDropdownFilter(selectedField, selectedValue);
                }
                else if (selectedField == "All fields" &&
                         selectedValue == "Contains...")
                {
                    lblStatus.ForeColor = Color.DarkGreen;
                    lblStatus.Text =
                        $"Loaded successfully: {report.Rows.Count} row(s). " +
                        "Select a specific field and value to filter.";
                }
                else
                {
                    lblStatus.ForeColor = Color.DarkGreen;
                    lblStatus.Text =
                        $"Loaded successfully: {report.Rows.Count} row(s).";
                }

                LoadFilterOptions();
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.DarkRed;
                lblStatus.Text = "Report failed to load.";

                MessageBox.Show(
                    "Unable to load the report.\n\n" + ex.Message,
                    "Report Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatGridColumns()
        {
            foreach (DataGridViewColumn column in dgvReport.Columns)
            {
                column.MinimumWidth = 90;
                column.AutoSizeMode =
      DataGridViewAutoSizeColumnMode.None;

                column.Width = 150;
                column.HeaderCell.Style.WrapMode =
                    DataGridViewTriState.True;
            }

            SetHeader("CompletionRate", "Completion Rate");
            SetHeader("HoursDelivered", "Hours Delivered");
            SetHeader("TutorName", "Tutor Name");
            SetHeader("Tutor_ID", "Tutor ID");
            SetHeader("Course_Code", "Course Code");
            SetHeader("Course_Name", "Course Name");

            if (dgvReport.Columns.Contains("CompletionRate"))
            {
                dgvReport.Columns["CompletionRate"]!
                    .DefaultCellStyle.Format = "0.0\\%";
            }
        }

        private void SetHeader(string columnName, string headerText)
        {
            if (dgvReport.Columns.Contains(columnName))
                dgvReport.Columns[columnName]!.HeaderText = headerText;
        }

        private void BtnApplyFilter_Click(object? sender, EventArgs e)
        {
            if (currentReport == null)
            {
                MessageBox.Show(
                    "Select your filter options, then click Run Report to load the report.",
                    "Report Not Loaded",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string selectedField =
                cmbFilterField.SelectedItem?.ToString() ?? "All fields";
            string selectedValue =
                cmbFilterValue.SelectedItem?.ToString() ?? "All values";

            if (selectedField == "All fields" ||
                selectedValue == "All values")
            {
                bindingSource.DataSource = currentReport;
                bindingSource.RemoveFilter();
                activeFilterDescription = "None";

                lblStatus.ForeColor = Color.DarkGreen;
                lblStatus.Text =
                    $"Filter cleared: {currentReport.Rows.Count} row(s).";
                return;
            }

            ApplyDropdownFilter(selectedField, selectedValue);
        }

        private void ApplyDropdownFilter(
            string selectedField,
            string selectedValue)
        {
            if (currentReport == null)
                return;

            try
            {
                string escapedValue = EscapeValue(selectedValue);

                if (selectedField == "All fields")
                {
                    string[] conditions = currentReport.Columns
                        .Cast<DataColumn>()
                        .Select(column =>
                            $"Convert([{EscapeColumn(column.ColumnName)}], " +
                            $"'System.String') = '{escapedValue}'")
                        .ToArray();

                    bindingSource.DataSource = currentReport;
                    bindingSource.Filter = string.Join(" OR ", conditions);
                    activeFilterDescription =
                        $"Any field equals {selectedValue}";
                }
                else
                {
                    DataColumn? column = FindColumn(selectedField);

                    if (column == null)
                    {
                        MessageBox.Show(
                            "The selected filter field is no longer available. Please select it again.",
                            "Filter Field Unavailable",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    bindingSource.DataSource = currentReport;
                    bindingSource.Filter =
                        $"Convert([{EscapeColumn(column.ColumnName)}], " +
                        $"'System.String') = '{escapedValue}'";

                    activeFilterDescription =
                        $"{column.ColumnName} = {selectedValue}";
                }

                lblStatus.ForeColor = Color.DarkGreen;
                lblStatus.Text =
                    $"Filter applied: {bindingSource.Count} row(s).";
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.DarkRed;
                lblStatus.Text = "Filter could not be applied.";

                MessageBox.Show(
                    "Could not apply the selected filter.\n\n" + ex.Message,
                    "Filter Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private DataColumn? FindColumn(string name)
        {
            if (currentReport == null)
                return null;

            return currentReport.Columns
                .Cast<DataColumn>()
                .FirstOrDefault(column =>
                    string.Equals(
                        column.ColumnName,
                        name,
                        StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(
                        column.Caption,
                        name,
                        StringComparison.OrdinalIgnoreCase));
        }

        private static string EscapeColumn(string name)
        {
            return name.Replace("]", "]]");
        }

        private static string EscapeValue(string value)
        {
            return value.Replace("'", "''");
        }

        private void BtnClearFilter_Click(object? sender, EventArgs e)
        {
            if (currentReport != null)
            {
                bindingSource.DataSource = currentReport;
                bindingSource.RemoveFilter();
            }

            if (cmbFilterField.Items.Count > 0)
                cmbFilterField.SelectedIndex = 0;

            if (cmbFilterValue.Items.Count > 0)
                cmbFilterValue.SelectedIndex = 0;

            activeFilterDescription = "None";
            lblStatus.ForeColor = Color.DarkGreen;
            lblStatus.Text = currentReport == null
                ? "Filter selection cleared. Run the report to display results."
                : $"Filter cleared: {currentReport.Rows.Count} row(s).";
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            bindingSource.DataSource = null;
            currentReport = null;
            cmbFilterField.Items.Clear();
            cmbFilterValue.Items.Clear();
            activeFilterDescription = "None";
            dgvReport.DataSource = bindingSource;
            lblStatus.Text = "Report cancelled.";
        }

        private void BtnPrintPreview_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Count == 0)
            {
                MessageBox.Show(
                    "There are no rows to print.",
                    "Nothing to Print",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            printRowIndex = 0;
            printPageNumber = 0;

            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.DefaultPageSettings.Margins =
                new Margins(25, 25, 30, 30);

            printPreviewDialog.Document = printDocument;
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.ShowDialog(this);
        }

        private void ConfigurePrinting()
        {
            printDocument.DocumentName = "ByteBetter Tutoring Report";
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.DefaultPageSettings.Margins =
                new Margins(35, 35, 45, 45);

            printDocument.BeginPrint += (_, _) =>
            {
                printRowIndex = 0;
                printPageNumber = 0;
            };

            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void PrintDocument_PrintPage(
     object? sender,
     PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = e.MarginBounds;

            using Font titleFont = new("Segoe UI", 15, FontStyle.Bold);
            using Font infoFont = new("Segoe UI", 8);
            using Font headerFont = new("Segoe UI", 7, FontStyle.Bold);
            using Font cellFont = new("Segoe UI", 7);
            using Pen gridPen = new(Color.LightGray);
            using Brush headerBrush =
                new SolidBrush(Color.FromArgb(31, 78, 121));

            List<DataGridViewColumn> columns = dgvReport.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .ToList();

            List<DataGridViewRow> rows = dgvReport.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Visible && !r.IsNewRow)
                .ToList();

            if (columns.Count == 0)
            {
                e.HasMorePages = false;
                return;
            }

            int y = bounds.Top;

            if (printPageNumber == 0)
            {
                g.DrawString(
                    currentReportTitle, titleFont, Brushes.Black,
                    bounds.Left, y);

                y += 29;

                string period = dtpStartDate.Visible
                    ? $"Period: {dtpStartDate.Value:dd MMM yyyy} - " +
                      $"{dtpEndDate.Value:dd MMM yyyy}"
                    : "Period: All available records";

                g.DrawString(period, infoFont, Brushes.Black, bounds.Left, y);
                y += 16;

                g.DrawString(
                    $"Row Filter: {activeFilterDescription}",
                    infoFont, Brushes.Black, bounds.Left, y);

                y += 23;
            }
            else
            {
                g.DrawString(
                    currentReportTitle + " (continued)",
                    titleFont, Brushes.Black, bounds.Left, y);

                y += 30;
            }

            // Calculate column widths that fit the printable page.
            float totalWidth = columns.Sum(c => (float)Math.Max(60, c.Width));
            float scale = Math.Min(1f, (float)bounds.Width / totalWidth);

            int[] widths = columns
                .Select(c => Math.Max(1, (int)(Math.Max(60, c.Width) * scale)))
                .ToArray();

            int headerHeight = 38;
            int x = bounds.Left;

            using StringFormat wrappedFormat = new()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near,
                Trimming = StringTrimming.Word
            };

            // Draw column headings.
            for (int i = 0; i < columns.Count; i++)
            {
                Rectangle cell = new(x, y, widths[i], headerHeight);

                g.FillRectangle(headerBrush, cell);
                g.DrawRectangle(gridPen, cell);

                g.DrawString(
                    FriendlyHeader(columns[i].HeaderText),
                    headerFont,
                    Brushes.White,
                    RectangleF.Inflate(cell, -2, -2),
                    wrappedFormat);

                x += widths[i];
            }

            y += headerHeight;

            // Print rows, continuing to the next page when necessary.
            while (printRowIndex < rows.Count)
            {
                DataGridViewRow row = rows[printRowIndex];

                string[] values = columns.Select(column =>
                {
                    object? value = row.Cells[column.Index].Value;

                    string text = value == null || value == DBNull.Value
                        ? ""
                        : Convert.ToString(value, CultureInfo.CurrentCulture) ?? "";

                    if (column.Name == "CompletionRate" &&
                        double.TryParse(text, out double rate))
                    {
                        text = rate.ToString("0.0") + "%";
                    }

                    return text;
                }).ToArray();

                int rowHeight = 24;

                for (int i = 0; i < values.Length; i++)
                {
                    SizeF measured = g.MeasureString(
                        values[i],
                        cellFont,
                        Math.Max(1, widths[i] - 6));

                    rowHeight = Math.Max(
                        rowHeight,
                        (int)Math.Ceiling(measured.Height) + 6);
                }

                if (y + rowHeight > bounds.Bottom)
                {
                    printPageNumber++;
                    e.HasMorePages = true;
                    return;
                }

                x = bounds.Left;

                for (int i = 0; i < columns.Count; i++)
                {
                    Rectangle cell = new(x, y, widths[i], rowHeight);

                    if (printRowIndex % 2 == 1)
                        g.FillRectangle(Brushes.AliceBlue, cell);

                    g.DrawRectangle(gridPen, cell);

                    g.DrawString(
                        values[i],
                        cellFont,
                        Brushes.Black,
                        RectangleF.Inflate(cell, -3, -3),
                        wrappedFormat);

                    x += widths[i];
                }

                y += rowHeight;
                printRowIndex++;
            }

            e.HasMorePages = false;
        }

        private static string FriendlyHeader(string header)
        {
            return header
                .Replace("_", " ")
                .Replace("SessionsScheduled", "Sessions Scheduled")
                .Replace("SessionsCompleted", "Sessions Completed")
                .Replace("CompletionRate", "Completion Rate")
                .Replace("HoursDelivered", "Hours Delivered")
                .Replace("TotalRequests", "Total Requests")
                .Replace("Course_Code", "Course Code")
                .Replace("Course_Name", "Course Name")
                .Replace("ContentClarification", "Content Clarification")
                .Replace("ExamPreparation", "Exam Preparation")
                .Replace("AssignmentAssistance", "Assignment Assistance")
                .Replace("VerifiedTutors", "Verified Tutors")
                .Replace("PendingQualifications", "Pending Qualifications");
        }

        private void frmReports_Load(object? sender, EventArgs e)
        {
        }
    }
}
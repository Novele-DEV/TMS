namespace TutoringAcademicSupport.Admin.Reports.TutorWorkloadAndCompletionRates
{
    partial class TutorWorkloadAndCompletionRatesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblPeriod = new Label();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            btnGenerate = new Button();
            lblWorkloadFlag = new Label();
            cmbWorkloadFlag = new ComboBox();
            btnClearFilters = new Button();
            lblFilter = new Label();
            pnlKpis = new FlowLayoutPanel();
            tabReport = new TabControl();
            tabTable = new TabPage();
            dgvReport = new DataGridView();
            tabChart = new TabPage();
            chartPanel = new ReportChartPanel();
            lblSummary = new Label();
            btnExport = new Button();
            btnPreview = new Button();
            btnReturn = new Button();
            tabReport.SuspendLayout();
            tabTable.SuspendLayout();
            tabChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = SystemColors.HotTrack;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(470, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tutor Workload by Period";
            //
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPeriod.ForeColor = Color.FromArgb(31, 56, 100);
            lblPeriod.Location = new Point(22, 52);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(0, 28);
            lblPeriod.TabIndex = 16;
            // 
            // lblStartDate
            //
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(24, 89);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(43, 20);
            lblStartDate.TabIndex = 1;
            lblStartDate.Text = "&From:";
            //
            // dtpStartDate
            //
            dtpStartDate.Location = new Point(75, 85);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(260, 27);
            dtpStartDate.TabIndex = 2;
            //
            // lblEndDate
            //
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(355, 89);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(28, 20);
            lblEndDate.TabIndex = 3;
            lblEndDate.Text = "T&o:";
            //
            // dtpEndDate
            //
            dtpEndDate.Location = new Point(390, 85);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(260, 27);
            dtpEndDate.TabIndex = 4;
            //
            // btnGenerate
            //
            btnGenerate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerate.Location = new Point(670, 81);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(140, 35);
            btnGenerate.TabIndex = 5;
            btnGenerate.Text = "&Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            //
            // lblWorkloadFlag
            //
            lblWorkloadFlag.AutoSize = true;
            lblWorkloadFlag.Location = new Point(24, 131);
            lblWorkloadFlag.Name = "lblWorkloadFlag";
            lblWorkloadFlag.Size = new Size(104, 20);
            lblWorkloadFlag.TabIndex = 6;
            lblWorkloadFlag.Text = "&Workload flag:";
            //
            // cmbWorkloadFlag
            //
            cmbWorkloadFlag.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWorkloadFlag.Location = new Point(135, 127);
            cmbWorkloadFlag.Name = "cmbWorkloadFlag";
            cmbWorkloadFlag.Size = new Size(200, 28);
            cmbWorkloadFlag.TabIndex = 7;
            //
            // btnClearFilters
            //
            btnClearFilters.Location = new Point(355, 123);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(140, 35);
            btnClearFilters.TabIndex = 8;
            btnClearFilters.Text = "C&lear Filters";
            btnClearFilters.UseVisualStyleBackColor = true;
            btnClearFilters.Click += btnClearFilters_Click;
            //
            // lblFilter
            //
            lblFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFilter.AutoEllipsis = true;
            lblFilter.ForeColor = SystemColors.GrayText;
            lblFilter.Location = new Point(24, 168);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(1150, 24);
            lblFilter.TabIndex = 9;
            //
            // pnlKpis
            //
            pnlKpis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlKpis.Location = new Point(24, 196);
            pnlKpis.Name = "pnlKpis";
            pnlKpis.Size = new Size(1150, 72);
            pnlKpis.TabIndex = 10;
            pnlKpis.WrapContents = false;
            //
            // dgvReport
            //
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.Location = new Point(3, 3);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 51;
            dgvReport.Size = new Size(1136, 349);
            dgvReport.TabIndex = 0;
            // 
            // tabReport
            // 
            tabReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabReport.Controls.Add(tabTable);
            tabReport.Controls.Add(tabChart);
            tabReport.Location = new Point(24, 272);
            tabReport.Name = "tabReport";
            tabReport.SelectedIndex = 0;
            tabReport.Size = new Size(1150, 388);
            tabReport.TabIndex = 11;
            // 
            // tabTable
            // 
            tabTable.Controls.Add(dgvReport);
            tabTable.Location = new Point(4, 29);
            tabTable.Name = "tabTable";
            tabTable.Padding = new Padding(3);
            tabTable.Size = new Size(1142, 355);
            tabTable.TabIndex = 0;
            tabTable.Text = "Table";
            tabTable.UseVisualStyleBackColor = true;
            // 
            // tabChart
            // 
            tabChart.Controls.Add(chartPanel);
            tabChart.Location = new Point(4, 29);
            tabChart.Name = "tabChart";
            tabChart.Padding = new Padding(3);
            tabChart.Size = new Size(1142, 355);
            tabChart.TabIndex = 1;
            tabChart.Text = "Chart";
            tabChart.UseVisualStyleBackColor = true;
            // 
            // chartPanel
            // 
            chartPanel.Dock = DockStyle.Fill;
            chartPanel.Location = new Point(3, 3);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(1136, 349);
            chartPanel.TabIndex = 0;
            //
            // lblSummary
            //
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSummary.Location = new Point(24, 670);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(0, 20);
            lblSummary.TabIndex = 12;
            //
            // btnExport
            //
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExport.Location = new Point(734, 705);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 40);
            btnExport.TabIndex = 13;
            btnExport.Text = "&Export to CSV";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            //
            // btnPreview
            //
            btnPreview.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPreview.Location = new Point(884, 705);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(140, 40);
            btnPreview.TabIndex = 14;
            btnPreview.Text = "Print Pre&view";
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Click += btnPreview_Click;
            //
            // btnReturn
            //
            btnReturn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReturn.Location = new Point(1034, 705);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(140, 40);
            btnReturn.TabIndex = 15;
            btnReturn.Text = "Re&turn";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            //
            // TutorWorkloadAndCompletionRatesForm
            //
            AcceptButton = btnGenerate;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnReturn;
            ClientSize = new Size(1200, 760);
            Controls.Add(btnReturn);
            Controls.Add(btnPreview);
            Controls.Add(btnExport);
            Controls.Add(lblSummary);
            Controls.Add(tabReport);
            Controls.Add(pnlKpis);
            Controls.Add(lblFilter);
            Controls.Add(btnClearFilters);
            Controls.Add(cmbWorkloadFlag);
            Controls.Add(lblWorkloadFlag);
            Controls.Add(btnGenerate);
            Controls.Add(dtpEndDate);
            Controls.Add(lblEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblPeriod);
            Controls.Add(lblTitle);
            MinimumSize = new Size(1050, 600);
            Name = "TutorWorkloadAndCompletionRatesForm";
            StartPosition = FormStartPosition.CenterParent;
            WindowState = FormWindowState.Maximized;
            Text = "Tutor Workload by Period";
            Load += TutorWorkloadAndCompletionRatesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            tabChart.ResumeLayout(false);
            tabTable.ResumeLayout(false);
            tabReport.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblPeriod;
        private Label lblStartDate;
        private DateTimePicker dtpStartDate;
        private Label lblEndDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerate;
        private Label lblWorkloadFlag;
        private ComboBox cmbWorkloadFlag;
        private Button btnClearFilters;
        private Label lblFilter;
        private FlowLayoutPanel pnlKpis;
        private TabControl tabReport;
        private TabPage tabTable;
        private DataGridView dgvReport;
        private TabPage tabChart;
        private ReportChartPanel chartPanel;
        private Label lblSummary;
        private Button btnExport;
        private Button btnPreview;
        private Button btnReturn;
    }
}

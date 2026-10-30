namespace TutoringAcademicSupport.Admin.Reports.CourseSupportDemandAndTutorCoverage
{
    partial class CourseSupportAndTutorCoverageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseSupportAndTutorCoverageForm));
            lblTitle = new Label();
            lblPeriod = new Label();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            btnGenerate = new Button();
            lblFaculty = new Label();
            cmbFaculty = new ComboBox();
            btnClearFilters = new Button();
            lblFilter = new Label();
            pnlKpis = new FlowLayoutPanel();
            tblReport = new TableLayoutPanel();
            dgvReport = new DataGridView();
            chartPanel = new ReportChartPanel();
            lblSummary = new Label();
            btnExport = new Button();
            btnPreview = new Button();
            btnReturn = new Button();
            tblReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Cooper Black", 20F);
            lblTitle.ForeColor = SystemColors.HotTrack;
            lblTitle.Location = new Point(22, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(974, 49);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Course Support Demand and Tutor Coverage";
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPeriod.ForeColor = Color.FromArgb(31, 56, 100);
            lblPeriod.Location = new Point(22, 52);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(0, 25);
            lblPeriod.TabIndex = 16;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.BackColor = Color.Transparent;
            lblStartDate.Location = new Point(24, 89);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(46, 20);
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
            btnGenerate.BackColor = SystemColors.ActiveCaption;
            btnGenerate.FlatStyle = FlatStyle.Popup;
            btnGenerate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerate.Location = new Point(1027, 74);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(140, 35);
            btnGenerate.TabIndex = 5;
            btnGenerate.Text = "&Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.BackColor = Color.Transparent;
            lblFaculty.Location = new Point(24, 139);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(57, 20);
            lblFaculty.TabIndex = 6;
            lblFaculty.Text = "Facult&y:";
            // 
            // cmbFaculty
            // 
            cmbFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFaculty.Location = new Point(87, 136);
            cmbFaculty.Name = "cmbFaculty";
            cmbFaculty.Size = new Size(200, 28);
            cmbFaculty.TabIndex = 7;
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = SystemColors.ButtonFace;
            btnClearFilters.FlatStyle = FlatStyle.Popup;
            btnClearFilters.Location = new Point(1027, 124);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(140, 35);
            btnClearFilters.TabIndex = 8;
            btnClearFilters.Text = "C&lear Filters";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // lblFilter
            // 
            lblFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFilter.AutoEllipsis = true;
            lblFilter.BackColor = Color.Transparent;
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
            pnlKpis.Size = new Size(1146, 72);
            pnlKpis.TabIndex = 10;
            pnlKpis.WrapContents = false;
            // 
            // tblReport
            // 
            tblReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblReport.ColumnCount = 1;
            tblReport.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblReport.Controls.Add(dgvReport, 0, 0);
            tblReport.Controls.Add(chartPanel, 0, 1);
            tblReport.Location = new Point(24, 272);
            tblReport.Name = "tblReport";
            tblReport.RowCount = 2;
            tblReport.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tblReport.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tblReport.Size = new Size(1150, 388);
            tblReport.TabIndex = 11;
            // 
            // dgvReport
            // 
            dgvReport.BackgroundColor = SystemColors.ActiveCaption;
            dgvReport.ColumnHeadersHeight = 29;
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.Location = new Point(3, 3);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 51;
            dgvReport.Size = new Size(1136, 349);
            dgvReport.TabIndex = 0;
            // 
            // chartPanel
            // 
            chartPanel.BackColor = Color.FromArgb(252, 252, 251);
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
            btnExport.BackColor = SystemColors.ActiveCaption;
            btnExport.FlatStyle = FlatStyle.Popup;
            btnExport.Location = new Point(856, 708);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 40);
            btnExport.TabIndex = 13;
            btnExport.Text = "&Export to CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnPreview
            // 
            btnPreview.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPreview.BackColor = SystemColors.InactiveCaption;
            btnPreview.FlatStyle = FlatStyle.Popup;
            btnPreview.Location = new Point(1034, 708);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(140, 40);
            btnPreview.TabIndex = 14;
            btnPreview.Text = "Print Pre&view";
            btnPreview.UseVisualStyleBackColor = false;
            btnPreview.Click += btnPreview_Click;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReturn.ForeColor = Color.FromArgb(64, 64, 64);
            btnReturn.Location = new Point(22, 708);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(85, 44);
            btnReturn.TabIndex = 15;
            btnReturn.Text = "&Back";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // CourseSupportAndTutorCoverageForm
            // 
            AcceptButton = btnGenerate;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnReturn;
            ClientSize = new Size(1200, 760);
            Controls.Add(btnReturn);
            Controls.Add(btnPreview);
            Controls.Add(btnExport);
            Controls.Add(lblSummary);
            Controls.Add(tblReport);
            Controls.Add(pnlKpis);
            Controls.Add(lblFilter);
            Controls.Add(btnClearFilters);
            Controls.Add(cmbFaculty);
            Controls.Add(lblFaculty);
            Controls.Add(btnGenerate);
            Controls.Add(dtpEndDate);
            Controls.Add(lblEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblPeriod);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            MinimumSize = new Size(1050, 760);
            Name = "CourseSupportAndTutorCoverageForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Course Support Demand and Tutor Coverage";
            WindowState = FormWindowState.Maximized;
            Load += CourseSupportAndTutorCoverageForm_Load;
            tblReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
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
        private Label lblFaculty;
        private ComboBox cmbFaculty;
        private Button btnClearFilters;
        private Label lblFilter;
        private FlowLayoutPanel pnlKpis;
        private TableLayoutPanel tblReport;
        private DataGridView dgvReport;
        private ReportChartPanel chartPanel;
        private Label lblSummary;
        private Button btnExport;
        private Button btnPreview;
        private Button btnReturn;
    }
}

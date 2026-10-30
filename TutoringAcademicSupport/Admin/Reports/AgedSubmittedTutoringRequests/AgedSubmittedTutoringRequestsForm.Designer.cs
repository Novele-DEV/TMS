namespace TutoringAcademicSupport.Admin.Reports.AgedSubmittedTutoringRequests
{
    partial class AgedSubmittedTutoringRequestsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgedSubmittedTutoringRequestsForm));
            lblTitle = new Label();
            lblPeriod = new Label();
            lblRunDate = new Label();
            dtpRunDate = new DateTimePicker();
            btnGenerate = new Button();
            lblCourse = new Label();
            cmbCourse = new ComboBox();
            lblPriority = new Label();
            cmbPriority = new ComboBox();
            lblAction = new Label();
            cmbAction = new ComboBox();
            btnClearFilters = new Button();
            lblFilter = new Label();
            pnlKpis = new FlowLayoutPanel();
            dgvReport = new DataGridView();
            lblSummary = new Label();
            btnExport = new Button();
            btnPreview = new Button();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Cooper Black", 25F);
            lblTitle.ForeColor = SystemColors.HotTrack;
            lblTitle.Location = new Point(24, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(987, 49);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Aged Submitted Tutoring Requests (7+ Days)";
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPeriod.ForeColor = Color.FromArgb(31, 56, 100);
            lblPeriod.Location = new Point(22, 52);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(0, 28);
            lblPeriod.TabIndex = 18;
            // 
            // lblRunDate
            // 
            lblRunDate.AutoSize = true;
            lblRunDate.BackColor = Color.Transparent;
            lblRunDate.Location = new Point(24, 89);
            lblRunDate.Name = "lblRunDate";
            lblRunDate.Size = new Size(71, 20);
            lblRunDate.TabIndex = 1;
            lblRunDate.Text = "&Run date:";
            // 
            // dtpRunDate
            // 
            dtpRunDate.Location = new Point(105, 85);
            dtpRunDate.Name = "dtpRunDate";
            dtpRunDate.Size = new Size(260, 27);
            dtpRunDate.TabIndex = 2;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = SystemColors.ActiveCaption;
            btnGenerate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerate.ForeColor = SystemColors.ActiveCaptionText;
            btnGenerate.Location = new Point(385, 81);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(140, 35);
            btnGenerate.TabIndex = 3;
            btnGenerate.Text = "&Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.BackColor = Color.Transparent;
            lblCourse.Location = new Point(24, 138);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(57, 20);
            lblCourse.TabIndex = 4;
            lblCourse.Text = "Co&urse:";
            // 
            // cmbCourse
            // 
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.Location = new Point(87, 130);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(300, 28);
            cmbCourse.TabIndex = 5;
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.BackColor = Color.Transparent;
            lblPriority.Location = new Point(413, 138);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(59, 20);
            lblPriority.TabIndex = 6;
            lblPriority.Text = "Pri&ority:";
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.Location = new Point(478, 131);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(140, 28);
            cmbPriority.TabIndex = 7;
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.BackColor = Color.Transparent;
            lblAction.Location = new Point(639, 139);
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(55, 20);
            lblAction.TabIndex = 8;
            lblAction.Text = "&Action:";
            // 
            // cmbAction
            // 
            cmbAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAction.Location = new Point(700, 135);
            cmbAction.Name = "cmbAction";
            cmbAction.Size = new Size(150, 28);
            cmbAction.TabIndex = 9;
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = SystemColors.ButtonFace;
            btnClearFilters.Location = new Point(1034, 132);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(140, 35);
            btnClearFilters.TabIndex = 10;
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
            lblFilter.Size = new Size(1157, 24);
            lblFilter.TabIndex = 11;
            // 
            // pnlKpis
            // 
            pnlKpis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlKpis.BackColor = Color.Transparent;
            pnlKpis.Location = new Point(24, 196);
            pnlKpis.Name = "pnlKpis";
            pnlKpis.Size = new Size(1157, 72);
            pnlKpis.TabIndex = 12;
            pnlKpis.WrapContents = false;
            // 
            // dgvReport
            // 
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.BackgroundColor = SystemColors.ActiveCaption;
            dgvReport.ColumnHeadersHeight = 29;
            dgvReport.Location = new Point(24, 272);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 51;
            dgvReport.Size = new Size(1157, 315);
            dgvReport.TabIndex = 13;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSummary.Location = new Point(24, 597);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(0, 20);
            lblSummary.TabIndex = 14;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExport.BackColor = SystemColors.ActiveCaption;
            btnExport.FlatStyle = FlatStyle.Popup;
            btnExport.Location = new Point(741, 632);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 40);
            btnExport.TabIndex = 15;
            btnExport.Text = "&Export to CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnPreview
            // 
            btnPreview.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPreview.BackColor = SystemColors.InactiveCaption;
            btnPreview.FlatStyle = FlatStyle.Popup;
            btnPreview.Location = new Point(891, 632);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(140, 40);
            btnPreview.TabIndex = 16;
            btnPreview.Text = "Print Pre&view";
            btnPreview.UseVisualStyleBackColor = false;
            btnPreview.Click += btnPreview_Click;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReturn.ForeColor = Color.FromArgb(64, 64, 64);
            btnReturn.Location = new Point(1041, 632);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(140, 40);
            btnReturn.TabIndex = 17;
            btnReturn.Text = "&Back";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // AgedSubmittedTutoringRequestsForm
            // 
            AcceptButton = btnGenerate;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnReturn;
            ClientSize = new Size(1207, 687);
            Controls.Add(btnReturn);
            Controls.Add(btnPreview);
            Controls.Add(btnExport);
            Controls.Add(lblSummary);
            Controls.Add(dgvReport);
            Controls.Add(pnlKpis);
            Controls.Add(lblFilter);
            Controls.Add(btnClearFilters);
            Controls.Add(cmbAction);
            Controls.Add(lblAction);
            Controls.Add(cmbPriority);
            Controls.Add(lblPriority);
            Controls.Add(cmbCourse);
            Controls.Add(lblCourse);
            Controls.Add(btnGenerate);
            Controls.Add(dtpRunDate);
            Controls.Add(lblRunDate);
            Controls.Add(lblPeriod);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            MinimumSize = new Size(465, 388);
            Name = "AgedSubmittedTutoringRequestsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Aged Submitted Tutoring Requests";
            WindowState = FormWindowState.Maximized;
            Load += AgedSubmittedTutoringRequestsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblPeriod;
        private Label lblRunDate;
        private DateTimePicker dtpRunDate;
        private Button btnGenerate;
        private Label lblCourse;
        private ComboBox cmbCourse;
        private Label lblPriority;
        private ComboBox cmbPriority;
        private Label lblAction;
        private ComboBox cmbAction;
        private Button btnClearFilters;
        private Label lblFilter;
        private FlowLayoutPanel pnlKpis;
        private DataGridView dgvReport;
        private Label lblSummary;
        private Button btnExport;
        private Button btnPreview;
        private Button btnReturn;
    }
}

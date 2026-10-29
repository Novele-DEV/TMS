namespace TutoringAcademicSupport.Admin.Dashboard
{
    partial class AdminForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            lblWelcome = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblCount = new Label();
            tutorDataGridView = new DataGridView();
            tutorBindingSource = new BindingSource(components);
            lblStatus = new Label();
            btnAddTutor = new Button();
            btnEdit = new Button();
            btnUpdateAvailability = new Button();
            btnGenerateReports = new Button();
            btnLogOut = new Button();
            ((System.ComponentModel.ISupportInitialize)tutorDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).BeginInit();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(24, 15);
            label1.Name = "label1";
            label1.Size = new Size(273, 41);
            label1.TabIndex = 0;
            label1.Text = "Admin Dashboard";
            //
            // lblWelcome
            //
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 11F);
            lblWelcome.Location = new Point(28, 60);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(80, 25);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome";
            //
            // lblSearch
            //
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(28, 103);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(105, 20);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "&Search tutors:";
            //
            // txtSearch
            //
            txtSearch.Location = new Point(140, 99);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Name, tutor ID or email";
            txtSearch.Size = new Size(320, 27);
            txtSearch.TabIndex = 3;
            txtSearch.TextChanged += txtSearch_TextChanged;
            //
            // lblCount
            //
            lblCount.AutoSize = true;
            lblCount.ForeColor = SystemColors.GrayText;
            lblCount.Location = new Point(480, 103);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 20);
            lblCount.TabIndex = 4;
            //
            // tutorDataGridView
            //
            tutorDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tutorDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tutorDataGridView.DataSource = tutorBindingSource;
            tutorDataGridView.Location = new Point(28, 138);
            tutorDataGridView.Name = "tutorDataGridView";
            tutorDataGridView.RowHeadersWidth = 51;
            tutorDataGridView.Size = new Size(944, 392);
            tutorDataGridView.TabIndex = 5;
            tutorDataGridView.CellDoubleClick += tutorDataGridView_CellDoubleClick;
            tutorDataGridView.SelectionChanged += tutorDataGridView_SelectionChanged;
            //
            // lblStatus
            //
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(28, 540);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 6;
            //
            // btnAddTutor
            //
            btnAddTutor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddTutor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddTutor.Location = new Point(28, 572);
            btnAddTutor.Name = "btnAddTutor";
            btnAddTutor.Size = new Size(160, 48);
            btnAddTutor.TabIndex = 7;
            btnAddTutor.Text = "&Add Tutor";
            btnAddTutor.UseVisualStyleBackColor = true;
            btnAddTutor.Click += btnAddTutor_Click;
            //
            // btnEdit
            //
            btnEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEdit.Location = new Point(198, 572);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(160, 48);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "&Edit Selected";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            //
            // btnUpdateAvailability
            //
            btnUpdateAvailability.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdateAvailability.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateAvailability.Location = new Point(368, 572);
            btnUpdateAvailability.Name = "btnUpdateAvailability";
            btnUpdateAvailability.Size = new Size(200, 48);
            btnUpdateAvailability.TabIndex = 9;
            btnUpdateAvailability.Text = "Tutor A&vailability";
            btnUpdateAvailability.UseVisualStyleBackColor = true;
            btnUpdateAvailability.Click += btnUpdateAvailability_Click;
            //
            // btnGenerateReports
            //
            btnGenerateReports.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGenerateReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerateReports.Location = new Point(578, 572);
            btnGenerateReports.Name = "btnGenerateReports";
            btnGenerateReports.Size = new Size(200, 48);
            btnGenerateReports.TabIndex = 10;
            btnGenerateReports.Text = "&Generate Reports";
            btnGenerateReports.UseVisualStyleBackColor = true;
            btnGenerateReports.Click += btnGenerateReports_Click;
            //
            // btnLogOut
            //
            btnLogOut.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogOut.Location = new Point(812, 572);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(160, 48);
            btnLogOut.TabIndex = 11;
            btnLogOut.Text = "&Log Out";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            //
            // AdminForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 640);
            Controls.Add(btnLogOut);
            Controls.Add(btnGenerateReports);
            Controls.Add(btnUpdateAvailability);
            Controls.Add(btnEdit);
            Controls.Add(btnAddTutor);
            Controls.Add(lblStatus);
            Controls.Add(tutorDataGridView);
            Controls.Add(lblCount);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblWelcome);
            Controls.Add(label1);
            MinimumSize = new Size(1018, 520);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)tutorDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblWelcome;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblCount;
        private DataGridView tutorDataGridView;
        private BindingSource tutorBindingSource;
        private Label lblStatus;
        private Button btnAddTutor;
        private Button btnEdit;
        private Button btnUpdateAvailability;
        private Button btnGenerateReports;
        private Button btnLogOut;
    }
}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
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
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cooper Black", 25F);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(28, 9);
            label1.Name = "label1";
            label1.Size = new Size(411, 49);
            label1.TabIndex = 0;
            label1.Text = "Admin Dashboard";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(28, 58);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(85, 25);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BackColor = Color.Transparent;
            lblSearch.Location = new Point(28, 102);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(98, 20);
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
            tutorDataGridView.AutoGenerateColumns = false;
            tutorDataGridView.BackgroundColor = SystemColors.ActiveCaption;
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
            btnAddTutor.BackColor = SystemColors.ActiveCaption;
            btnAddTutor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddTutor.Location = new Point(28, 572);
            btnAddTutor.Name = "btnAddTutor";
            btnAddTutor.Size = new Size(147, 48);
            btnAddTutor.TabIndex = 7;
            btnAddTutor.Text = "&Add Tutor";
            btnAddTutor.UseVisualStyleBackColor = false;
            btnAddTutor.Click += btnAddTutor_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEdit.BackColor = SystemColors.InactiveCaption;
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEdit.Location = new Point(181, 572);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(146, 48);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "&Edit Selected";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnUpdateAvailability
            // 
            btnUpdateAvailability.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdateAvailability.BackColor = SystemColors.GradientActiveCaption;
            btnUpdateAvailability.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateAvailability.Location = new Point(333, 572);
            btnUpdateAvailability.Name = "btnUpdateAvailability";
            btnUpdateAvailability.Size = new Size(201, 48);
            btnUpdateAvailability.TabIndex = 9;
            btnUpdateAvailability.Text = "Tutor A&vailability";
            btnUpdateAvailability.UseVisualStyleBackColor = false;
            btnUpdateAvailability.Click += btnUpdateAvailability_Click;
            // 
            // btnGenerateReports
            // 
            btnGenerateReports.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGenerateReports.BackColor = SystemColors.GradientInactiveCaption;
            btnGenerateReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerateReports.Location = new Point(540, 572);
            btnGenerateReports.Name = "btnGenerateReports";
            btnGenerateReports.Size = new Size(200, 48);
            btnGenerateReports.TabIndex = 10;
            btnGenerateReports.Text = "&Generate Reports";
            btnGenerateReports.UseVisualStyleBackColor = false;
            btnGenerateReports.Click += btnGenerateReports_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogOut.ForeColor = Color.FromArgb(64, 64, 64);
            btnLogOut.Location = new Point(867, 572);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(105, 48);
            btnLogOut.TabIndex = 11;
            btnLogOut.Text = "&Log Out";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
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
            DoubleBuffered = true;
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
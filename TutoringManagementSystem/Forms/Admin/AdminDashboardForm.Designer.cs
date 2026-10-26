namespace Tutoring_Management_System
{
    partial class AdminDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            studentPanel = new Panel();
            lblSelectStudent = new Label();
            cboStudent = new ComboBox();
            btnBookTutorial = new Button();
            btnUpdateBooking = new Button();
            btnCancelBooking = new Button();
            adminPanel = new Panel();
            btnManageTutors = new Button();
            btnGetReport = new Button();
            lblStudentHeading = new Label();
            lblAdminHeading = new Label();
            picLogo = new PictureBox();
            lblTagline = new Label();
            label1 = new Label();
            btnLogOut = new Button();
            btnToggleTheme = new Button();
            brandStrip = new Panel();
            studentPanel.SuspendLayout();
            adminPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            //
            // studentPanel
            //
            studentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            studentPanel.BackColor = Color.FromArgb(238, 243, 251);
            studentPanel.Controls.Add(lblSelectStudent);
            studentPanel.Controls.Add(cboStudent);
            studentPanel.Controls.Add(btnBookTutorial);
            studentPanel.Controls.Add(btnUpdateBooking);
            studentPanel.Controls.Add(btnCancelBooking);
            studentPanel.Controls.Add(lblStudentHeading);
            studentPanel.Location = new Point(34, 262);
            studentPanel.Name = "studentPanel";
            studentPanel.Padding = new Padding(16);
            studentPanel.Size = new Size(336, 280);
            studentPanel.TabIndex = 0;
            studentPanel.Paint += studentPanel_Paint;
            //
            // lblSelectStudent
            //
            lblSelectStudent.AutoSize = true;
            lblSelectStudent.ForeColor = Color.FromArgb(0, 56, 152);
            lblSelectStudent.Location = new Point(28, 48);
            lblSelectStudent.Name = "lblSelectStudent";
            lblSelectStudent.Size = new Size(105, 19);
            lblSelectStudent.TabIndex = 1;
            lblSelectStudent.Text = "Select student *";
            //
            // cboStudent
            //
            cboStudent.BackColor = Color.White;
            cboStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStudent.FlatStyle = FlatStyle.Flat;
            cboStudent.FormattingEnabled = true;
            cboStudent.Location = new Point(28, 72);
            cboStudent.Name = "cboStudent";
            cboStudent.Size = new Size(280, 25);
            cboStudent.TabIndex = 2;
            cboStudent.Enter += cboStudent_FocusChanged;
            cboStudent.Leave += cboStudent_FocusChanged;
            //
            // btnBookTutorial
            //
            btnBookTutorial.BackColor = Color.FromArgb(0, 56, 152);
            btnBookTutorial.Cursor = Cursors.Hand;
            btnBookTutorial.FlatAppearance.BorderSize = 0;
            btnBookTutorial.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 42, 112);
            btnBookTutorial.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 42, 112);
            btnBookTutorial.FlatStyle = FlatStyle.Flat;
            btnBookTutorial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBookTutorial.ForeColor = Color.White;
            btnBookTutorial.Location = new Point(28, 115);
            btnBookTutorial.Name = "btnBookTutorial";
            btnBookTutorial.Size = new Size(280, 40);
            btnBookTutorial.TabIndex = 3;
            btnBookTutorial.Text = "Book Tutorial";
            btnBookTutorial.UseVisualStyleBackColor = false;
            btnBookTutorial.Click += btnBookTutorial_Click;
            //
            // btnUpdateBooking
            //
            btnUpdateBooking.BackColor = Color.FromArgb(0, 56, 152);
            btnUpdateBooking.Cursor = Cursors.Hand;
            btnUpdateBooking.FlatAppearance.BorderSize = 0;
            btnUpdateBooking.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 42, 112);
            btnUpdateBooking.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 42, 112);
            btnUpdateBooking.FlatStyle = FlatStyle.Flat;
            btnUpdateBooking.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateBooking.ForeColor = Color.White;
            btnUpdateBooking.Location = new Point(28, 166);
            btnUpdateBooking.Name = "btnUpdateBooking";
            btnUpdateBooking.Size = new Size(280, 40);
            btnUpdateBooking.TabIndex = 4;
            btnUpdateBooking.Text = "Update Booking";
            btnUpdateBooking.UseVisualStyleBackColor = false;
            btnUpdateBooking.Click += btnUpdateBooking_Click;
            //
            // btnCancelBooking
            //
            btnCancelBooking.BackColor = Color.FromArgb(0, 56, 152);
            btnCancelBooking.Cursor = Cursors.Hand;
            btnCancelBooking.FlatAppearance.BorderSize = 0;
            btnCancelBooking.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 42, 112);
            btnCancelBooking.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 42, 112);
            btnCancelBooking.FlatStyle = FlatStyle.Flat;
            btnCancelBooking.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelBooking.ForeColor = Color.White;
            btnCancelBooking.Location = new Point(28, 217);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(280, 40);
            btnCancelBooking.TabIndex = 5;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = false;
            btnCancelBooking.Click += btnCancelBooking_Click;
            //
            // adminPanel
            //
            adminPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            adminPanel.BackColor = Color.FromArgb(238, 243, 251);
            adminPanel.Controls.Add(btnManageTutors);
            adminPanel.Controls.Add(btnGetReport);
            adminPanel.Controls.Add(lblAdminHeading);
            adminPanel.Location = new Point(390, 262);
            adminPanel.Name = "adminPanel";
            adminPanel.Padding = new Padding(16);
            adminPanel.Size = new Size(336, 280);
            adminPanel.TabIndex = 1;
            //
            // btnManageTutors
            //
            btnManageTutors.BackColor = Color.FromArgb(0, 56, 152);
            btnManageTutors.Cursor = Cursors.Hand;
            btnManageTutors.FlatAppearance.BorderSize = 0;
            btnManageTutors.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 42, 112);
            btnManageTutors.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 42, 112);
            btnManageTutors.FlatStyle = FlatStyle.Flat;
            btnManageTutors.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnManageTutors.ForeColor = Color.White;
            btnManageTutors.Location = new Point(28, 115);
            btnManageTutors.Name = "btnManageTutors";
            btnManageTutors.Size = new Size(280, 40);
            btnManageTutors.TabIndex = 0;
            btnManageTutors.Text = "Manage Tutors";
            btnManageTutors.UseVisualStyleBackColor = false;
            btnManageTutors.Click += btnManageTutors_Click;
            //
            // btnGetReport
            //
            btnGetReport.BackColor = Color.FromArgb(0, 56, 152);
            btnGetReport.Cursor = Cursors.Hand;
            btnGetReport.FlatAppearance.BorderSize = 0;
            btnGetReport.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 42, 112);
            btnGetReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 42, 112);
            btnGetReport.FlatStyle = FlatStyle.Flat;
            btnGetReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGetReport.ForeColor = Color.White;
            btnGetReport.Location = new Point(28, 166);
            btnGetReport.Name = "btnGetReport";
            btnGetReport.Size = new Size(280, 40);
            btnGetReport.TabIndex = 1;
            btnGetReport.Text = "Get Report";
            btnGetReport.UseVisualStyleBackColor = false;
            btnGetReport.Click += btnGetReport_Click;
            //
            // lblStudentHeading
            //
            lblStudentHeading.AutoSize = true;
            lblStudentHeading.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStudentHeading.ForeColor = Color.FromArgb(0, 56, 152);
            lblStudentHeading.Location = new Point(28, 17);
            lblStudentHeading.Name = "lblStudentHeading";
            lblStudentHeading.Size = new Size(62, 19);
            lblStudentHeading.TabIndex = 0;
            lblStudentHeading.Text = "Student";
            //
            // lblAdminHeading
            //
            lblAdminHeading.AutoSize = true;
            lblAdminHeading.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdminHeading.ForeColor = Color.FromArgb(0, 56, 152);
            lblAdminHeading.Location = new Point(28, 17);
            lblAdminHeading.Name = "lblAdminHeading";
            lblAdminHeading.Size = new Size(49, 19);
            lblAdminHeading.TabIndex = 2;
            lblAdminHeading.Text = "Admin";
            //
            // picLogo
            //
            picLogo.Anchor = AnchorStyles.Top;
            picLogo.Image = (Image)(resources.GetObject("LogoLight") ?? throw new InvalidOperationException("The light-mode logo resource is missing."));
            picLogo.Location = new Point(270, 14);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(220, 160);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 2;
            picLogo.TabStop = false;
            //
            // lblTagline
            //
            lblTagline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTagline.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblTagline.ForeColor = Color.FromArgb(0, 56, 152);
            lblTagline.Location = new Point(0, 174);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(760, 26);
            lblTagline.TabIndex = 3;
            lblTagline.Text = "Smarter Learning, Brighter Futures";
            lblTagline.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label1
            //
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 56, 152);
            label1.Location = new Point(0, 207);
            label1.Name = "label1";
            label1.Size = new Size(760, 40);
            label1.TabIndex = 4;
            label1.Text = "Tutoring System";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnLogOut
            //
            btnLogOut.Anchor = AnchorStyles.Bottom;
            btnLogOut.BackColor = Color.White;
            btnLogOut.Cursor = Cursors.Hand;
            btnLogOut.FlatAppearance.BorderColor = Color.FromArgb(0, 56, 152);
            btnLogOut.FlatAppearance.BorderSize = 1;
            btnLogOut.FlatAppearance.MouseDownBackColor = Color.FromArgb(238, 243, 251);
            btnLogOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(238, 243, 251);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogOut.ForeColor = Color.FromArgb(0, 56, 152);
            btnLogOut.Location = new Point(310, 560);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(140, 40);
            btnLogOut.TabIndex = 5;
            btnLogOut.Text = "Logout";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            //
            // btnToggleTheme
            //
            btnToggleTheme.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnToggleTheme.BackColor = Color.FromArgb(0, 56, 152);
            btnToggleTheme.Cursor = Cursors.Hand;
            btnToggleTheme.FlatAppearance.BorderSize = 0;
            btnToggleTheme.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 42, 112);
            btnToggleTheme.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 42, 112);
            btnToggleTheme.FlatStyle = FlatStyle.Flat;
            btnToggleTheme.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnToggleTheme.ForeColor = Color.White;
            btnToggleTheme.Location = new Point(34, 560);
            btnToggleTheme.Name = "btnToggleTheme";
            btnToggleTheme.Size = new Size(180, 40);
            btnToggleTheme.TabIndex = 6;
            btnToggleTheme.Text = "Switch to dark mode";
            btnToggleTheme.UseVisualStyleBackColor = false;
            btnToggleTheme.Click += btnToggleTheme_Click;
            //
            // brandStrip
            //
            brandStrip.BackColor = Color.FromArgb(0, 56, 152);
            brandStrip.Dock = DockStyle.Top;
            brandStrip.Location = new Point(0, 0);
            brandStrip.Name = "brandStrip";
            brandStrip.Size = new Size(760, 4);
            brandStrip.TabIndex = 6;
            //
            // AdminDashboardForm
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(760, 620);
            Controls.Add(brandStrip);
            Controls.Add(btnLogOut);
            Controls.Add(btnToggleTheme);
            Controls.Add(label1);
            Controls.Add(lblTagline);
            Controls.Add(picLogo);
            Controls.Add(adminPanel);
            Controls.Add(studentPanel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tutoring System - Main Menu";
            Load += AdminDashboardForm_Load;
            studentPanel.ResumeLayout(false);
            studentPanel.PerformLayout();
            adminPanel.ResumeLayout(false);
            adminPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel studentPanel;
        private System.Windows.Forms.Label lblSelectStudent;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Button btnBookTutorial;
        private System.Windows.Forms.Button btnUpdateBooking;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Panel adminPanel;
        private System.Windows.Forms.Button btnManageTutors;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.Label lblStudentHeading;
        private System.Windows.Forms.Label lblAdminHeading;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnToggleTheme;
        private System.Windows.Forms.Panel brandStrip;
    }
}

namespace TutoringAcademicSupport.Student.Dashboard
{
    partial class StudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            tblLayout = new TableLayoutPanel();
            picLogo = new PictureBox();
            lblTitle = new Label();
            lblLoggedInAs = new Label();
            lblPrompt = new Label();
            tblOptions = new TableLayoutPanel();
            btnViewAvailability = new Button();
            btnBookSession = new Button();
            btnUpdateBooking = new Button();
            btnCancelBooking = new Button();
            btnLogOut = new Button();
            tblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tblOptions.SuspendLayout();
            SuspendLayout();
            // 
            // tblLayout
            // 
            tblLayout.BackColor = Color.White;
            tblLayout.BackgroundImage = (Image)resources.GetObject("tblLayout.BackgroundImage");
            tblLayout.BackgroundImageLayout = ImageLayout.Stretch;
            tblLayout.ColumnCount = 1;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblLayout.Controls.Add(picLogo, 0, 1);
            tblLayout.Controls.Add(lblTitle, 0, 2);
            tblLayout.Controls.Add(lblLoggedInAs, 0, 3);
            tblLayout.Controls.Add(lblPrompt, 0, 5);
            tblLayout.Controls.Add(tblOptions, 0, 6);
            tblLayout.Controls.Add(btnLogOut, 0, 8);
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.Location = new Point(0, 0);
            tblLayout.Name = "tblLayout";
            tblLayout.RowCount = 9;
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 61F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblLayout.Size = new Size(760, 580);
            tblLayout.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.AccessibleName = "Byte Better logo";
            picLogo.Anchor = AnchorStyles.None;
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(307, 26);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(146, 90);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Cooper Black", 25F);
            lblTitle.ForeColor = SystemColors.HotTrack;
            lblTitle.Location = new Point(0, 116);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(760, 61);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Student Menu";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLoggedInAs
            // 
            lblLoggedInAs.BackColor = Color.Transparent;
            lblLoggedInAs.Dock = DockStyle.Fill;
            lblLoggedInAs.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblLoggedInAs.ForeColor = Color.FromArgb(96, 96, 96);
            lblLoggedInAs.Location = new Point(0, 177);
            lblLoggedInAs.Margin = new Padding(0);
            lblLoggedInAs.Name = "lblLoggedInAs";
            lblLoggedInAs.Size = new Size(760, 39);
            lblLoggedInAs.TabIndex = 2;
            lblLoggedInAs.Text = "Welcome";
            lblLoggedInAs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrompt
            // 
            lblPrompt.BackColor = Color.Transparent;
            lblPrompt.Dock = DockStyle.Fill;
            lblPrompt.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrompt.ForeColor = Color.FromArgb(31, 56, 100);
            lblPrompt.Location = new Point(0, 224);
            lblPrompt.Margin = new Padding(0);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(760, 60);
            lblPrompt.TabIndex = 3;
            lblPrompt.Text = "What would you like to do?";
            lblPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblOptions
            // 
            tblOptions.Anchor = AnchorStyles.None;
            tblOptions.BackColor = Color.Transparent;
            tblOptions.ColumnCount = 3;
            tblOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270F));
            tblOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270F));
            tblOptions.Controls.Add(btnViewAvailability, 0, 0);
            tblOptions.Controls.Add(btnBookSession, 2, 0);
            tblOptions.Controls.Add(btnUpdateBooking, 0, 2);
            tblOptions.Controls.Add(btnCancelBooking, 2, 2);
            tblOptions.Location = new Point(100, 291);
            tblOptions.Margin = new Padding(0);
            tblOptions.Name = "tblOptions";
            tblOptions.RowCount = 3;
            tblOptions.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tblOptions.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblOptions.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tblOptions.Size = new Size(560, 196);
            tblOptions.TabIndex = 4;
            // 
            // btnViewAvailability
            // 
            btnViewAvailability.BackColor = SystemColors.HotTrack;
            btnViewAvailability.Cursor = Cursors.Hand;
            btnViewAvailability.Dock = DockStyle.Fill;
            btnViewAvailability.FlatAppearance.BorderSize = 0;
            btnViewAvailability.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnViewAvailability.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnViewAvailability.FlatStyle = FlatStyle.Flat;
            btnViewAvailability.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnViewAvailability.ForeColor = Color.White;
            btnViewAvailability.Location = new Point(0, 0);
            btnViewAvailability.Margin = new Padding(0);
            btnViewAvailability.Name = "btnViewAvailability";
            btnViewAvailability.Size = new Size(270, 88);
            btnViewAvailability.TabIndex = 0;
            btnViewAvailability.Text = "&View Tutor Availability";
            btnViewAvailability.UseVisualStyleBackColor = false;
            btnViewAvailability.Click += btnViewAvailability_Click;
            // 
            // btnBookSession
            // 
            btnBookSession.BackColor = SystemColors.HotTrack;
            btnBookSession.Cursor = Cursors.Hand;
            btnBookSession.Dock = DockStyle.Fill;
            btnBookSession.FlatAppearance.BorderSize = 0;
            btnBookSession.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnBookSession.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnBookSession.FlatStyle = FlatStyle.Flat;
            btnBookSession.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnBookSession.ForeColor = Color.White;
            btnBookSession.Location = new Point(290, 0);
            btnBookSession.Margin = new Padding(0);
            btnBookSession.Name = "btnBookSession";
            btnBookSession.Size = new Size(270, 88);
            btnBookSession.TabIndex = 1;
            btnBookSession.Text = "&Book a Tutorial Session";
            btnBookSession.UseVisualStyleBackColor = false;
            btnBookSession.Click += btnBookSession_Click;
            // 
            // btnUpdateBooking
            // 
            btnUpdateBooking.BackColor = SystemColors.HotTrack;
            btnUpdateBooking.Cursor = Cursors.Hand;
            btnUpdateBooking.Dock = DockStyle.Fill;
            btnUpdateBooking.FlatAppearance.BorderSize = 0;
            btnUpdateBooking.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnUpdateBooking.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnUpdateBooking.FlatStyle = FlatStyle.Flat;
            btnUpdateBooking.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnUpdateBooking.ForeColor = Color.White;
            btnUpdateBooking.Location = new Point(0, 108);
            btnUpdateBooking.Margin = new Padding(0);
            btnUpdateBooking.Name = "btnUpdateBooking";
            btnUpdateBooking.Size = new Size(270, 88);
            btnUpdateBooking.TabIndex = 2;
            btnUpdateBooking.Text = "&Update a Booking";
            btnUpdateBooking.UseVisualStyleBackColor = false;
            btnUpdateBooking.Click += btnUpdateBooking_Click;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.BackColor = SystemColors.HotTrack;
            btnCancelBooking.Cursor = Cursors.Hand;
            btnCancelBooking.Dock = DockStyle.Fill;
            btnCancelBooking.FlatAppearance.BorderSize = 0;
            btnCancelBooking.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnCancelBooking.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnCancelBooking.FlatStyle = FlatStyle.Flat;
            btnCancelBooking.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnCancelBooking.ForeColor = Color.White;
            btnCancelBooking.Location = new Point(290, 108);
            btnCancelBooking.Margin = new Padding(0);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(270, 88);
            btnCancelBooking.TabIndex = 3;
            btnCancelBooking.Text = "&Cancel a Booking";
            btnCancelBooking.UseVisualStyleBackColor = false;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.Anchor = AnchorStyles.Right;
            btnLogOut.BackColor = Color.White;
            btnLogOut.Cursor = Cursors.Hand;
            btnLogOut.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnLogOut.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 228, 235);
            btnLogOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 242, 246);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.ForeColor = Color.FromArgb(64, 64, 64);
            btnLogOut.Location = new Point(596, 528);
            btnLogOut.Margin = new Padding(0, 0, 24, 0);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(140, 44);
            btnLogOut.TabIndex = 5;
            btnLogOut.Text = "&Log Out";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 580);
            Controls.Add(tblLayout);
            MinimumSize = new Size(700, 600);
            Name = "StudentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Menu";
            tblLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tblOptions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblLayout;
        private PictureBox picLogo;
        private Label lblTitle;
        private Label lblLoggedInAs;
        private Label lblPrompt;
        private TableLayoutPanel tblOptions;
        private Button btnViewAvailability;
        private Button btnBookSession;
        private Button btnUpdateBooking;
        private Button btnCancelBooking;
        private Button btnLogOut;
    }
}

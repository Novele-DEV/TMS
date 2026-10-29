namespace TutoringAcademicSupport.Student.BookSession
{
    partial class BookSessionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblTutor;
        private System.Windows.Forms.Label lblSessionDate;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblMessage;

        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.ComboBox cmbTutor;
        private System.Windows.Forms.DateTimePicker dtpSessionDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.ComboBox cmbMode;

        private System.Windows.Forms.Button btnBookTutorial;
        private System.Windows.Forms.Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblStudentID = new Label();
            lblTutor = new Label();
            lblSessionDate = new Label();
            lblStartTime = new Label();
            lblEndTime = new Label();
            lblMode = new Label();
            lblMessage = new Label();
            txtStudentID = new TextBox();
            cmbTutor = new ComboBox();
            dtpSessionDate = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            cmbMode = new ComboBox();
            btnBookTutorial = new Button();
            btnClear = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(35, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(344, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Book a Tutorial Session";
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Location = new Point(40, 85);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(82, 20);
            lblStudentID.TabIndex = 1;
            lblStudentID.Text = "Student ID:";
            // 
            // lblTutor
            // 
            lblTutor.AutoSize = true;
            lblTutor.Location = new Point(40, 130);
            lblTutor.Name = "lblTutor";
            lblTutor.Size = new Size(47, 20);
            lblTutor.TabIndex = 3;
            lblTutor.Text = "Tutor:";
            // 
            // lblSessionDate
            // 
            lblSessionDate.AutoSize = true;
            lblSessionDate.Location = new Point(40, 175);
            lblSessionDate.Name = "lblSessionDate";
            lblSessionDate.Size = new Size(95, 20);
            lblSessionDate.TabIndex = 5;
            lblSessionDate.Text = "Session date:";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(40, 220);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(77, 20);
            lblStartTime.TabIndex = 7;
            lblStartTime.Text = "Start time:";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(40, 265);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(71, 20);
            lblEndTime.TabIndex = 9;
            lblEndTime.Text = "End time:";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(40, 310);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(51, 20);
            lblMode.TabIndex = 11;
            lblMode.Text = "Mode:";
            // 
            // lblMessage
            // 
            lblMessage.Location = new Point(40, 415);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(440, 50);
            lblMessage.TabIndex = 15;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(180, 80);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(220, 27);
            txtStudentID.TabIndex = 2;
            // 
            // cmbTutor
            // 
            cmbTutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTutor.Location = new Point(180, 125);
            cmbTutor.Name = "cmbTutor";
            cmbTutor.Size = new Size(220, 28);
            cmbTutor.TabIndex = 4;
            // 
            // dtpSessionDate
            // 
            dtpSessionDate.Format = DateTimePickerFormat.Short;
            dtpSessionDate.Location = new Point(180, 170);
            dtpSessionDate.MinDate = new DateTime(2026, 10, 29, 0, 0, 0, 0);
            dtpSessionDate.Name = "dtpSessionDate";
            dtpSessionDate.Size = new Size(220, 27);
            dtpSessionDate.TabIndex = 6;
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(180, 215);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(220, 27);
            dtpStartTime.TabIndex = 8;
            dtpStartTime.Value = new DateTime(2026, 10, 29, 9, 0, 0, 0);
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(180, 260);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(220, 27);
            dtpEndTime.TabIndex = 10;
            dtpEndTime.Value = new DateTime(2026, 10, 29, 10, 0, 0, 0);
            // 
            // cmbMode
            // 
            cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMode.Items.AddRange(new object[] { "In-person", "Virtual" });
            cmbMode.Location = new Point(180, 305);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new Size(220, 28);
            cmbMode.TabIndex = 12;
            // 
            // btnBookTutorial
            // 
            btnBookTutorial.Location = new Point(180, 360);
            btnBookTutorial.Name = "btnBookTutorial";
            btnBookTutorial.Size = new Size(130, 35);
            btnBookTutorial.TabIndex = 13;
            btnBookTutorial.Text = "Book Session";
            btnBookTutorial.Click += btnBookTutorial_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(320, 360);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 35);
            btnClear.TabIndex = 14;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // BookSessionForm
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(520, 490);
            Controls.Add(lblTitle);
            Controls.Add(lblStudentID);
            Controls.Add(txtStudentID);
            Controls.Add(lblTutor);
            Controls.Add(cmbTutor);
            Controls.Add(lblSessionDate);
            Controls.Add(dtpSessionDate);
            Controls.Add(lblStartTime);
            Controls.Add(dtpStartTime);
            Controls.Add(lblEndTime);
            Controls.Add(dtpEndTime);
            Controls.Add(lblMode);
            Controls.Add(cmbMode);
            Controls.Add(btnBookTutorial);
            Controls.Add(btnClear);
            Controls.Add(lblMessage);
            Name = "BookSessionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book a Tutorial Session";
            Load += BookSessionForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
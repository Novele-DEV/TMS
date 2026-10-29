namespace TutoringAcademicSupport.Student.UpdateBooking
{
    partial class UpdateBookingForm
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
            label7 = new Label();
            label6 = new Label();
            txtSession = new TextBox();
            btnFindSession = new Button();
            btnUpdateSession = new Button();
            btnClose = new Button();
            cmbMode = new ComboBox();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            dtpSession = new DateTimePicker();
            txtStudentID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(252, 15);
            label7.Name = "label7";
            label7.Size = new Size(283, 28);
            label7.TabIndex = 32;
            label7.Text = "UPDATE TUTORING SESSION";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(547, 205);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 31;
            label6.Text = "Mode";
            // 
            // txtSession
            // 
            txtSession.Location = new Point(175, 140);
            txtSession.Name = "txtSession";
            txtSession.Size = new Size(250, 27);
            txtSession.TabIndex = 30;
            // 
            // btnFindSession
            // 
            btnFindSession.Location = new Point(16, 407);
            btnFindSession.Name = "btnFindSession";
            btnFindSession.Size = new Size(94, 29);
            btnFindSession.TabIndex = 29;
            btnFindSession.Text = "Find";
            btnFindSession.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSession
            // 
            btnUpdateSession.BackColor = Color.Azure;
            btnUpdateSession.Location = new Point(145, 407);
            btnUpdateSession.Name = "btnUpdateSession";
            btnUpdateSession.Size = new Size(94, 29);
            btnUpdateSession.TabIndex = 28;
            btnUpdateSession.Text = "Update";
            btnUpdateSession.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(287, 407);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 27;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // cmbMode
            // 
            cmbMode.FormattingEnabled = true;
            cmbMode.Location = new Point(634, 202);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new Size(151, 28);
            cmbMode.TabIndex = 26;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(175, 305);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(250, 27);
            dtpEndTime.TabIndex = 25;
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(175, 252);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(250, 27);
            dtpStartTime.TabIndex = 24;
            // 
            // dtpSession
            // 
            dtpSession.Location = new Point(175, 205);
            dtpSession.Name = "dtpSession";
            dtpSession.Size = new Size(250, 27);
            dtpSession.TabIndex = 23;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(175, 77);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(250, 27);
            txtStudentID.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 310);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 21;
            label5.Text = "End Time";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 257);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 20;
            label4.Text = "Start Time";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 210);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 19;
            label3.Tag = "Session Date";
            label3.Text = "Session Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 143);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 18;
            label2.Text = "Session ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 84);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 17;
            label1.Text = "Student ID";
            // 
            // UpdateBookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtSession);
            Controls.Add(btnFindSession);
            Controls.Add(btnUpdateSession);
            Controls.Add(btnClose);
            Controls.Add(cmbMode);
            Controls.Add(dtpEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(dtpSession);
            Controls.Add(txtStudentID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateBookingForm";
            Text = "UpdateBookingForm";
            Load += UpdateBookingForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label6;
        private TextBox txtSession;
        private Button btnFindSession;
        private Button btnUpdateSession;
        private Button btnClose;
        private ComboBox cmbMode;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpSession;
        private TextBox txtStudentID;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
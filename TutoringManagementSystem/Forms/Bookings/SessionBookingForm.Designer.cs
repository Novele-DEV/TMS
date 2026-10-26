namespace TutoringManagementSystem
{
    partial class SessionBookingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBookTutorial = new Button();
            dtpSessionDate = new DateTimePicker();
            txtStudentID = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cmbTutor = new ComboBox();
            label3 = new Label();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            cmbMode = new ComboBox();
            label6 = new Label();
            SuspendLayout();
            //
            // btnBookTutorial
            //
            btnBookTutorial.Location = new Point(24, 409);
            btnBookTutorial.Name = "btnBookTutorial";
            btnBookTutorial.Size = new Size(126, 29);
            btnBookTutorial.TabIndex = 0;
            btnBookTutorial.Text = "Book Tutorial";
            btnBookTutorial.UseVisualStyleBackColor = true;
            btnBookTutorial.Click += btnBookTutorial_Click;
            //
            // dtpSessionDate
            //
            dtpSessionDate.Location = new Point(533, 270);
            dtpSessionDate.Name = "dtpSessionDate";
            dtpSessionDate.Size = new Size(243, 27);
            dtpSessionDate.TabIndex = 1;
            //
            // txtStudentID
            //
            txtStudentID.Location = new Point(151, 91);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(125, 27);
            txtStudentID.TabIndex = 2;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(415, 277);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 3;
            label1.Text = "Tutorial Date";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(24, 98);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 4;
            label2.Text = "Student ID";
            //
            // cmbTutor
            //
            cmbTutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTutor.FormattingEnabled = true;
            cmbTutor.Location = new Point(598, 98);
            cmbTutor.Name = "cmbTutor";
            cmbTutor.Size = new Size(151, 28);
            cmbTutor.TabIndex = 5;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(450, 102);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 6;
            label3.Text = "Tutor Selection";
            //
            // dtpStartTime
            //
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.ImeMode = ImeMode.NoControl;
            dtpStartTime.Location = new Point(186, 194);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(100, 27);
            dtpStartTime.TabIndex = 7;
            //
            // dtpEndTime
            //
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(186, 270);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(100, 27);
            dtpEndTime.TabIndex = 8;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(12, 192);
            label4.Name = "label4";
            label4.Size = new Size(130, 20);
            label4.TabIndex = 9;
            label4.Text = "Session Start Time";
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(12, 277);
            label5.Name = "label5";
            label5.Size = new Size(124, 20);
            label5.TabIndex = 10;
            label5.Text = "Session End Time";
            label5.Click += label5_Click;
            //
            // cmbMode
            //
            cmbMode.FormattingEnabled = true;
            cmbMode.Location = new Point(598, 189);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new Size(151, 28);
            cmbMode.TabIndex = 11;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Location = new Point(403, 201);
            label6.Name = "label6";
            label6.Size = new Size(177, 20);
            label6.TabIndex = 12;
            label6.Text = "Session Mode of Delivery";
            //
            // SessionBookingForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(cmbMode);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(label3);
            Controls.Add(cmbTutor);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtStudentID);
            Controls.Add(dtpSessionDate);
            Controls.Add(btnBookTutorial);
            Name = "SessionBookingForm";
            Text = "Session Booking";
            Load += SessionBookingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBookTutorial;
        private DateTimePicker dtpSessionDate;
        private TextBox txtStudentID;
        private Label label1;
        private Label label2;
        private ComboBox cmbTutor;
        private Label label3;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private Label label4;
        private Label label5;
        private ComboBox cmbMode;
        private Label label6;
    }
}

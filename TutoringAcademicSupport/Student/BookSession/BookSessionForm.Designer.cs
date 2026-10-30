namespace TutoringAcademicSupport.Student.BookSession
{
    partial class BookSessionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label lblSessionDate;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblTutor;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblMessage;

        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.ComboBox cmbRequest;
        private System.Windows.Forms.DateTimePicker dtpSessionDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.ComboBox cmbTutor;
        private System.Windows.Forms.ComboBox cmbMode;

        private System.Windows.Forms.Button btnBookTutorial;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookSessionForm));
            lblTitle = new Label();
            lblRules = new Label();
            lblStudentID = new Label();
            lblRequest = new Label();
            lblSessionDate = new Label();
            lblStartTime = new Label();
            lblEndTime = new Label();
            lblTutor = new Label();
            lblMode = new Label();
            lblMessage = new Label();
            txtStudentID = new TextBox();
            cmbRequest = new ComboBox();
            dtpSessionDate = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            cmbTutor = new ComboBox();
            cmbMode = new ComboBox();
            btnBookTutorial = new Button();
            btnClear = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Cooper Black", 25F);
            lblTitle.ForeColor = SystemColors.HotTrack;
            lblTitle.Location = new Point(40, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(524, 49);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Book a Tutorial Session";
            // 
            // lblRules
            // 
            lblRules.BackColor = Color.Transparent;
            lblRules.ForeColor = SystemColors.GrayText;
            lblRules.Location = new Point(40, 68);
            lblRules.Name = "lblRules";
            lblRules.Size = new Size(440, 44);
            lblRules.TabIndex = 1;
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.BackColor = Color.Transparent;
            lblStudentID.Location = new Point(40, 120);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(82, 20);
            lblStudentID.TabIndex = 2;
            lblStudentID.Text = "Student ID:";
            // 
            // lblRequest
            // 
            lblRequest.AutoSize = true;
            lblRequest.BackColor = Color.Transparent;
            lblRequest.Location = new Point(40, 165);
            lblRequest.Name = "lblRequest";
            lblRequest.Size = new Size(121, 20);
            lblRequest.TabIndex = 4;
            lblRequest.Text = "Tutoring request:";
            // 
            // lblSessionDate
            // 
            lblSessionDate.AutoSize = true;
            lblSessionDate.BackColor = Color.Transparent;
            lblSessionDate.Location = new Point(40, 210);
            lblSessionDate.Name = "lblSessionDate";
            lblSessionDate.Size = new Size(95, 20);
            lblSessionDate.TabIndex = 6;
            lblSessionDate.Text = "Session date:";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.BackColor = Color.Transparent;
            lblStartTime.Location = new Point(40, 255);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(77, 20);
            lblStartTime.TabIndex = 8;
            lblStartTime.Text = "Start time:";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.BackColor = Color.Transparent;
            lblEndTime.Location = new Point(40, 300);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(71, 20);
            lblEndTime.TabIndex = 10;
            lblEndTime.Text = "End time:";
            // 
            // lblTutor
            // 
            lblTutor.AutoSize = true;
            lblTutor.BackColor = Color.Transparent;
            lblTutor.Location = new Point(40, 345);
            lblTutor.Name = "lblTutor";
            lblTutor.Size = new Size(47, 20);
            lblTutor.TabIndex = 12;
            lblTutor.Text = "Tutor:";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.BackColor = Color.Transparent;
            lblMode.Location = new Point(40, 390);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(51, 20);
            lblMode.TabIndex = 14;
            lblMode.Text = "Mode:";
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Location = new Point(40, 429);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(629, 59);
            lblMessage.TabIndex = 18;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(180, 115);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(489, 27);
            txtStudentID.TabIndex = 3;
            txtStudentID.Leave += txtStudentID_Leave;
            // 
            // cmbRequest
            // 
            cmbRequest.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRequest.Location = new Point(180, 160);
            cmbRequest.Name = "cmbRequest";
            cmbRequest.Size = new Size(489, 28);
            cmbRequest.TabIndex = 5;
            cmbRequest.SelectedIndexChanged += AvailabilityInputs_Changed;
            // 
            // dtpSessionDate
            // 
            dtpSessionDate.Format = DateTimePickerFormat.Short;
            dtpSessionDate.Location = new Point(180, 205);
            dtpSessionDate.Name = "dtpSessionDate";
            dtpSessionDate.Size = new Size(489, 27);
            dtpSessionDate.TabIndex = 7;
            dtpSessionDate.ValueChanged += AvailabilityInputs_Changed;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(180, 250);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(489, 27);
            dtpStartTime.TabIndex = 9;
            dtpStartTime.ValueChanged += AvailabilityInputs_Changed;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(180, 295);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(489, 27);
            dtpEndTime.TabIndex = 11;
            dtpEndTime.ValueChanged += AvailabilityInputs_Changed;
            // 
            // cmbTutor
            // 
            cmbTutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTutor.Location = new Point(180, 340);
            cmbTutor.Name = "cmbTutor";
            cmbTutor.Size = new Size(489, 28);
            cmbTutor.TabIndex = 13;
            // 
            // cmbMode
            // 
            cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMode.Location = new Point(180, 385);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new Size(489, 28);
            cmbMode.TabIndex = 15;
            // 
            // btnBookTutorial
            // 
            btnBookTutorial.BackColor = SystemColors.HotTrack;
            btnBookTutorial.FlatStyle = FlatStyle.Popup;
            btnBookTutorial.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBookTutorial.ForeColor = SystemColors.ButtonHighlight;
            btnBookTutorial.Location = new Point(365, 512);
            btnBookTutorial.Name = "btnBookTutorial";
            btnBookTutorial.Size = new Size(144, 44);
            btnBookTutorial.TabIndex = 16;
            btnBookTutorial.Text = "B&ook Session";
            btnBookTutorial.UseVisualStyleBackColor = false;
            btnBookTutorial.Click += btnBookTutorial_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ButtonFace;
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = SystemColors.HotTrack;
            btnClear.Location = new Point(525, 512);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(144, 44);
            btnClear.TabIndex = 17;
            btnClear.Text = "&Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBack.ForeColor = Color.FromArgb(64, 64, 64);
            btnBack.Location = new Point(40, 512);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 44);
            btnBack.TabIndex = 19;
            btnBack.Text = "&Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // BookSessionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnBack;
            ClientSize = new Size(731, 568);
            Controls.Add(lblTitle);
            Controls.Add(lblRules);
            Controls.Add(lblStudentID);
            Controls.Add(txtStudentID);
            Controls.Add(lblRequest);
            Controls.Add(cmbRequest);
            Controls.Add(lblSessionDate);
            Controls.Add(dtpSessionDate);
            Controls.Add(lblStartTime);
            Controls.Add(dtpStartTime);
            Controls.Add(lblEndTime);
            Controls.Add(dtpEndTime);
            Controls.Add(lblTutor);
            Controls.Add(cmbTutor);
            Controls.Add(lblMode);
            Controls.Add(cmbMode);
            Controls.Add(btnBookTutorial);
            Controls.Add(btnClear);
            Controls.Add(btnBack);
            Controls.Add(lblMessage);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F);
            Name = "BookSessionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book a Tutorial Session";
            Load += BookSessionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

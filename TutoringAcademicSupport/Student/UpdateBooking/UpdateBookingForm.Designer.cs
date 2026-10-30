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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateBookingForm));
            label7 = new Label();
            lblRules = new Label();
            lblBooking = new Label();
            cmbBooking = new ComboBox();
            label3 = new Label();
            dtpSession = new DateTimePicker();
            label4 = new Label();
            dtpStartTime = new DateTimePicker();
            label5 = new Label();
            dtpEndTime = new DateTimePicker();
            label6 = new Label();
            cmbMode = new ComboBox();
            lblMessage = new Label();
            btnUpdateSession = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Cooper Black", 25F);
            label7.ForeColor = Color.Blue;
            label7.Location = new Point(28, 11);
            label7.Name = "label7";
            label7.Size = new Size(272, 41);
            label7.Size = new Size(400, 49);
            label7.TabIndex = 0;
            label7.Text = "Update a Booking";
            // 
            // lblRules
            // 
            lblRules.BackColor = Color.Transparent;
            lblRules.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRules.ForeColor = SystemColors.GrayText;
            lblRules.Location = new Point(28, 60);
            lblRules.Name = "lblRules";
            lblRules.Size = new Size(328, 24);
            lblRules.TabIndex = 1;
            lblRules.Text = "Update a booking that you have already made.";
            lblRules.Click += lblRules_Click;
            // 
            // lblBooking
            // 
            lblBooking.AutoSize = true;
            lblBooking.BackColor = Color.Transparent;
            lblBooking.Location = new Point(28, 108);
            lblBooking.Name = "lblBooking";
            lblBooking.Size = new Size(100, 20);
            lblBooking.TabIndex = 2;
            lblBooking.Text = "Your boo&king:";
            // 
            // cmbBooking
            // 
            cmbBooking.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBooking.Location = new Point(170, 104);
            cmbBooking.Name = "cmbBooking";
            cmbBooking.Size = new Size(440, 28);
            cmbBooking.TabIndex = 3;
            cmbBooking.SelectedIndexChanged += cmbBooking_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(28, 156);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 4;
            label3.Text = "Session &date:";
            // 
            // dtpSession
            // 
            dtpSession.Format = DateTimePickerFormat.Short;
            dtpSession.Location = new Point(170, 152);
            dtpSession.Name = "dtpSession";
            dtpSession.Size = new Size(200, 27);
            dtpSession.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(28, 202);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 6;
            label4.Text = "&Start time:";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(170, 198);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(120, 27);
            dtpStartTime.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(28, 248);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 8;
            label5.Text = "&End time:";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(170, 244);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(120, 27);
            dtpEndTime.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(28, 294);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 10;
            label6.Text = "M&ode:";
            // 
            // cmbMode
            // 
            cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMode.Location = new Point(170, 290);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new Size(200, 28);
            cmbMode.TabIndex = 11;
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Location = new Point(28, 336);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(582, 56);
            lblMessage.TabIndex = 12;
            // 
            // btnUpdateSession
            // 
            btnUpdateSession.BackColor = Color.Blue;
            btnUpdateSession.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdateSession.ForeColor = Color.White;
            btnUpdateSession.Location = new Point(28, 404);
            btnUpdateSession.Location = new Point(395, 395);
            btnUpdateSession.Name = "btnUpdateSession";
            btnUpdateSession.Size = new Size(203, 63);
            btnUpdateSession.TabIndex = 13;
            btnUpdateSession.Text = "&Update Booking";
            btnUpdateSession.UseVisualStyleBackColor = false;
            btnUpdateSession.Click += btnUpdateSession_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(64, 64, 64);
            btnClose.Location = new Point(470, 404);
            btnClose.Location = new Point(24, 414);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 44);
            btnClose.TabIndex = 14;
            btnClose.Text = "&Back";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // UpdateBookingForm
            // 
            AcceptButton = btnUpdateSession;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnClose;
            ClientSize = new Size(640, 470);
            Controls.Add(btnClose);
            Controls.Add(btnUpdateSession);
            Controls.Add(lblMessage);
            Controls.Add(cmbMode);
            Controls.Add(label6);
            Controls.Add(dtpEndTime);
            Controls.Add(label5);
            Controls.Add(dtpStartTime);
            Controls.Add(label4);
            Controls.Add(dtpSession);
            Controls.Add(label3);
            Controls.Add(cmbBooking);
            Controls.Add(lblBooking);
            Controls.Add(lblRules);
            Controls.Add(label7);
            DoubleBuffered = true;
            Name = "UpdateBookingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update a Booking";
            Load += UpdateBookingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label lblRules;
        private Label lblBooking;
        private ComboBox cmbBooking;
        private Label label3;
        private DateTimePicker dtpSession;
        private Label label4;
        private DateTimePicker dtpStartTime;
        private Label label5;
        private DateTimePicker dtpEndTime;
        private Label label6;
        private ComboBox cmbMode;
        private Label lblMessage;
        private Button btnUpdateSession;
        private Button btnClose;
    }
}

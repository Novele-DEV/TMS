namespace Tutoring_Management_System
{
    partial class TutorDetailsForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveTutor = new System.Windows.Forms.Button();
            this.btnCancelChange = new System.Windows.Forms.Button();
            this.errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtTutorID = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.cboPreference = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tutor ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Academic Average";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Preference";
            // 
            // btnSaveTutor
            // 
            this.btnSaveTutor.Location = new System.Drawing.Point(217, 533);
            this.btnSaveTutor.Name = "btnSaveTutor";
            this.btnSaveTutor.Size = new System.Drawing.Size(125, 56);
            this.btnSaveTutor.TabIndex = 7;
            this.btnSaveTutor.Text = "Save";
            this.btnSaveTutor.UseVisualStyleBackColor = true;
            this.btnSaveTutor.Click += new System.EventHandler(this.btnSaveTutor_Click);
            // 
            // btnCancelChange
            // 
            this.btnCancelChange.Location = new System.Drawing.Point(510, 533);
            this.btnCancelChange.Name = "btnCancelChange";
            this.btnCancelChange.Size = new System.Drawing.Size(131, 56);
            this.btnCancelChange.TabIndex = 8;
            this.btnCancelChange.Text = "Cancel";
            this.btnCancelChange.UseVisualStyleBackColor = true;
            this.btnCancelChange.Click += new System.EventHandler(this.btnCancelChange_Click);
            // 
            // errors
            // 
            this.errors.ContainerControl = this;
            // 
            // txtTutorID
            // 
            this.txtTutorID.Location = new System.Drawing.Point(272, 52);
            this.txtTutorID.Name = "txtTutorID";
            this.txtTutorID.Size = new System.Drawing.Size(282, 22);
            this.txtTutorID.TabIndex = 9;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(272, 108);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(282, 22);
            this.txtFirstName.TabIndex = 10;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(272, 173);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(282, 22);
            this.txtLastName.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(272, 229);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(282, 22);
            this.txtEmail.TabIndex = 12;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(272, 288);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(282, 22);
            this.txtPhone.TabIndex = 13;
            // 
            // txtAverage
            // 
            this.txtAverage.Location = new System.Drawing.Point(272, 344);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.Size = new System.Drawing.Size(282, 22);
            this.txtAverage.TabIndex = 14;
            // 
            // cboPreference
            // 
            this.cboPreference.FormattingEnabled = true;
            this.cboPreference.Items.AddRange(new object[] {
            "In-person",
            "Online",
            "Hybrid"});
            this.cboPreference.Location = new System.Drawing.Point(272, 395);
            this.cboPreference.Name = "cboPreference";
            this.cboPreference.Size = new System.Drawing.Size(282, 24);
            this.cboPreference.TabIndex = 16;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(171, 467);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 17;
            // 
            // TutorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 641);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboPreference);
            this.Controls.Add(this.txtAverage);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtTutorID);
            this.Controls.Add(this.btnCancelChange);
            this.Controls.Add(this.btnSaveTutor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TutorDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tutor Details";
            this.Load += new System.EventHandler(this.TutorDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaveTutor;
        private System.Windows.Forms.Button btnCancelChange;
        private System.Windows.Forms.ErrorProvider errors;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtTutorID;
        private System.Windows.Forms.ComboBox cboPreference;
        private System.Windows.Forms.Label lblStatus;
    }
}
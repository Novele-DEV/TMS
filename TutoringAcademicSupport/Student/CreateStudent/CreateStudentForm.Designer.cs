namespace TutoringAcademicSupport.Student.CreateStudent
{
    partial class CreateStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateStudentForm));
            lblHeading = new Label();
            txtStudentID = new TextBox();
            dtpDoB = new DateTimePicker();
            txtFirstName = new TextBox();
            txtEmail = new TextBox();
            cboFaculty = new ComboBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            cboProgramme = new ComboBox();
            btnBack = new Button();
            btnCreate = new Button();
            lblStudentNo = new Label();
            lblDoB = new Label();
            lblFName = new Label();
            lblLName = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblFaculty = new Label();
            lblProgramme = new Label();
            errorProvider = new ErrorProvider(components);
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            lblMessage = new Label();
            lblRequired = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.BackColor = Color.Transparent;
            lblHeading.Font = new Font("Cooper Black", 25F);
            lblHeading.ForeColor = Color.DarkBlue;
            lblHeading.Location = new Point(12, 19);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(473, 49);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Create a new student";
            // 
            // txtStudentID
            // 
            txtStudentID.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStudentID.Location = new Point(12, 147);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(258, 29);
            txtStudentID.TabIndex = 1;
            // 
            // dtpDoB
            // 
            dtpDoB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDoB.Location = new Point(618, 212);
            dtpDoB.Name = "dtpDoB";
            dtpDoB.Size = new Size(258, 29);
            dtpDoB.TabIndex = 2;
            dtpDoB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDoB.Location = new Point(400, 76);
            dtpDoB.Name = "dtpDoB";
            dtpDoB.Size = new Size(258, 29);
            dtpDoB.TabIndex = 2;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(12, 212);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(258, 29);
            txtFirstName.TabIndex = 3;
            txtFirstName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(20, 138);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(258, 29);
            txtFirstName.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(12, 324);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(258, 29);
            txtEmail.TabIndex = 4;
            txtEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(20, 200);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "name@example.com";
            txtEmail.Size = new Size(258, 29);
            txtEmail.TabIndex = 4;
            // 
            // cboFaculty
            // 
            cboFaculty.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboFaculty.FormattingEnabled = true;
            cboFaculty.Location = new Point(12, 432);
            cboFaculty.Name = "cboFaculty";
            cboFaculty.Size = new Size(258, 29);
            cboFaculty.TabIndex = 5;
            cboFaculty.SelectedIndexChanged += cboFaculty_SelectedIndexChanged;
            cboFaculty.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboFaculty.FormattingEnabled = true;
            cboFaculty.Location = new Point(20, 262);
            cboFaculty.Name = "cboFaculty";
            cboFaculty.Size = new Size(258, 29);
            cboFaculty.TabIndex = 5;
            cboFaculty.SelectedIndexChanged += cboFaculty_SelectedIndexChanged;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(317, 212);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(258, 29);
            txtLastName.TabIndex = 6;
            txtLastName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(400, 138);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(258, 29);
            txtLastName.TabIndex = 6;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(392, 324);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(258, 29);
            txtPhone.TabIndex = 7;
            txtPhone.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(400, 200);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "+27821234567";
            txtPhone.Size = new Size(258, 29);
            txtPhone.TabIndex = 7;
            // 
            // cboProgramme
            // 
            cboProgramme.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboProgramme.FormattingEnabled = true;
            cboProgramme.Location = new Point(392, 432);
            cboProgramme.Name = "cboProgramme";
            cboProgramme.Size = new Size(258, 29);
            cboProgramme.TabIndex = 8;
            cboProgramme.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboProgramme.FormattingEnabled = true;
            cboProgramme.Location = new Point(400, 262);
            cboProgramme.Name = "cboProgramme";
            cboProgramme.Size = new Size(258, 29);
            cboProgramme.TabIndex = 8;
            // 
            // lblRequired
            // 
            lblRequired.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequired.Location = new Point(20, 446);
            lblRequired.Name = "lblRequired";
            lblRequired.Size = new Size(258, 37);
            lblRequired.TabIndex = 9;
            lblRequired.Text = "label1";
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(20, 499);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(710, 44);
            lblMessage.TabIndex = 10;
            lblMessage.Text = "label1";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.FromArgb(64, 64, 64);
            btnBack.Location = new Point(732, 683);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(144, 44);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back to Login";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            btnBack.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(20, 570);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 44);
            btnBack.TabIndex = 11;
            btnBack.Text = "&Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.DarkBlue;
            btnCreate.FlatStyle = FlatStyle.Popup;
            btnCreate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(15, 683);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(144, 44);
            btnCreate.TabIndex = 12;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            btnCreate.BackColor = Color.FromArgb(31, 56, 100);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(420, 351);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(149, 59);
            btnCreate.TabIndex = 12;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // lblStudentNo
            // 
            lblStudentNo.AutoSize = true;
            lblStudentNo.BackColor = Color.Transparent;
            lblStudentNo.Location = new Point(15, 128);
            lblStudentNo.Name = "lblStudentNo";
            lblStudentNo.Size = new Size(119, 19);
            lblStudentNo.TabIndex = 13;
            lblStudentNo.Text = "Student number *";
            lblStudentNo.AutoSize = true;
            lblStudentNo.Location = new Point(20, 57);
            lblStudentNo.Name = "lblStudentNo";
            lblStudentNo.Size = new Size(119, 19);
            lblStudentNo.TabIndex = 13;
            lblStudentNo.Text = "Student number *";
            // 
            // lblDoB
            // 
            lblDoB.AutoSize = true;
            lblDoB.BackColor = Color.Transparent;
            lblDoB.Location = new Point(618, 193);
            lblDoB.Name = "lblDoB";
            lblDoB.Size = new Size(97, 19);
            lblDoB.TabIndex = 14;
            lblDoB.Text = "Date of birth *";
            lblDoB.AutoSize = true;
            lblDoB.Location = new Point(400, 57);
            lblDoB.Name = "lblDoB";
            lblDoB.Size = new Size(97, 19);
            lblDoB.TabIndex = 14;
            lblDoB.Text = "Date of birth *";
            // 
            // lblFName
            // 
            lblFName.AutoSize = true;
            lblFName.BackColor = Color.Transparent;
            lblFName.Location = new Point(12, 193);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(83, 19);
            lblFName.TabIndex = 15;
            lblFName.Text = "First name *";
            lblFName.AutoSize = true;
            lblFName.Location = new Point(20, 119);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(83, 19);
            lblFName.TabIndex = 15;
            lblFName.Text = "First name *";
            // 
            // lblLName
            // 
            lblLName.AutoSize = true;
            lblLName.BackColor = Color.Transparent;
            lblLName.Location = new Point(317, 193);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(82, 19);
            lblLName.TabIndex = 16;
            lblLName.Text = "Last name *";
            lblLName.AutoSize = true;
            lblLName.Location = new Point(400, 119);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(82, 19);
            lblLName.TabIndex = 16;
            lblLName.Text = "Last name *";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Location = new Point(12, 305);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 19);
            lblEmail.TabIndex = 17;
            lblEmail.Text = "Email *";
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 181);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 19);
            lblEmail.TabIndex = 17;
            lblEmail.Text = "Email *";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(400, 181);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(58, 19);
            lblPhone.TabIndex = 18;
            lblPhone.Text = "Phone *";
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.BackColor = Color.Transparent;
            lblFaculty.Location = new Point(12, 413);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(62, 19);
            lblFaculty.TabIndex = 19;
            lblFaculty.Text = "Faculty *";
            lblFaculty.AutoSize = true;
            lblFaculty.Location = new Point(20, 243);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(62, 19);
            lblFaculty.TabIndex = 19;
            lblFaculty.Text = "Faculty *";
            // 
            // lblProgramme
            // 
            lblProgramme.AutoSize = true;
            lblProgramme.BackColor = Color.Transparent;
            lblProgramme.Location = new Point(392, 413);
            lblProgramme.Name = "lblProgramme";
            lblProgramme.Size = new Size(145, 19);
            lblProgramme.TabIndex = 20;
            lblProgramme.Text = "Programme of study *";
            lblProgramme.AutoSize = true;
            lblProgramme.Location = new Point(400, 243);
            lblProgramme.Name = "lblProgramme";
            lblProgramme.Size = new Size(145, 19);
            lblProgramme.TabIndex = 20;
            lblProgramme.Text = "Programme of study *";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(12, 560);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(258, 29);
            txtPassword.TabIndex = 21;
            txtPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(20, 331);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(258, 29);
            txtPassword.TabIndex = 21;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(392, 557);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(258, 29);
            txtConfirmPassword.TabIndex = 22;
            txtConfirmPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(20, 391);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(258, 29);
            txtConfirmPassword.TabIndex = 22;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Location = new Point(12, 541);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 19);
            lblPassword.TabIndex = 24;
            lblPassword.Text = "Password *";
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(20, 312);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 19);
            lblPassword.TabIndex = 24;
            lblPassword.Text = "Password *";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.BackColor = Color.Transparent;
            lblConfirmPassword.Location = new Point(392, 541);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(130, 19);
            lblConfirmPassword.TabIndex = 25;
            lblConfirmPassword.Text = "Confirm Password *";
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(17, 636);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(893, 44);
            lblMessage.TabIndex = 10;
            // 
            // lblRequired
            // 
            lblRequired.BackColor = Color.Transparent;
            lblRequired.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequired.Location = new Point(17, 571);
            lblRequired.Name = "lblRequired";
            lblRequired.Size = new Size(893, 37);
            lblRequired.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(12, 268);
            label1.Name = "label1";
            label1.Size = new Size(104, 19);
            label1.TabIndex = 26;
            label1.Text = "Contact details";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(12, 97);
            label2.Name = "label2";
            label2.Size = new Size(141, 19);
            label2.TabIndex = 27;
            label2.Text = "Personal Information";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(12, 394);
            label3.Name = "label3";
            label3.Size = new Size(115, 19);
            label3.TabIndex = 28;
            label3.Text = "Academic details";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            label4.ForeColor = SystemColors.ActiveCaption;
            label4.Location = new Point(12, 513);
            label4.Name = "label4";
            label4.Size = new Size(58, 19);
            label4.TabIndex = 29;
            label4.Text = "Security";
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(20, 372);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(130, 19);
            lblConfirmPassword.TabIndex = 25;
            lblConfirmPassword.Text = "Confirm password *";
            // 
            // CreateStudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(922, 756);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblProgramme);
            Controls.Add(lblFaculty);
            Controls.Add(lblPhone);
            Controls.Add(lblEmail);
            Controls.Add(lblLName);
            Controls.Add(lblFName);
            Controls.Add(lblDoB);
            Controls.Add(lblStudentNo);
            Controls.Add(btnCreate);
            Controls.Add(btnBack);
            Controls.Add(lblMessage);
            Controls.Add(lblRequired);
            Controls.Add(cboProgramme);
            Controls.Add(txtPhone);
            Controls.Add(txtLastName);
            Controls.Add(cboFaculty);
            Controls.Add(txtEmail);
            Controls.Add(txtFirstName);
            Controls.Add(dtpDoB);
            Controls.Add(txtStudentID);
            Controls.Add(lblHeading);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "CreateStudentForm";
            Text = "Create Student";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 626);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblProgramme);
            Controls.Add(lblFaculty);
            Controls.Add(lblPhone);
            Controls.Add(lblEmail);
            Controls.Add(lblLName);
            Controls.Add(lblFName);
            Controls.Add(lblDoB);
            Controls.Add(lblStudentNo);
            Controls.Add(btnCreate);
            Controls.Add(btnBack);
            Controls.Add(lblMessage);
            Controls.Add(lblRequired);
            Controls.Add(cboProgramme);
            Controls.Add(txtPhone);
            Controls.Add(txtLastName);
            Controls.Add(cboFaculty);
            Controls.Add(txtEmail);
            Controls.Add(txtFirstName);
            Controls.Add(dtpDoB);
            Controls.Add(txtStudentID);
            Controls.Add(lblHeading);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "CreateStudentForm";
            Text = "Create Student";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.DateTimePicker dtpDoB;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cboFaculty;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cboProgramme;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblStudentNo;
        private System.Windows.Forms.Label lblDoB;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.Label lblProgramme;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private Label lblMessage;
        private Label lblRequired;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
    }
}
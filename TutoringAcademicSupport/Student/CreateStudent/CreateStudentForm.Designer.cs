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
            lblHeading = new Label();
            txtStudentID = new TextBox();
            dtpDoB = new DateTimePicker();
            txtFirstName = new TextBox();
            txtEmail = new TextBox();
            cboFaculty = new ComboBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            cboProgramme = new ComboBox();
            lblRequired = new Label();
            lblMessage = new Label();
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
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeading.ForeColor = Color.FromArgb(31, 56, 100);
            lblHeading.Location = new Point(20, 14);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(255, 32);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Create a new student";
            // 
            // txtStudentID
            // 
            txtStudentID.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStudentID.Location = new Point(20, 76);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.PlaceholderText = "2000015";
            txtStudentID.Size = new Size(258, 29);
            txtStudentID.TabIndex = 1;
            // 
            // dtpDoB
            // 
            dtpDoB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDoB.Location = new Point(400, 76);
            dtpDoB.Name = "dtpDoB";
            dtpDoB.Size = new Size(258, 29);
            dtpDoB.TabIndex = 2;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(20, 138);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(258, 29);
            txtFirstName.TabIndex = 3;
            // 
            // txtEmail
            // 
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
            cboFaculty.Location = new Point(20, 262);
            cboFaculty.Name = "cboFaculty";
            cboFaculty.Size = new Size(258, 29);
            cboFaculty.TabIndex = 5;
            cboFaculty.SelectedIndexChanged += cboFaculty_SelectedIndexChanged;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(400, 138);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(258, 29);
            txtLastName.TabIndex = 6;
            // 
            // txtPhone
            // 
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
            lblStudentNo.Location = new Point(20, 57);
            lblStudentNo.Name = "lblStudentNo";
            lblStudentNo.Size = new Size(119, 19);
            lblStudentNo.TabIndex = 13;
            lblStudentNo.Text = "Student number *";
            // 
            // lblDoB
            // 
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
            lblFName.Location = new Point(20, 119);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(83, 19);
            lblFName.TabIndex = 15;
            lblFName.Text = "First name *";
            // 
            // lblLName
            // 
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
            lblFaculty.Location = new Point(20, 243);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(62, 19);
            lblFaculty.TabIndex = 19;
            lblFaculty.Text = "Faculty *";
            // 
            // lblProgramme
            // 
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
            txtPassword.Location = new Point(20, 331);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(258, 29);
            txtPassword.TabIndex = 21;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(20, 391);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(258, 29);
            txtConfirmPassword.TabIndex = 22;
            // 
            // lblPassword
            // 
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
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label lblMessage;
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
    }
}
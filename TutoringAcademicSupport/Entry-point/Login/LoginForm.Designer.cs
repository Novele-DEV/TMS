namespace TutoringAcademicSupport.EntryPoint.Login
{
    partial class LoginForm
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
            lblIntro = new Label();
            lblUserID = new Label();
            txtUserID = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblMessage = new Label();
            LnkCreateStudent = new LinkLabel();
            btnExit = new Button();
            btnLogIn = new Button();
            errorProvider = new ErrorProvider(components);
            lblIntroduction = new Label();
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
            lblHeading.Size = new Size(267, 32);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Log into your account";
            // 
            // lblIntro
            // 
            lblIntro.AutoSize = true;
            lblIntro.Location = new Point(22, 79);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(314, 23);
            lblIntro.TabIndex = 1;
            lblIntro.Text = "Enter your ID and password to continue";
            lblIntro.Click += lblIntro_Click;
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Location = new Point(22, 134);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(284, 23);
            lblUserID.TabIndex = 5;
            lblUserID.Text = "Student number or administrator ID";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(20, 154);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(480, 29);
            txtUserID.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(22, 208);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 23);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 228);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(480, 29);
            txtPassword.TabIndex = 8;
            // 
            // lblMessage
            // 
            lblMessage.Location = new Point(20, 272);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(480, 36);
            lblMessage.TabIndex = 9;
            lblMessage.Text = "You are loggin in as";
            lblMessage.Click += lblMessage_Click;
            // 
            // LnkCreateStudent
            // 
            LnkCreateStudent.AutoSize = true;
            LnkCreateStudent.Location = new Point(20, 318);
            LnkCreateStudent.Name = "LnkCreateStudent";
            LnkCreateStudent.Size = new Size(264, 23);
            LnkCreateStudent.TabIndex = 10;
            LnkCreateStudent.TabStop = true;
            LnkCreateStudent.Text = "New student? Create an account.";
            LnkCreateStudent.LinkClicked += LnkCreateStudent_LinkClicked;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(12, 360);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 32);
            btnExit.TabIndex = 11;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.FromArgb(31, 56, 100);
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.ForeColor = Color.White;
            btnLogIn.Location = new Point(538, 360);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(100, 32);
            btnLogIn.TabIndex = 12;
            btnLogIn.Text = "Log In";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // lblIntroduction
            // 
            lblIntroduction.AutoSize = true;
            lblIntroduction.Location = new Point(20, 46);
            lblIntroduction.Name = "lblIntroduction";
            lblIntroduction.Size = new Size(0, 23);
            lblIntroduction.TabIndex = 13;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 401);
            Controls.Add(lblIntroduction);
            Controls.Add(btnLogIn);
            Controls.Add(btnExit);
            Controls.Add(LnkCreateStudent);
            Controls.Add(lblMessage);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUserID);
            Controls.Add(lblUserID);
            Controls.Add(lblIntro);
            Controls.Add(lblHeading);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "LoginForm";
            Text = "Log in";
            Load += frmLogIn_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.LinkLabel LnkCreateStudent;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Label lblIntroduction;
    }
}

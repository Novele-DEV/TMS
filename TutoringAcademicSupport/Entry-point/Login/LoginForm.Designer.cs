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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
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
            lblHeading.BackColor = Color.Transparent;
            lblHeading.Font = new Font("Cooper Black", 25F);
            lblHeading.ForeColor = SystemColors.HotTrack;
            lblHeading.Location = new Point(20, 20);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(487, 49);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Log into your account";
            // 
            // lblIntro
            // 
            lblIntro.AutoSize = true;
            lblIntro.BackColor = Color.Transparent;
            lblIntro.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblIntro.Location = new Point(22, 79);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(301, 23);
            lblIntro.TabIndex = 1;
            lblIntro.Text = "Enter your ID and password to continue";
            lblIntro.Click += lblIntro_Click;
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.BackColor = Color.Transparent;
            lblUserID.Location = new Point(22, 128);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(284, 23);
            lblUserID.TabIndex = 5;
            lblUserID.Text = "Student number or administrator ID";
            // 
            // txtUserID
            // 
            txtUserID.BorderStyle = BorderStyle.FixedSingle;
            txtUserID.Location = new Point(20, 154);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(633, 29);
            txtUserID.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Location = new Point(20, 229);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 23);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(22, 255);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(631, 29);
            txtPassword.TabIndex = 8;
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Location = new Point(20, 336);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(633, 36);
            lblMessage.TabIndex = 9;
            lblMessage.Text = "You are loggin in as";
            lblMessage.Click += lblMessage_Click;
            // 
            // LnkCreateStudent
            // 
            LnkCreateStudent.AutoSize = true;
            LnkCreateStudent.BackColor = Color.Transparent;
            LnkCreateStudent.Location = new Point(20, 415);
            LnkCreateStudent.Name = "LnkCreateStudent";
            LnkCreateStudent.Size = new Size(264, 23);
            LnkCreateStudent.TabIndex = 10;
            LnkCreateStudent.TabStop = true;
            LnkCreateStudent.Text = "New student? Create an account.";
            LnkCreateStudent.LinkClicked += LnkCreateStudent_LinkClicked;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(64, 64, 64);
            btnExit.Location = new Point(587, 501);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(66, 44);
            btnExit.TabIndex = 12;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = SystemColors.HotTrack;
            btnLogIn.Cursor = Cursors.Hand;
            btnLogIn.FlatAppearance.BorderSize = 0;
            btnLogIn.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnLogIn.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnLogIn.FlatStyle = FlatStyle.Popup;
            btnLogIn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogIn.ForeColor = Color.White;
            btnLogIn.Location = new Point(22, 480);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(181, 65);
            btnLogIn.TabIndex = 11;
            btnLogIn.Text = "&Log In";
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
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(683, 570);
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
            DoubleBuffered = true;
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

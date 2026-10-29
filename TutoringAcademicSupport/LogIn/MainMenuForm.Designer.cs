namespace TutoringAcademicSupport.LogIn
{
    partial class MainMenuForm
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
            label1 = new Label();
            label3 = new Label();
            btnAdministrator = new Button();
            btnTutor = new Button();
            btnStudent = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(351, 41);
            label1.TabIndex = 0;
            label1.Text = "Welcome to Byte Better";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(371, 418);
            label3.Name = "label3";
            label3.Size = new Size(120, 23);
            label3.TabIndex = 10;
            label3.Text = "Select your role";
            // 
            // btnAdministrator
            // 
            btnAdministrator.BackColor = SystemColors.HotTrack;
            btnAdministrator.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnAdministrator.ForeColor = SystemColors.Control;
            btnAdministrator.Location = new Point(591, 271);
            btnAdministrator.Name = "btnAdministrator";
            btnAdministrator.Size = new Size(227, 101);
            btnAdministrator.TabIndex = 9;
            btnAdministrator.Text = "Administrator";
            btnAdministrator.UseVisualStyleBackColor = false;
            btnAdministrator.Click += btnAdministrator_Click;
            // 
            // btnTutor
            // 
            btnTutor.BackColor = SystemColors.HotTrack;
            btnTutor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnTutor.ForeColor = SystemColors.Control;
            btnTutor.Location = new Point(312, 271);
            btnTutor.Name = "btnTutor";
            btnTutor.Size = new Size(201, 101);
            btnTutor.TabIndex = 8;
            btnTutor.Text = "Tutor";
            btnTutor.UseVisualStyleBackColor = false;
            btnTutor.Click += btnTutor_Click;
            // 
            // btnStudent
            // 
            btnStudent.BackColor = SystemColors.HotTrack;
            btnStudent.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnStudent.ForeColor = SystemColors.Control;
            btnStudent.Location = new Point(0, 271);
            btnStudent.Name = "btnStudent";
            btnStudent.Size = new Size(222, 101);
            btnStudent.TabIndex = 7;
            btnStudent.Text = "Student";
            btnStudent.UseVisualStyleBackColor = false;
            btnStudent.Click += btnStudent_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.GradientActiveCaption;
            label2.Location = new Point(19, 50);
            label2.Name = "label2";
            label2.Size = new Size(494, 41);
            label2.TabIndex = 6;
            label2.Text = "smarter learning, brighter futures";
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 450);
            Controls.Add(label3);
            Controls.Add(btnAdministrator);
            Controls.Add(btnTutor);
            Controls.Add(btnStudent);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Button btnAdministrator;
        private Button btnTutor;
        private Button btnStudent;
        private Label label2;
    }
}
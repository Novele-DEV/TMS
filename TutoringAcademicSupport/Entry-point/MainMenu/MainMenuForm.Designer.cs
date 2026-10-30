namespace TutoringAcademicSupport.EntryPoint.MainMenu
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
            tblLayout = new TableLayoutPanel();
            picLogo = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tblRoles = new TableLayoutPanel();
            btnStudent = new Button();
            btnTutor = new Button();
            btnAdministrator = new Button();
            btnExit = new Button();
            tblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tblRoles.SuspendLayout();
            SuspendLayout();
            //
            // tblLayout
            //
            tblLayout.BackColor = Color.White;
            tblLayout.ColumnCount = 1;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblLayout.Controls.Add(picLogo, 0, 1);
            tblLayout.Controls.Add(label1, 0, 3);
            tblLayout.Controls.Add(label2, 0, 4);
            tblLayout.Controls.Add(label3, 0, 6);
            tblLayout.Controls.Add(tblRoles, 0, 7);
            tblLayout.Controls.Add(btnExit, 0, 9);
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.Location = new Point(0, 0);
            tblLayout.Name = "tblLayout";
            tblLayout.RowCount = 10;
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblLayout.Size = new Size(860, 600);
            tblLayout.TabIndex = 0;
            //
            // picLogo
            //
            picLogo.AccessibleName = "Byte Better logo";
            picLogo.Anchor = AnchorStyles.None;
            picLogo.Location = new Point(360, 1);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(140, 140);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            //
            // label1
            //
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.TabIndex = 1;
            label1.Text = "Welcome to Byte Better";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label2
            //
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(96, 96, 96);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.TabIndex = 2;
            label2.Text = "Tutoring and Academic Support  ·  Smarter learning, brighter futures";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label3
            //
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(31, 56, 100);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.TabIndex = 3;
            label3.Text = "How would you like to continue?";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            //
            // tblRoles
            //
            tblRoles.Anchor = AnchorStyles.None;
            tblRoles.ColumnCount = 5;
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tblRoles.Controls.Add(btnStudent, 0, 0);
            tblRoles.Controls.Add(btnTutor, 2, 0);
            tblRoles.Controls.Add(btnAdministrator, 4, 0);
            tblRoles.Margin = new Padding(0);
            tblRoles.Name = "tblRoles";
            tblRoles.RowCount = 1;
            tblRoles.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tblRoles.Size = new Size(716, 120);
            tblRoles.TabIndex = 4;
            //
            // btnStudent
            //
            btnStudent.BackColor = Color.FromArgb(31, 56, 100);
            btnStudent.Cursor = Cursors.Hand;
            btnStudent.Dock = DockStyle.Fill;
            btnStudent.FlatAppearance.BorderSize = 0;
            btnStudent.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnStudent.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnStudent.FlatStyle = FlatStyle.Flat;
            btnStudent.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            btnStudent.ForeColor = Color.White;
            btnStudent.Margin = new Padding(0);
            btnStudent.Name = "btnStudent";
            btnStudent.TabIndex = 0;
            btnStudent.Text = "&Student";
            btnStudent.UseVisualStyleBackColor = false;
            btnStudent.Click += btnStudent_Click;
            //
            // btnTutor
            //
            btnTutor.BackColor = Color.FromArgb(31, 56, 100);
            btnTutor.Cursor = Cursors.Hand;
            btnTutor.Dock = DockStyle.Fill;
            btnTutor.FlatAppearance.BorderSize = 0;
            btnTutor.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnTutor.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnTutor.FlatStyle = FlatStyle.Flat;
            btnTutor.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            btnTutor.ForeColor = Color.White;
            btnTutor.Margin = new Padding(0);
            btnTutor.Name = "btnTutor";
            btnTutor.TabIndex = 1;
            btnTutor.Text = "&Tutor";
            btnTutor.UseVisualStyleBackColor = false;
            btnTutor.Click += btnTutor_Click;
            //
            // btnAdministrator
            //
            btnAdministrator.BackColor = Color.FromArgb(31, 56, 100);
            btnAdministrator.Cursor = Cursors.Hand;
            btnAdministrator.Dock = DockStyle.Fill;
            btnAdministrator.FlatAppearance.BorderSize = 0;
            btnAdministrator.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnAdministrator.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnAdministrator.FlatStyle = FlatStyle.Flat;
            btnAdministrator.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            btnAdministrator.ForeColor = Color.White;
            btnAdministrator.Margin = new Padding(0);
            btnAdministrator.Name = "btnAdministrator";
            btnAdministrator.TabIndex = 2;
            btnAdministrator.Text = "&Administrator";
            btnAdministrator.UseVisualStyleBackColor = false;
            btnAdministrator.Click += btnAdministrator_Click;
            //
            // btnExit
            //
            btnExit.Anchor = AnchorStyles.Right;
            btnExit.BackColor = Color.White;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 228, 235);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 242, 246);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.FromArgb(64, 64, 64);
            btnExit.Margin = new Padding(0, 0, 24, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(110, 36);
            btnExit.TabIndex = 5;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            //
            // MainMenuForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(860, 600);
            Controls.Add(tblLayout);
            MinimumSize = new Size(800, 640);
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Byte Better - Tutoring and Academic Support";
            tblLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tblRoles.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblLayout;
        private PictureBox picLogo;
        private Label label1;
        private Label label2;
        private Label label3;
        private TableLayoutPanel tblRoles;
        private Button btnStudent;
        private Button btnTutor;
        private Button btnAdministrator;
        private Button btnExit;
    }
}

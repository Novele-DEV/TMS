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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            tblLayout = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tblRoles = new TableLayoutPanel();
            btnStudent = new Button();
            btnTutor = new Button();
            btnAdministrator = new Button();
            btnExit = new Button();
            picLogo = new PictureBox();
            tblLayout.SuspendLayout();
            tblRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // tblLayout
            // 
            tblLayout.BackColor = SystemColors.ButtonHighlight;
            tblLayout.BackgroundImage = (Image)resources.GetObject("tblLayout.BackgroundImage");
            tblLayout.BackgroundImageLayout = ImageLayout.Stretch;
            tblLayout.ColumnCount = 1;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblLayout.Controls.Add(label1, 0, 3);
            tblLayout.Controls.Add(label2, 0, 4);
            tblLayout.Controls.Add(label3, 0, 6);
            tblLayout.Controls.Add(tblRoles, 0, 7);
            tblLayout.Controls.Add(btnExit, 0, 9);
            tblLayout.Controls.Add(picLogo, 0, 1);
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.Location = new Point(0, 0);
            tblLayout.Name = "tblLayout";
            tblLayout.RowCount = 10;
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 117F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblLayout.Size = new Size(860, 600);
            tblLayout.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Cooper Black", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(0, 201);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(860, 54);
            label1.TabIndex = 1;
            label1.Text = "Welcome to Byte Better";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(96, 96, 96);
            label2.Location = new Point(0, 255);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(860, 32);
            label2.TabIndex = 2;
            label2.Text = "Tutoring and Academic Support  ·  Smarter learning, brighter futures";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(31, 56, 100);
            label3.Location = new Point(0, 311);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(860, 38);
            label3.TabIndex = 3;
            label3.Text = "How would you like to continue?";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblRoles
            // 
            tblRoles.Anchor = AnchorStyles.None;
            tblRoles.BackColor = Color.Transparent;
            tblRoles.ColumnCount = 5;
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            tblRoles.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tblRoles.Controls.Add(btnStudent, 0, 0);
            tblRoles.Controls.Add(btnTutor, 2, 0);
            tblRoles.Controls.Add(btnAdministrator, 4, 0);
            tblRoles.Location = new Point(72, 359);
            tblRoles.Margin = new Padding(0);
            tblRoles.Name = "tblRoles";
            tblRoles.RowCount = 1;
            tblRoles.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tblRoles.Size = new Size(716, 120);
            tblRoles.TabIndex = 4;
            // 
            // btnStudent
            // 
            btnStudent.BackColor = SystemColors.HotTrack;
            btnStudent.Cursor = Cursors.Hand;
            btnStudent.Dock = DockStyle.Fill;
            btnStudent.FlatAppearance.BorderSize = 0;
            btnStudent.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnStudent.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnStudent.FlatStyle = FlatStyle.Popup;
            btnStudent.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            btnStudent.ForeColor = Color.White;
            btnStudent.Location = new Point(0, 0);
            btnStudent.Margin = new Padding(0);
            btnStudent.Name = "btnStudent";
            btnStudent.Size = new Size(220, 120);
            btnStudent.TabIndex = 0;
            btnStudent.Text = "&Student";
            btnStudent.UseVisualStyleBackColor = false;
            btnStudent.Click += btnStudent_Click;
            // 
            // btnTutor
            // 
            btnTutor.BackColor = SystemColors.HotTrack;
            btnTutor.Cursor = Cursors.Hand;
            btnTutor.Dock = DockStyle.Fill;
            btnTutor.FlatAppearance.BorderSize = 0;
            btnTutor.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnTutor.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnTutor.FlatStyle = FlatStyle.Popup;
            btnTutor.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            btnTutor.ForeColor = Color.White;
            btnTutor.Location = new Point(248, 0);
            btnTutor.Margin = new Padding(0);
            btnTutor.Name = "btnTutor";
            btnTutor.Size = new Size(220, 120);
            btnTutor.TabIndex = 1;
            btnTutor.Text = "&Tutor";
            btnTutor.UseVisualStyleBackColor = false;
            btnTutor.Click += btnTutor_Click;
            // 
            // btnAdministrator
            // 
            btnAdministrator.BackColor = SystemColors.HotTrack;
            btnAdministrator.Cursor = Cursors.Hand;
            btnAdministrator.Dock = DockStyle.Fill;
            btnAdministrator.FlatAppearance.BorderSize = 0;
            btnAdministrator.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnAdministrator.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnAdministrator.FlatStyle = FlatStyle.Popup;
            btnAdministrator.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            btnAdministrator.ForeColor = Color.White;
            btnAdministrator.Location = new Point(496, 0);
            btnAdministrator.Margin = new Padding(0);
            btnAdministrator.Name = "btnAdministrator";
            btnAdministrator.Size = new Size(220, 120);
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
            btnExit.ForeColor = Color.FromArgb(64, 64, 64);
            btnExit.Location = new Point(751, 548);
            btnExit.Margin = new Padding(0, 0, 24, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(85, 44);
            btnExit.TabIndex = 5;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // picLogo
            // 
            picLogo.AccessibleName = "Byte Better logo";
            picLogo.Anchor = AnchorStyles.None;
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(352, 51);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(155, 117);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(860, 600);
            Controls.Add(tblLayout);
            DoubleBuffered = true;
            MinimumSize = new Size(800, 640);
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Byte Better - Tutoring and Academic Support";
            tblLayout.ResumeLayout(false);
            tblRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
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

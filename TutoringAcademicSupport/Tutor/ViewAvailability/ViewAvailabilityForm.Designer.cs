namespace TutoringAcademicSupport.Tutor
{
    partial class ViewAvailabilityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAvailabilityForm));
            tblLayout = new TableLayoutPanel();
            picLogo = new PictureBox();
            label1 = new Label();
            lblTutorMessage = new Label();
            lblPrompt = new Label();
            btnUpdate = new Button();
            btnReturn = new Button();
            tblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // tblLayout
            // 
            tblLayout.BackColor = Color.White;
            tblLayout.BackgroundImage = (Image)resources.GetObject("tblLayout.BackgroundImage");
            tblLayout.BackgroundImageLayout = ImageLayout.Stretch;
            tblLayout.ColumnCount = 1;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblLayout.Controls.Add(picLogo, 0, 1);
            tblLayout.Controls.Add(label1, 0, 2);
            tblLayout.Controls.Add(lblTutorMessage, 0, 3);
            tblLayout.Controls.Add(lblPrompt, 0, 5);
            tblLayout.Controls.Add(btnUpdate, 0, 6);
            tblLayout.Controls.Add(btnReturn, 0, 8);
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.Location = new Point(0, 0);
            tblLayout.Name = "tblLayout";
            tblLayout.RowCount = 9;
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 119F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 14F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblLayout.Size = new Size(760, 580);
            tblLayout.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.AccessibleName = "Byte Better logo";
            picLogo.Anchor = AnchorStyles.None;
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(316, 82);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(127, 119);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Cooper Black", 25F);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(0, 201);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(760, 46);
            label1.TabIndex = 1;
            label1.Text = "Tutor Menu";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTutorMessage
            // 
            lblTutorMessage.BackColor = Color.Transparent;
            lblTutorMessage.Dock = DockStyle.Fill;
            lblTutorMessage.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblTutorMessage.ForeColor = Color.FromArgb(96, 96, 96);
            lblTutorMessage.Location = new Point(0, 247);
            lblTutorMessage.Margin = new Padding(0);
            lblTutorMessage.Name = "lblTutorMessage";
            lblTutorMessage.Size = new Size(760, 38);
            lblTutorMessage.TabIndex = 2;
            lblTutorMessage.Text = "Welcome";
            lblTutorMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrompt
            // 
            lblPrompt.BackColor = Color.Transparent;
            lblPrompt.Dock = DockStyle.Fill;
            lblPrompt.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrompt.ForeColor = Color.FromArgb(31, 56, 100);
            lblPrompt.Location = new Point(0, 299);
            lblPrompt.Margin = new Padding(0);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(760, 38);
            lblPrompt.TabIndex = 3;
            lblPrompt.Text = "What would you like to do?";
            lblPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.None;
            btnUpdate.BackColor = SystemColors.HotTrack;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(230, 343);
            btnUpdate.Margin = new Padding(0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(300, 88);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "My &Availability";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Right;
            btnReturn.BackColor = Color.White;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnReturn.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 228, 235);
            btnReturn.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 242, 246);
            btnReturn.ForeColor = Color.FromArgb(64, 64, 64);
            btnReturn.Location = new Point(596, 527);
            btnReturn.Margin = new Padding(0, 0, 24, 0);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(140, 44);
            btnReturn.TabIndex = 5;
            btnReturn.Text = "&Log Out";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // ViewAvailabilityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 580);
            Controls.Add(tblLayout);
            MinimumSize = new Size(700, 600);
            Name = "ViewAvailabilityForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tutor Menu";
            tblLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblLayout;
        private PictureBox picLogo;
        private Label label1;
        private Label lblTutorMessage;
        private Label lblPrompt;
        private Button btnUpdate;
        private Button btnReturn;
    }
}

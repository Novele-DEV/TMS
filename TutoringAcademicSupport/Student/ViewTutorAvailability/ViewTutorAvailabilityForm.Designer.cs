namespace TutoringAcademicSupport.Student.ViewTutorAvailability
{
    partial class ViewTutorAvailabilityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTutorAvailabilityForm));
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblTutor = new Label();
            cmbTutor = new ComboBox();
            availabilityGrid = new DataGridView();
            lblMessage = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)availabilityGrid).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Cooper Black", 25F);
            lblTitle.ForeColor = SystemColors.HotTrack;
            lblTitle.Location = new Point(28, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(412, 49);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tutor Availability";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = SystemColors.GrayText;
            lblSubtitle.Location = new Point(28, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(544, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "When each tutor is available during the week. Choose a tutor to see only their times.";
            // 
            // lblTutor
            // 
            lblTutor.AutoSize = true;
            lblTutor.BackColor = Color.Transparent;
            lblTutor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTutor.Location = new Point(28, 103);
            lblTutor.Name = "lblTutor";
            lblTutor.Size = new Size(52, 20);
            lblTutor.TabIndex = 2;
            lblTutor.Text = "&Tutor:";
            // 
            // cmbTutor
            // 
            cmbTutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTutor.Location = new Point(90, 99);
            cmbTutor.Name = "cmbTutor";
            cmbTutor.Size = new Size(300, 28);
            cmbTutor.TabIndex = 3;
            cmbTutor.SelectedIndexChanged += cmbTutor_SelectedIndexChanged;
            // 
            // availabilityGrid
            // 
            availabilityGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            availabilityGrid.BackgroundColor = SystemColors.ActiveCaption;
            availabilityGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            availabilityGrid.Location = new Point(28, 142);
            availabilityGrid.Name = "availabilityGrid";
            availabilityGrid.RowHeadersWidth = 51;
            availabilityGrid.Size = new Size(804, 330);
            availabilityGrid.TabIndex = 4;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Location = new Point(28, 482);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(640, 48);
            lblMessage.TabIndex = 5;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBack.ForeColor = Color.FromArgb(64, 64, 64);
            btnBack.Location = new Point(692, 486);
            btnBack.Location = new Point(28, 482);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 44);
            btnBack.TabIndex = 6;
            btnBack.Text = "&Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ViewTutorAvailabilityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnBack;
            ClientSize = new Size(860, 550);
            Controls.Add(btnBack);
            Controls.Add(lblMessage);
            Controls.Add(availabilityGrid);
            Controls.Add(cmbTutor);
            Controls.Add(lblTutor);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            MinimumSize = new Size(700, 480);
            Name = "ViewTutorAvailabilityForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tutor Availability";
            Load += ViewTutorAvailabilityForm_Load;
            ((System.ComponentModel.ISupportInitialize)availabilityGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblTutor;
        private ComboBox cmbTutor;
        private DataGridView availabilityGrid;
        private Label lblMessage;
        private Button btnBack;
    }
}

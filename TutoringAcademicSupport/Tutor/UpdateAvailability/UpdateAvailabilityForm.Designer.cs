namespace TutoringAcademicSupport.Tutor.UpdateAvailability
{
    partial class UpdateAvailabilityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAvailabilityForm));
            label1 = new Label();
            lblSubtitle = new Label();
            lblTutorId = new Label();
            txtTutorId = new TextBox();
            btnLoad = new Button();
            availabilityGrid = new DataGridView();
            grpSlot = new GroupBox();
            lblHeading = new Label();
            cmbAvailDay = new ComboBox();
            label2 = new Label();
            dtpStartTime = new DateTimePicker();
            label3 = new Label();
            dtpEndTime = new DateTimePicker();
            btnSave = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            lblMessage = new Label();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)availabilityGrid).BeginInit();
            grpSlot.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cooper Black", 25F);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(28, 11);
            label1.Name = "label1";
            label1.Size = new Size(412, 49);
            label1.TabIndex = 0;
            label1.Text = "Tutor Availability";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = SystemColors.GrayText;
            lblSubtitle.Location = new Point(37, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(519, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Weekly time slots when the tutor is available. Select a slot to change or delete it.";
            // 
            // lblTutorId
            // 
            lblTutorId.AutoSize = true;
            lblTutorId.BackColor = Color.Transparent;
            lblTutorId.Location = new Point(28, 103);
            lblTutorId.Name = "lblTutorId";
            lblTutorId.Size = new Size(66, 20);
            lblTutorId.TabIndex = 2;
            lblTutorId.Text = "Tutor &ID:";
            // 
            // txtTutorId
            // 
            txtTutorId.Location = new Point(110, 99);
            txtTutorId.MaxLength = 8;
            txtTutorId.Name = "txtTutorId";
            txtTutorId.PlaceholderText = "TUT00001";
            txtTutorId.Size = new Size(140, 27);
            txtTutorId.TabIndex = 3;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = SystemColors.ActiveCaption;
            btnLoad.Location = new Point(488, 92);
            // 
            btnLoad.Location = new Point(262, 96);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(100, 34);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "&Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // availabilityGrid
            // 
            availabilityGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            availabilityGrid.BackgroundColor = SystemColors.ActiveCaption;
            availabilityGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            availabilityGrid.Location = new Point(28, 145);
            availabilityGrid.Name = "availabilityGrid";
            availabilityGrid.RowHeadersWidth = 51;
            availabilityGrid.Size = new Size(560, 330);
            availabilityGrid.TabIndex = 5;
            availabilityGrid.CellClick += availabilityGrid_CellClick;
            availabilityGrid.SelectionChanged += availabilityGrid_SelectionChanged;
            // 
            // grpSlot
            // 
            grpSlot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpSlot.BackColor = Color.Transparent;
            grpSlot.Controls.Add(lblHeading);
            grpSlot.Controls.Add(cmbAvailDay);
            grpSlot.Controls.Add(label2);
            grpSlot.Controls.Add(dtpStartTime);
            grpSlot.Controls.Add(label3);
            grpSlot.Controls.Add(dtpEndTime);
            grpSlot.Controls.Add(btnSave);
            grpSlot.Controls.Add(btnClear);
            grpSlot.Controls.Add(btnDelete);
            grpSlot.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpSlot.Location = new Point(612, 140);
            grpSlot.Name = "grpSlot";
            grpSlot.Size = new Size(360, 335);
            grpSlot.TabIndex = 6;
            grpSlot.TabStop = false;
            grpSlot.Text = "New slot";
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 9F);
            lblHeading.Location = new Point(16, 44);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(38, 20);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Da&y:";
            // 
            // cmbAvailDay
            // 
            cmbAvailDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvailDay.Font = new Font("Segoe UI", 9F);
            cmbAvailDay.Location = new Point(130, 40);
            cmbAvailDay.Name = "cmbAvailDay";
            cmbAvailDay.Size = new Size(200, 28);
            cmbAvailDay.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(16, 94);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 2;
            label2.Text = "&Start time:";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "HH:mm";
            dtpStartTime.Font = new Font("Segoe UI", 9F);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(130, 90);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(120, 27);
            dtpStartTime.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(16, 144);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 4;
            label3.Text = "&End time:";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "HH:mm";
            dtpEndTime.Font = new Font("Segoe UI", 9F);
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(130, 140);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(120, 27);
            dtpEndTime.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Blue;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(16, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 48);
            btnSave.TabIndex = 6;
            btnSave.Text = "&Add Slot";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.ForeColor = Color.Blue;
            btnClear.Location = new Point(184, 200);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(160, 48);
            btnClear.TabIndex = 7;
            btnClear.Text = "&New Slot";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.Black;
            btnDelete.Location = new Point(16, 262);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(328, 48);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "&Delete Slot";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Location = new Point(28, 488);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(944, 40);
            lblMessage.TabIndex = 7;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReturn.FlatAppearance.BorderColor = Color.Silver;
            btnReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReturn.ForeColor = Color.FromArgb(64, 64, 64);
            btnReturn.Location = new Point(812, 576);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(160, 48);
            btnReturn.TabIndex = 8;
            btnReturn.Text = "&Back";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // UpdateAvailabilityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnReturn;
            ClientSize = new Size(1000, 640);
            Controls.Add(btnReturn);
            Controls.Add(lblMessage);
            Controls.Add(grpSlot);
            Controls.Add(availabilityGrid);
            Controls.Add(btnLoad);
            Controls.Add(txtTutorId);
            Controls.Add(lblTutorId);
            Controls.Add(lblSubtitle);
            Controls.Add(label1);
            DoubleBuffered = true;
            MinimumSize = new Size(1018, 658);
            Name = "UpdateAvailabilityForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tutor Availability";
            Load += UpdateAvailabilityForm_Load;
            ((System.ComponentModel.ISupportInitialize)availabilityGrid).EndInit();
            grpSlot.ResumeLayout(false);
            grpSlot.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblSubtitle;
        private Label lblTutorId;
        private TextBox txtTutorId;
        private Button btnLoad;
        private DataGridView availabilityGrid;
        private GroupBox grpSlot;
        private Label lblHeading;
        private ComboBox cmbAvailDay;
        private Label label2;
        private DateTimePicker dtpStartTime;
        private Label label3;
        private DateTimePicker dtpEndTime;
        private Button btnSave;
        private Button btnClear;
        private Button btnDelete;
        private Label lblMessage;
        private Button btnReturn;
    }
}

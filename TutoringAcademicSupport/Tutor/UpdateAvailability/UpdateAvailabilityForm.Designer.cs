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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            tutorBindingSource = new BindingSource(components);
            label3 = new Label();
            lblHeading = new Label();
            tutorDataGridView = new DataGridView();
            btnReturn = new Button();
            btnClear = new Button();
            btnSave = new Button();
            cmbAvailDay = new ComboBox();
            label2 = new Label();
            lblMessage = new Label();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tutorDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(290, 41);
            label1.TabIndex = 1;
            label1.Text = "Update Availability";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(347, 192);
            label3.Name = "label3";
            label3.Size = new Size(167, 31);
            label3.TabIndex = 3;
            label3.Text = "New End Time";
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblHeading.ForeColor = SystemColors.Highlight;
            lblHeading.Location = new Point(347, 92);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(109, 31);
            lblHeading.TabIndex = 4;
            lblHeading.Text = "New Day";
            // 
            // tutorDataGridView
            // 
            tutorDataGridView.AutoGenerateColumns = false;
            tutorDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tutorDataGridView.DataSource = tutorBindingSource;
            tutorDataGridView.Location = new Point(12, 74);
            tutorDataGridView.Name = "tutorDataGridView";
            tutorDataGridView.RowHeadersWidth = 51;
            tutorDataGridView.Size = new Size(300, 188);
            tutorDataGridView.TabIndex = 5;
            // 
            // btnReturn
            // 
            btnReturn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnReturn.Location = new Point(12, 285);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(110, 51);
            btnReturn.TabIndex = 6;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnClear.Location = new Point(208, 285);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(104, 51);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSave.Location = new Point(602, 259);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 102);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbAvailDay
            // 
            cmbAvailDay.FormattingEnabled = true;
            cmbAvailDay.Items.AddRange(new object[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" });
            cmbAvailDay.Location = new Point(545, 92);
            cmbAvailDay.Name = "cmbAvailDay";
            cmbAvailDay.Size = new Size(151, 28);
            cmbAvailDay.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(347, 148);
            label2.Name = "label2";
            label2.Size = new Size(179, 31);
            label2.TabIndex = 10;
            label2.Text = "New Start Time";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(652, 397);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(18, 20);
            lblMessage.TabIndex = 13;
            lblMessage.Text = "...";
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(545, 152);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowCheckBox = true;
            dtpStartTime.Size = new Size(250, 27);
            dtpStartTime.TabIndex = 14;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(545, 196);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(250, 27);
            dtpEndTime.TabIndex = 15;
            // 
            // UpdateAvailabilityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(lblMessage);
            Controls.Add(label2);
            Controls.Add(cmbAvailDay);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnReturn);
            Controls.Add(tutorDataGridView);
            Controls.Add(lblHeading);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "UpdateAvailabilityForm";
            Text = "UpdateAvailabilityForm";
            Load += UpdateAvailabilityForm_Load;
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tutorDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private BindingSource tutorBindingSource;
        private Label label3;
        private Label lblHeading;
        private DataGridView tutorDataGridView;
        private Button btnReturn;
        private Button btnClear;
        private Button btnSave;
        private ComboBox cmbAvailDay;
        private Label label2;
        private Label lblMessage;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
    }
}
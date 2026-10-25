namespace TutoringManagementSystem
{
    partial class frmUpdateBooking
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
            this.components = new System.ComponentModel.Container();
            this.lblRule = new System.Windows.Forms.Label();
            this.byteBetter_TutoringDataSet = new TutoringManagementSystem.ByteBetter_TutoringDataSet();
            this.byteBetterTutoringDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseTableAdapter = new TutoringManagementSystem.ByteBetter_TutoringDataSetTableAdapters.CourseTableAdapter();
            this.tutorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tutorTableAdapter = new TutoringManagementSystem.ByteBetter_TutoringDataSetTableAdapters.TutorTableAdapter();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSlot = new System.Windows.Forms.Label();
            this.lblTutor = new System.Windows.Forms.Label();
            this.dtpSessionDate = new System.Windows.Forms.DateTimePicker();
            this.cboTimeSlot = new System.Windows.Forms.ComboBox();
            this.cboTutor = new System.Windows.Forms.ComboBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.byteBetter_TutoringDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.byteBetterTutoringDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tutorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRule
            // 
            this.lblRule.AutoSize = true;
            this.lblRule.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRule.Location = new System.Drawing.Point(30, 84);
            this.lblRule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new System.Drawing.Size(22, 17);
            this.lblRule.TabIndex = 0;
            this.lblRule.Text = "lbl";
            // 
            // byteBetter_TutoringDataSet
            // 
            this.byteBetter_TutoringDataSet.DataSetName = "ByteBetter_TutoringDataSet";
            this.byteBetter_TutoringDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // byteBetterTutoringDataSetBindingSource
            // 
            this.byteBetterTutoringDataSetBindingSource.DataSource = this.byteBetter_TutoringDataSet;
            this.byteBetterTutoringDataSetBindingSource.Position = 0;
            this.byteBetterTutoringDataSetBindingSource.CurrentChanged += new System.EventHandler(this.byteBetterTutoringDataSetBindingSource_CurrentChanged);
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataMember = "Course";
            this.courseBindingSource.DataSource = this.byteBetterTutoringDataSetBindingSource;
            // 
            // courseTableAdapter
            // 
            this.courseTableAdapter.ClearBeforeFill = true;
            // 
            // tutorBindingSource
            // 
            this.tutorBindingSource.DataMember = "Tutor";
            this.tutorBindingSource.DataSource = this.byteBetterTutoringDataSetBindingSource;
            // 
            // tutorTableAdapter
            // 
            this.tutorTableAdapter.ClearBeforeFill = true;
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(23, 136);
            this.dgvBookings.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBookings.MultiSelect = false;
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(840, 222);
            this.dgvBookings.TabIndex = 1;
            this.dgvBookings.SelectionChanged += new System.EventHandler(this.dgvBookings_SelectionChanged);
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.lblDate);
            this.GroupBox.Controls.Add(this.lblSlot);
            this.GroupBox.Controls.Add(this.lblTutor);
            this.GroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox.Location = new System.Drawing.Point(23, 377);
            this.GroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox.Size = new System.Drawing.Size(859, 157);
            this.GroupBox.TabIndex = 3;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "New date and time";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 35);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(91, 17);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Session date *";
            // 
            // lblSlot
            // 
            this.lblSlot.AutoSize = true;
            this.lblSlot.Location = new System.Drawing.Point(276, 35);
            this.lblSlot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(70, 17);
            this.lblSlot.TabIndex = 6;
            this.lblSlot.Text = "Time slot *";
            // 
            // lblTutor
            // 
            this.lblTutor.AutoSize = true;
            this.lblTutor.Location = new System.Drawing.Point(463, 35);
            this.lblTutor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTutor.Name = "lblTutor";
            this.lblTutor.Size = new System.Drawing.Size(48, 17);
            this.lblTutor.TabIndex = 8;
            this.lblTutor.Text = "Tutor *";
            // 
            // dtpSessionDate
            // 
            this.dtpSessionDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSessionDate.Location = new System.Drawing.Point(33, 445);
            this.dtpSessionDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpSessionDate.Name = "dtpSessionDate";
            this.dtpSessionDate.Size = new System.Drawing.Size(246, 25);
            this.dtpSessionDate.TabIndex = 5;
            // 
            // cboTimeSlot
            // 
            this.cboTimeSlot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTimeSlot.FormattingEnabled = true;
            this.cboTimeSlot.Location = new System.Drawing.Point(303, 445);
            this.cboTimeSlot.Margin = new System.Windows.Forms.Padding(4);
            this.cboTimeSlot.Name = "cboTimeSlot";
            this.cboTimeSlot.Size = new System.Drawing.Size(140, 25);
            this.cboTimeSlot.TabIndex = 7;
            // 
            // cboTutor
            // 
            this.cboTutor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTutor.FormattingEnabled = true;
            this.cboTutor.Location = new System.Drawing.Point(490, 445);
            this.cboTutor.Margin = new System.Windows.Forms.Padding(4);
            this.cboTutor.Name = "cboTutor";
            this.cboTutor.Size = new System.Drawing.Size(365, 25);
            this.cboTutor.TabIndex = 9;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(23, 539);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(443, 30);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "label1";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(23, 602);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(117, 42);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(747, 602);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 42);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "Update Booking";
            // 
            // frmUpdateBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 655);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cboTutor);
            this.Controls.Add(this.cboTimeSlot);
            this.Controls.Add(this.dtpSessionDate);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.lblRule);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmUpdateBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Booking";
            this.Load += new System.EventHandler(this.frmUpdateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.byteBetter_TutoringDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.byteBetterTutoringDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tutorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRule;
        private System.Windows.Forms.BindingSource byteBetterTutoringDataSetBindingSource;
        private ByteBetter_TutoringDataSet byteBetter_TutoringDataSet;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private ByteBetter_TutoringDataSetTableAdapters.CourseTableAdapter courseTableAdapter;
        private System.Windows.Forms.BindingSource tutorBindingSource;
        private ByteBetter_TutoringDataSetTableAdapters.TutorTableAdapter tutorTableAdapter;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpSessionDate;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.ComboBox cboTimeSlot;
        private System.Windows.Forms.Label lblTutor;
        private System.Windows.Forms.ComboBox cboTutor;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label1;
    }
}


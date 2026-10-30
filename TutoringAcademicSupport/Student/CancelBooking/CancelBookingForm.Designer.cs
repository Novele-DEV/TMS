namespace TutoringAcademicSupport.Student.CancelBooking
{
    partial class CancelBookingForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelBookingForm));
            lblHeading = new Label();
            lblRules = new Label();
            dgvBookings = new DataGridView();
            lblSelected = new Label();
            lblMessage = new Label();
            btnBack = new Button();
            btnCancel = new Button();
            errorProvider = new ErrorProvider(components);
            bookingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookingSource).BeginInit();
            SuspendLayout();
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.BackColor = Color.Transparent;
            lblHeading.Font = new Font("Cooper Black", 25F);
            lblHeading.ForeColor = SystemColors.HotTrack;
            lblHeading.Location = new Point(15, 9);
            lblHeading.Margin = new Padding(4, 0, 4, 0);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(387, 49);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Cancel a Booking";
            // 
            // lblRules
            // 
            lblRules.BackColor = Color.Transparent;
            lblRules.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRules.ForeColor = SystemColors.GrayText;
            lblRules.Location = new Point(15, 72);
            lblRules.Margin = new Padding(4, 0, 4, 0);
            lblRules.Name = "lblRules";
            lblRules.Size = new Size(841, 30);
            lblRules.TabIndex = 1;
            lblRules.Text = "Rule message";
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 242, 242);
            dgvBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 56, 100);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Location = new Point(14, 107);
            dgvBookings.Margin = new Padding(5);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowHeadersWidth = 51;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(840, 265);
            dgvBookings.TabIndex = 2;
            // 
            // lblSelected
            // 
            lblSelected.BackColor = Color.Transparent;
            lblSelected.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSelected.Location = new Point(25, 399);
            lblSelected.Margin = new Padding(4, 0, 4, 0);
            lblSelected.Name = "lblSelected";
            lblSelected.Size = new Size(831, 27);
            lblSelected.TabIndex = 3;
            lblSelected.Text = "Session selected";
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(25, 430);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(817, 48);
            lblMessage.TabIndex = 4;
            lblMessage.Text = "General messages";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.FromArgb(64, 64, 64);
            btnBack.Location = new Point(15, 533);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 44);
            btnBack.TabIndex = 6;
            btnBack.Text = "&Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.HotTrack;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 38, 70);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 82, 140);
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(683, 533);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(173, 44);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel Booking";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancelBooking_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // bookingSource
            // 
            bookingSource.ListChanged += bookingSource_ListChanged;
            bookingSource.PositionChanged += bookingSource_PositionChanged;
            // 
            // CancelBookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnBack;
            ClientSize = new Size(868, 589);
            Controls.Add(btnCancel);
            Controls.Add(btnBack);
            Controls.Add(lblMessage);
            Controls.Add(lblSelected);
            Controls.Add(dgvBookings);
            Controls.Add(lblRules);
            Controls.Add(lblHeading);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "CancelBookingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cancel Booking";
            Load += CancelBooking_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bookingSource;
    }
}

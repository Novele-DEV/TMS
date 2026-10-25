namespace TutoringManagementSystem
{
    partial class frmCancelBooking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblRules = new System.Windows.Forms.Label();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bookingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(20, 14);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(151, 25);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Cancel Booking";
            // 
            // lblRules
            // 
            this.lblRules.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.Location = new System.Drawing.Point(20, 52);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(720, 36);
            this.lblRules.TabIndex = 1;
            this.lblRules.Text = "label1";
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(13, 112);
            this.dgvBookings.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBookings.MultiSelect = false;
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowHeadersVisible = false;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(720, 230);
            this.dgvBookings.TabIndex = 0;
            // 
            // lblSelected
            // 
            this.lblSelected.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(20, 346);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(329, 23);
            this.lblSelected.TabIndex = 3;
            this.lblSelected.Text = "label1";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(20, 384);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(246, 23);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "label1";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(12, 417);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 32);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(632, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel booking";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmCancelBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.lblHeading);
            this.MaximizeBox = false;
            this.Name = "frmCancelBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancel Booking";
            this.Load += new System.EventHandler(this.CancelBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bookingSource;
    }
}

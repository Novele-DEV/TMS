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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            lblTutorMessage = new Label();
            tutorBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            btnUpdate = new Button();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(30, 9);
            label1.Name = "label1";
            label1.Size = new Size(255, 41);
            label1.TabIndex = 2;
            label1.Text = "View Availability";
            // 
            // lblTutorMessage
            // 
            lblTutorMessage.AutoSize = true;
            lblTutorMessage.Location = new Point(30, 59);
            lblTutorMessage.Name = "lblTutorMessage";
            lblTutorMessage.Size = new Size(67, 20);
            lblTutorMessage.TabIndex = 3;
            lblTutorMessage.Text = "Hi Tutor!";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 92);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(312, 188);
            dataGridView1.TabIndex = 4;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.Highlight;
            btnUpdate.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnUpdate.ForeColor = SystemColors.ControlLightLight;
            btnUpdate.Location = new Point(389, 154);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(256, 69);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update Availability";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = SystemColors.Highlight;
            btnReturn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnReturn.ForeColor = SystemColors.ControlLightLight;
            btnReturn.Location = new Point(30, 301);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(130, 61);
            btnReturn.TabIndex = 6;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // ViewAvailabilityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReturn);
            Controls.Add(btnUpdate);
            Controls.Add(dataGridView1);
            Controls.Add(lblTutorMessage);
            Controls.Add(label1);
            Name = "ViewAvailabilityForm";
            Text = "ViewAvailabilityForm";
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblTutorMessage;
        private BindingSource tutorBindingSource;
        private DataGridView dataGridView1;
        private Button btnUpdate;
        private Button btnReturn;
    }
}
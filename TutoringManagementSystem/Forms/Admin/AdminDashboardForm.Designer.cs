namespace Tutoring_Management_System
{
    partial class AdminDashboardForm
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
            bindingSource1 = new BindingSource(components);
            byteBetter_TutoringDataSet = new ByteBetter_TutoringDataSet();
            btnManageTutor = new Button();
            btnGetReport = new Button();
            btnBookTutorial = new Button();
            btnLogOut = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)byteBetter_TutoringDataSet).BeginInit();
            SuspendLayout();
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = byteBetter_TutoringDataSet;
            bindingSource1.Position = 0;
            // 
            // byteBetter_TutoringDataSet
            // 
            byteBetter_TutoringDataSet.DataSetName = "ByteBetter_TutoringDataSet";
            byteBetter_TutoringDataSet.Namespace = "http://tempuri.org/ByteBetter_TutoringDataSet.xsd";
            byteBetter_TutoringDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnManageTutor
            // 
            btnManageTutor.BackColor = SystemColors.Highlight;
            btnManageTutor.Location = new Point(35, 255);
            btnManageTutor.Margin = new Padding(3, 4, 3, 4);
            btnManageTutor.Name = "btnManageTutor";
            btnManageTutor.Size = new Size(146, 82);
            btnManageTutor.TabIndex = 0;
            btnManageTutor.Text = "Manage_Tutors";
            btnManageTutor.UseVisualStyleBackColor = false;
            btnManageTutor.Click += button1_Click;
            // 
            // btnGetReport
            // 
            btnGetReport.BackColor = SystemColors.HotTrack;
            btnGetReport.Location = new Point(225, 255);
            btnGetReport.Margin = new Padding(3, 4, 3, 4);
            btnGetReport.Name = "btnGetReport";
            btnGetReport.Size = new Size(139, 82);
            btnGetReport.TabIndex = 1;
            btnGetReport.Text = "Get_Report";
            btnGetReport.UseVisualStyleBackColor = false;
            btnGetReport.Click += btnGetReport_Click;
            // 
            // btnBookTutorial
            // 
            btnBookTutorial.BackColor = SystemColors.HotTrack;
            btnBookTutorial.Location = new Point(415, 255);
            btnBookTutorial.Margin = new Padding(3, 4, 3, 4);
            btnBookTutorial.Name = "btnBookTutorial";
            btnBookTutorial.Size = new Size(146, 82);
            btnBookTutorial.TabIndex = 2;
            btnBookTutorial.Text = "Book Tutorial";
            btnBookTutorial.UseVisualStyleBackColor = false;
            btnBookTutorial.Click += btnBookTutorial_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = SystemColors.HotTrack;
            btnLogOut.Location = new Point(605, 255);
            btnLogOut.Margin = new Padding(3, 4, 3, 4);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(146, 82);
            btnLogOut.TabIndex = 3;
            btnLogOut.Text = "Logout";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Highlight;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(190, 61);
            label1.Name = "label1";
            label1.Size = new Size(416, 39);
            label1.TabIndex = 3;
            label1.Text = "Administrator Dashboard";
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 562);
            Controls.Add(label1);
            Controls.Add(btnLogOut);
            Controls.Add(btnBookTutorial);
            Controls.Add(btnGetReport);
            Controls.Add(btnManageTutor);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminDashboard";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)byteBetter_TutoringDataSet).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private ByteBetter_TutoringDataSet byteBetter_TutoringDataSet;
        private System.Windows.Forms.Button btnManageTutor;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.Button btnBookTutorial;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label1;
    }
}

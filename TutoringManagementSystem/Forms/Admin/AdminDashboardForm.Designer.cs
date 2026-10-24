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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.byteBetter_TutoringDataSet = new Tutoring_Management_System.ByteBetter_TutoringDataSet();
            this.btnManageTutor = new System.Windows.Forms.Button();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.btnBookTutorial = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.byteBetter_TutoringDataSet)).BeginInit();
            this.SuspendLayout();
            //
            // bindingSource1
            //
            this.bindingSource1.DataSource = this.byteBetter_TutoringDataSet;
            this.bindingSource1.Position = 0;
            //
            // byteBetter_TutoringDataSet
            //
            this.byteBetter_TutoringDataSet.DataSetName = "ByteBetter_TutoringDataSet";
            this.byteBetter_TutoringDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            //
            // btnManageTutor
            //
            this.btnManageTutor.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnManageTutor.Location = new System.Drawing.Point(35, 204);
            this.btnManageTutor.Name = "btnManageTutor";
            this.btnManageTutor.Size = new System.Drawing.Size(146, 66);
            this.btnManageTutor.TabIndex = 0;
            this.btnManageTutor.Text = "Manage_Tutors";
            this.btnManageTutor.UseVisualStyleBackColor = false;
            this.btnManageTutor.Click += new System.EventHandler(this.button1_Click);
            //
            // btnGetReport
            //
            this.btnGetReport.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnGetReport.Location = new System.Drawing.Point(225, 204);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(139, 66);
            this.btnGetReport.TabIndex = 1;
            this.btnGetReport.Text = "Get_Report";
            this.btnGetReport.UseVisualStyleBackColor = false;
            //
            // btnBookTutorial
            //
            this.btnBookTutorial.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBookTutorial.Location = new System.Drawing.Point(415, 204);
            this.btnBookTutorial.Name = "btnBookTutorial";
            this.btnBookTutorial.Size = new System.Drawing.Size(146, 66);
            this.btnBookTutorial.TabIndex = 2;
            this.btnBookTutorial.Text = "Book Tutorial";
            this.btnBookTutorial.UseVisualStyleBackColor = false;
            this.btnBookTutorial.Click += new System.EventHandler(this.btnBookTutorial_Click);
            //
            // btnLogOut
            //
            this.btnLogOut.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLogOut.Location = new System.Drawing.Point(605, 204);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(146, 66);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.button3_Click);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(190, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Administrator Dashboard";
            //
            // AdminDashboardForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnBookTutorial);
            this.Controls.Add(this.btnGetReport);
            this.Controls.Add(this.btnManageTutor);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.byteBetter_TutoringDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

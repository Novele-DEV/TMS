namespace TutoringAcademicSupport.Admin.Reports
{
    partial class ReportGenerationForm
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
            lblTitle = new Label();
            lblIntro = new Label();
            btnAgedRequests = new Button();
            btnTutorWorkload = new Button();
            btnCourseDemand = new Button();
            btnReturn = new Button();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = SystemColors.HotTrack;
            lblTitle.Location = new Point(255, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(290, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Generate Reports";
            //
            // lblIntro
            //
            lblIntro.AutoSize = true;
            lblIntro.Location = new Point(240, 78);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(320, 20);
            lblIntro.TabIndex = 1;
            lblIntro.Text = "Choose the report you want to generate.";
            //
            // btnAgedRequests
            //
            btnAgedRequests.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAgedRequests.Location = new Point(175, 120);
            btnAgedRequests.Name = "btnAgedRequests";
            btnAgedRequests.Size = new Size(450, 55);
            btnAgedRequests.TabIndex = 2;
            btnAgedRequests.Text = "Aged Submitted Requests (7+ Days)";
            btnAgedRequests.UseVisualStyleBackColor = true;
            btnAgedRequests.Click += btnAgedRequests_Click;
            //
            // btnTutorWorkload
            //
            btnTutorWorkload.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTutorWorkload.Location = new Point(175, 190);
            btnTutorWorkload.Name = "btnTutorWorkload";
            btnTutorWorkload.Size = new Size(450, 55);
            btnTutorWorkload.TabIndex = 3;
            btnTutorWorkload.Text = "Tutor Workload by Period";
            btnTutorWorkload.UseVisualStyleBackColor = true;
            btnTutorWorkload.Click += btnTutorWorkload_Click;
            //
            // btnCourseDemand
            //
            btnCourseDemand.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCourseDemand.Location = new Point(175, 260);
            btnCourseDemand.Name = "btnCourseDemand";
            btnCourseDemand.Size = new Size(450, 55);
            btnCourseDemand.TabIndex = 4;
            btnCourseDemand.Text = "Course Support Demand and Tutor Coverage";
            btnCourseDemand.UseVisualStyleBackColor = true;
            btnCourseDemand.Click += btnCourseDemand_Click;
            //
            // btnReturn
            //
            btnReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReturn.Location = new Point(310, 360);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(180, 50);
            btnReturn.TabIndex = 5;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            //
            // ReportGenerationForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReturn);
            Controls.Add(btnCourseDemand);
            Controls.Add(btnTutorWorkload);
            Controls.Add(btnAgedRequests);
            Controls.Add(lblIntro);
            Controls.Add(lblTitle);
            Name = "ReportGenerationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Generate Reports";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblIntro;
        private Button btnAgedRequests;
        private Button btnTutorWorkload;
        private Button btnCourseDemand;
        private Button btnReturn;
    }
}

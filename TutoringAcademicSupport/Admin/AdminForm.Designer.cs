namespace TutoringAcademicSupport.Admin
{
    partial class AdminForm
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
            tutorDataGridView = new DataGridView();
            tutorBindingSource = new BindingSource(components);
            btnAddTutor = new Button();
            btnEdit = new Button();
            btnReturn = new Button();
            label1 = new Label();
            btnGenerateReports = new Button();
            btnUpdateAvailability = new Button();
            ((System.ComponentModel.ISupportInitialize)tutorDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tutorDataGridView
            // 
            tutorDataGridView.AutoGenerateColumns = false;
            tutorDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tutorDataGridView.DataSource = tutorBindingSource;
            tutorDataGridView.Location = new Point(138, 93);
            tutorDataGridView.Name = "tutorDataGridView";
            tutorDataGridView.RowHeadersWidth = 51;
            tutorDataGridView.Size = new Size(503, 219);
            tutorDataGridView.TabIndex = 1;
            // 
            // btnAddTutor
            // 
            btnAddTutor.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnAddTutor.Location = new Point(30, 359);
            btnAddTutor.Name = "btnAddTutor";
            btnAddTutor.Size = new Size(198, 54);
            btnAddTutor.TabIndex = 2;
            btnAddTutor.Text = "Add Tutor";
            btnAddTutor.UseVisualStyleBackColor = true;
            btnAddTutor.Click += btnAddTutor_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnEdit.Location = new Point(274, 358);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(205, 55);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit Selected";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnReturn
            // 
            btnReturn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnReturn.Location = new Point(274, 469);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(186, 50);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(247, 29);
            label1.Name = "label1";
            label1.Size = new Size(273, 41);
            label1.TabIndex = 5;
            label1.Text = "Admin Dashboard";
            // 
            // btnGenerateReports
            // 
            btnGenerateReports.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnGenerateReports.Location = new Point(530, 358);
            btnGenerateReports.Name = "btnGenerateReports";
            btnGenerateReports.Size = new Size(258, 55);
            btnGenerateReports.TabIndex = 6;
            btnGenerateReports.Text = "Generate Reports";
            btnGenerateReports.UseVisualStyleBackColor = true;
            btnGenerateReports.Click += btnGenerateReports_Click;
            //
            // btnUpdateAvailability
            //
            btnUpdateAvailability.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnUpdateAvailability.Location = new Point(530, 430);
            btnUpdateAvailability.Name = "btnUpdateAvailability";
            btnUpdateAvailability.Size = new Size(258, 55);
            btnUpdateAvailability.TabIndex = 7;
            btnUpdateAvailability.Text = "Tutor Availability";
            btnUpdateAvailability.UseVisualStyleBackColor = true;
            btnUpdateAvailability.Click += btnUpdateAvailability_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 602);
            Controls.Add(btnGenerateReports);
            Controls.Add(btnUpdateAvailability);
            Controls.Add(label1);
            Controls.Add(btnReturn);
            Controls.Add(btnEdit);
            Controls.Add(btnAddTutor);
            Controls.Add(tutorDataGridView);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)tutorDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tutorDataGridView;
        private BindingSource tutorBindingSource;
        private Button btnAddTutor;
        private Button btnEdit;
        private Button btnReturn;
        private Label label1;
        private Button btnGenerateReports;
        private Button btnUpdateAvailability;
    }
}
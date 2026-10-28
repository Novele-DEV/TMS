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
            ((System.ComponentModel.ISupportInitialize)tutorDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tutorDataGridView
            // 
            tutorDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tutorDataGridView.Location = new Point(138, 93);
            tutorDataGridView.Name = "tutorDataGridView";
            tutorDataGridView.RowHeadersWidth = 51;
            tutorDataGridView.Size = new Size(503, 219);
            tutorDataGridView.TabIndex = 1;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tutorDataGridView);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)tutorDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)tutorBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tutorDataGridView;
        private BindingSource tutorBindingSource;
    }
}
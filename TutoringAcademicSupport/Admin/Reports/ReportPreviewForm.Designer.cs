namespace TutoringAcademicSupport.Admin.Reports
{
    partial class ReportPreviewForm
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
            pnlToolbar = new Panel();
            btnPrint = new Button();
            btnPrevious = new Button();
            lblPage = new Label();
            btnNext = new Button();
            lblZoom = new Label();
            cmbZoom = new ComboBox();
            btnClose = new Button();
            previewControl = new PrintPreviewControl();
            pnlToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = SystemColors.ButtonHighlight;
            pnlToolbar.Controls.Add(btnPrint);
            pnlToolbar.Controls.Add(btnPrevious);
            pnlToolbar.Controls.Add(lblPage);
            pnlToolbar.Controls.Add(btnNext);
            pnlToolbar.Controls.Add(lblZoom);
            pnlToolbar.Controls.Add(cmbZoom);
            pnlToolbar.Controls.Add(btnClose);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1100, 54);
            pnlToolbar.TabIndex = 0;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.DarkBlue;
            btnPrint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(12, 9);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(120, 36);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "&Print...";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(160, 9);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(130, 36);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "◀  Pre&vious page";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // lblPage
            // 
            lblPage.Location = new Point(295, 9);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(120, 36);
            lblPage.TabIndex = 2;
            lblPage.Text = "Page 1 of 1";
            lblPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(420, 9);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(130, 36);
            btnNext.TabIndex = 3;
            btnNext.Text = "&Next page  ▶";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblZoom
            // 
            lblZoom.AutoSize = true;
            lblZoom.Location = new Point(580, 17);
            lblZoom.Name = "lblZoom";
            lblZoom.Size = new Size(52, 20);
            lblZoom.TabIndex = 4;
            lblZoom.Text = "&Zoom:";
            // 
            // cmbZoom
            // 
            cmbZoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZoom.Location = new Point(635, 13);
            cmbZoom.Name = "cmbZoom";
            cmbZoom.Size = new Size(140, 28);
            cmbZoom.TabIndex = 5;
            cmbZoom.SelectedIndexChanged += cmbZoom_SelectedIndexChanged;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.ForeColor = Color.FromArgb(64, 64, 64);
            btnClose.Location = new Point(968, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 36);
            btnClose.TabIndex = 6;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // previewControl
            // 
            previewControl.BackColor = SystemColors.InactiveCaption;
            previewControl.Dock = DockStyle.Fill;
            previewControl.Location = new Point(0, 54);
            previewControl.Name = "previewControl";
            previewControl.Size = new Size(1100, 696);
            previewControl.TabIndex = 1;
            previewControl.StartPageChanged += previewControl_StartPageChanged;
            // 
            // ReportPreviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(1100, 750);
            Controls.Add(previewControl);
            Controls.Add(pnlToolbar);
            MinimumSize = new Size(800, 500);
            Name = "ReportPreviewForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Print Preview";
            WindowState = FormWindowState.Maximized;
            FormClosed += ReportPreviewForm_FormClosed;
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlToolbar;
        private Button btnPrint;
        private Button btnPrevious;
        private Label lblPage;
        private Button btnNext;
        private Label lblZoom;
        private ComboBox cmbZoom;
        private Button btnClose;
        private PrintPreviewControl previewControl;
    }
}

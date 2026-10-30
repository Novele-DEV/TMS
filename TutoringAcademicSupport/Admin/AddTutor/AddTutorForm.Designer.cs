namespace TutoringAcademicSupport.Admin.AddTutor;

partial class AddTutorForm
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
        lblSubtitle = new Label();
        lblTutorID = new Label();
        txtTutorID = new TextBox();
        lblFirstName = new Label();
        txtTutorFName = new TextBox();
        lblLastName = new Label();
        txtTutorLName = new TextBox();
        lblEmail = new Label();
        txtTutorEmail = new TextBox();
        lblPhone = new Label();
        txtTutorPhoneNo = new TextBox();
        lblAverage = new Label();
        txtAcademicAverage = new TextBox();
        lblMode = new Label();
        cmbPreferredMode = new ComboBox();
        lblCurriculumVitae = new Label();
        txtCurriculumVitae = new TextBox();
        btnBrowseCurriculumVitae = new Button();
        lblStatus = new Label();
        btnAdd = new Button();
        btnClear = new Button();
        btnReturn = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.ForeColor = SystemColors.HotTrack;
        lblTitle.Location = new Point(24, 15);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(161, 41);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Add Tutor";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.ForeColor = SystemColors.GrayText;
        lblSubtitle.Location = new Point(28, 60);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(418, 20);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Enter the tutor's details. The tutor ID is created when you save.";
        // 
        // lblTutorID
        // 
        lblTutorID.AutoSize = true;
        lblTutorID.Location = new Point(28, 108);
        lblTutorID.Name = "lblTutorID";
        lblTutorID.Size = new Size(66, 20);
        lblTutorID.TabIndex = 2;
        lblTutorID.Text = "Tutor ID:";
        // 
        // txtTutorID
        // 
        txtTutorID.Location = new Point(210, 105);
        txtTutorID.Name = "txtTutorID";
        txtTutorID.ReadOnly = true;
        txtTutorID.Size = new Size(400, 27);
        txtTutorID.TabIndex = 3;
        txtTutorID.TabStop = false;
        txtTutorID.Text = "(created when you save)";
        // 
        // lblFirstName
        // 
        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(28, 154);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(80, 20);
        lblFirstName.TabIndex = 4;
        lblFirstName.Text = "$First name:";
        // 
        // txtTutorFName
        // 
        txtTutorFName.Location = new Point(210, 151);
        txtTutorFName.MaxLength = 50;
        txtTutorFName.Name = "txtTutorFName";
        txtTutorFName.Size = new Size(400, 27);
        txtTutorFName.TabIndex = 5;
        // 
        // lblLastName
        // 
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(28, 200);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(79, 20);
        lblLastName.TabIndex = 6;
        lblLastName.Text = "La&st name:";
        // 
        // txtTutorLName
        // 
        txtTutorLName.Location = new Point(210, 197);
        txtTutorLName.MaxLength = 50;
        txtTutorLName.Name = "txtTutorLName";
        txtTutorLName.Size = new Size(400, 27);
        txtTutorLName.TabIndex = 7;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(28, 246);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(49, 20);
        lblEmail.TabIndex = 8;
        lblEmail.Text = "E$mail:";
        // 
        // txtTutorEmail
        // 
        txtTutorEmail.Location = new Point(210, 243);
        txtTutorEmail.MaxLength = 100;
        txtTutorEmail.Name = "txtTutorEmail";
        txtTutorEmail.PlaceholderText = "name@example.com";
        txtTutorEmail.Size = new Size(400, 27);
        txtTutorEmail.TabIndex = 9;
        // 
        // lblPhone
        // 
        lblPhone.AutoSize = true;
        lblPhone.Location = new Point(28, 292);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(53, 20);
        lblPhone.TabIndex = 10;
        lblPhone.Text = "&Phone:";
        // 
        // txtTutorPhoneNo
        // 
        txtTutorPhoneNo.Location = new Point(210, 289);
        txtTutorPhoneNo.MaxLength = 12;
        txtTutorPhoneNo.Name = "txtTutorPhoneNo";
        txtTutorPhoneNo.PlaceholderText = "+27821234567";
        txtTutorPhoneNo.Size = new Size(400, 27);
        txtTutorPhoneNo.TabIndex = 11;
        // 
        // lblAverage
        // 
        lblAverage.AutoSize = true;
        lblAverage.Location = new Point(28, 338);
        lblAverage.Name = "lblAverage";
        lblAverage.Size = new Size(135, 20);
        lblAverage.TabIndex = 12;
        lblAverage.Text = "Academic a&verage:";
        // 
        // txtAcademicAverage
        // 
        txtAcademicAverage.Location = new Point(210, 335);
        txtAcademicAverage.Name = "txtAcademicAverage";
        txtAcademicAverage.PlaceholderText = "Optional, 0 to 100";
        txtAcademicAverage.Size = new Size(400, 27);
        txtAcademicAverage.TabIndex = 13;
        // 
        // lblMode
        // 
        lblMode.AutoSize = true;
        lblMode.Location = new Point(28, 384);
        lblMode.Name = "lblMode";
        lblMode.Size = new Size(116, 20);
        lblMode.TabIndex = 14;
        lblMode.Text = "Preferred m&ode:";
        // 
        // cmbPreferredMode
        // 
        cmbPreferredMode.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPreferredMode.Items.AddRange(new object[] { "Virtual", "In-person", "Both" });
        cmbPreferredMode.Location = new Point(210, 381);
        cmbPreferredMode.Name = "cmbPreferredMode";
        cmbPreferredMode.Size = new Size(200, 28);
        cmbPreferredMode.TabIndex = 15;
        // 
        // lblCurriculumVitae
        //
        lblCurriculumVitae.AutoSize = true;
        lblCurriculumVitae.Location = new Point(28, 430);
        lblCurriculumVitae.Name = "lblCurriculumVitae";
        lblCurriculumVitae.Size = new Size(124, 20);
        lblCurriculumVitae.TabIndex = 16;
        lblCurriculumVitae.Text = "&Curriculum Vitae";
        //
        // txtCurriculumVitae
        //
        txtCurriculumVitae.Location = new Point(210, 427);
        txtCurriculumVitae.Name = "txtCurriculumVitae";
        txtCurriculumVitae.ReadOnly = true;
        txtCurriculumVitae.Size = new Size(300, 27);
        txtCurriculumVitae.TabIndex = 17;
        txtCurriculumVitae.TabStop = false;
        //
        // btnBrowseCurriculumVitae
        //
        btnBrowseCurriculumVitae.Location = new Point(520, 426);
        btnBrowseCurriculumVitae.Name = "btnBrowseCurriculumVitae";
        btnBrowseCurriculumVitae.Size = new Size(90, 29);
        btnBrowseCurriculumVitae.TabIndex = 18;
        btnBrowseCurriculumVitae.Text = "Browse...";
        btnBrowseCurriculumVitae.UseVisualStyleBackColor = true;
        btnBrowseCurriculumVitae.Click += btnBrowseCurriculumVitae_Click;
        //
        // lblStatus
        // 
        lblStatus.Location = new Point(28, 466);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(582, 48);
        lblStatus.TabIndex = 19;
        // 
        // btnAdd
        // 
        btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btnAdd.Location = new Point(420, 515);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(190, 86);
        btnAdd.TabIndex = 20;
        btnAdd.Text = "&Add Tutor";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnClear
        // 
        btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btnClear.Location = new Point(179, 553);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(170, 48);
        btnClear.TabIndex = 21;
        btnClear.Text = "&Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        // 
        // btnReturn
        // 
        btnReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btnReturn.Location = new Point(3, 553);
        btnReturn.Name = "btnReturn";
        btnReturn.Size = new Size(170, 48);
        btnReturn.TabIndex = 22;
        btnReturn.Text = "&Back";
        btnReturn.UseVisualStyleBackColor = true;
        btnReturn.Click += btnReturn_Click;
        // 
        // AddTutorForm
        // 
        AcceptButton = btnAdd;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnReturn;
        ClientSize = new Size(640, 630);
        Controls.Add(btnReturn);
        Controls.Add(btnClear);
        Controls.Add(btnAdd);
        Controls.Add(lblStatus);
        Controls.Add(btnBrowseCurriculumVitae);
        Controls.Add(txtCurriculumVitae);
        Controls.Add(lblCurriculumVitae);
        Controls.Add(cmbPreferredMode);
        Controls.Add(lblMode);
        Controls.Add(txtAcademicAverage);
        Controls.Add(lblAverage);
        Controls.Add(txtTutorPhoneNo);
        Controls.Add(lblPhone);
        Controls.Add(txtTutorEmail);
        Controls.Add(lblEmail);
        Controls.Add(txtTutorLName);
        Controls.Add(lblLastName);
        Controls.Add(txtTutorFName);
        Controls.Add(lblFirstName);
        Controls.Add(txtTutorID);
        Controls.Add(lblTutorID);
        Controls.Add(lblSubtitle);
        Controls.Add(lblTitle);
        Name = "AddTutorForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add Tutor";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblTutorID;
    private TextBox txtTutorID;
    private Label lblFirstName;
    private TextBox txtTutorFName;
    private Label lblLastName;
    private TextBox txtTutorLName;
    private Label lblEmail;
    private TextBox txtTutorEmail;
    private Label lblPhone;
    private TextBox txtTutorPhoneNo;
    private Label lblAverage;
    private TextBox txtAcademicAverage;
    private Label lblMode;
    private ComboBox cmbPreferredMode;
    private Label lblCurriculumVitae;
    private TextBox txtCurriculumVitae;
    private Button btnBrowseCurriculumVitae;
    private Label lblStatus;
    private Button btnAdd;
    private Button btnClear;
    private Button btnReturn;
}

using System.Drawing;
using System.Windows.Forms;

namespace TutoringAcademicSupport.Admin.AddTutor;

partial class AddTutorForm
{
    private System.ComponentModel.IContainer? components;

    private Label label1 = null!;
    private Label label2 = null!;
    private Label label3 = null!;
    private Label label4 = null!;
    private Label label5 = null!;
    private Label label6 = null!;
    private Label label7 = null!;
    private Label label8 = null!;

    private TextBox txtTutorID = null!;
    private TextBox txtTutorPhoneNo = null!;
    private TextBox txtTutorEmail = null!;
    private TextBox txtTutorLName = null!;
    private TextBox txtTutorFName = null!;
    private TextBox txtAcademicAverage = null!;

    private ComboBox cmbPreferredMode = null!;

    private Button btnReturn = null!;
    private Button btnClear = null!;
    private Button btnAdd = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        label6 = new Label();
        label7 = new Label();
        label8 = new Label();
        txtTutorID = new TextBox();
        txtTutorPhoneNo = new TextBox();
        txtTutorEmail = new TextBox();
        txtTutorLName = new TextBox();
        txtTutorFName = new TextBox();
        txtAcademicAverage = new TextBox();
        cmbPreferredMode = new ComboBox();
        btnReturn = new Button();
        btnClear = new Button();
        btnAdd = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        label1.ForeColor = SystemColors.HotTrack;
        label1.Location = new Point(310, 25);
        label1.Name = "label1";
        label1.Size = new Size(129, 32);
        label1.TabIndex = 0;
        label1.Text = "Add Tutor";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
        label2.ForeColor = SystemColors.HotTrack;
        label2.Location = new Point(90, 365);
        label2.Name = "label2";
        label2.Size = new Size(210, 31);
        label2.TabIndex = 1;
        label2.Text = "Academic Average";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
        label3.ForeColor = SystemColors.HotTrack;
        label3.Location = new Point(90, 420);
        label3.Name = "label3";
        label3.Size = new Size(182, 31);
        label3.TabIndex = 2;
        label3.Text = "Preferred Mode";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
        label4.ForeColor = SystemColors.HotTrack;
        label4.Location = new Point(90, 310);
        label4.Name = "label4";
        label4.Size = new Size(176, 31);
        label4.TabIndex = 3;
        label4.Text = "Phone Number";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
        label5.ForeColor = SystemColors.HotTrack;
        label5.Location = new Point(90, 255);
        label5.Name = "label5";
        label5.Size = new Size(73, 31);
        label5.TabIndex = 4;
        label5.Text = "Email";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
        label6.ForeColor = SystemColors.HotTrack;
        label6.Location = new Point(90, 200);
        label6.Name = "label6";
        label6.Size = new Size(126, 31);
        label6.TabIndex = 5;
        label6.Text = "Last Name";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
        label7.ForeColor = SystemColors.HotTrack;
        label7.Location = new Point(90, 145);
        label7.Name = "label7";
        label7.Size = new Size(130, 31);
        label7.TabIndex = 6;
        label7.Text = "First Name";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
        label8.ForeColor = SystemColors.HotTrack;
        label8.Location = new Point(90, 90);
        label8.Name = "label8";
        label8.Size = new Size(101, 31);
        label8.TabIndex = 7;
        label8.Text = "Tutor ID";
        // 
        // txtTutorID
        // 
        txtTutorID.Location = new Point(310, 90);
        txtTutorID.Name = "txtTutorID";
        txtTutorID.ReadOnly = true;
        txtTutorID.Size = new Size(190, 27);
        txtTutorID.TabIndex = 8;
        txtTutorID.Text = "(auto-generated by system)";
        // 
        // txtTutorPhoneNo
        // 
        txtTutorPhoneNo.Location = new Point(310, 310);
        txtTutorPhoneNo.Name = "txtTutorPhoneNo";
        txtTutorPhoneNo.Size = new Size(165, 27);
        txtTutorPhoneNo.TabIndex = 9;
        // 
        // txtTutorEmail
        // 
        txtTutorEmail.Location = new Point(310, 255);
        txtTutorEmail.Name = "txtTutorEmail";
        txtTutorEmail.Size = new Size(235, 27);
        txtTutorEmail.TabIndex = 10;
        // 
        // txtTutorLName
        // 
        txtTutorLName.Location = new Point(310, 200);
        txtTutorLName.Name = "txtTutorLName";
        txtTutorLName.Size = new Size(190, 27);
        txtTutorLName.TabIndex = 11;
        // 
        // txtTutorFName
        // 
        txtTutorFName.Location = new Point(310, 145);
        txtTutorFName.Name = "txtTutorFName";
        txtTutorFName.Size = new Size(190, 27);
        txtTutorFName.TabIndex = 12;
        // 
        // txtAcademicAverage
        // 
        txtAcademicAverage.Location = new Point(310, 365);
        txtAcademicAverage.Name = "txtAcademicAverage";
        txtAcademicAverage.Size = new Size(165, 27);
        txtAcademicAverage.TabIndex = 13;
        // 
        // cmbPreferredMode
        // 
        cmbPreferredMode.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPreferredMode.Items.AddRange(new object[] { "Online", "In-person", "Both" });
        cmbPreferredMode.Location = new Point(310, 420);
        cmbPreferredMode.Name = "cmbPreferredMode";
        cmbPreferredMode.Size = new Size(165, 28);
        cmbPreferredMode.TabIndex = 14;
        // 
        // btnReturn
        // 
        btnReturn.BackColor = SystemColors.Highlight;
        btnReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btnReturn.ForeColor = SystemColors.ControlDark;
        btnReturn.Location = new Point(560, 145);
        btnReturn.Name = "btnReturn";
        btnReturn.Size = new Size(190, 60);
        btnReturn.TabIndex = 15;
        btnReturn.Text = "Return";
        btnReturn.UseVisualStyleBackColor = false;
        btnReturn.Click += btnReturn_Click;
        // 
        // btnClear
        // 
        btnClear.BackColor = SystemColors.Highlight;
        btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btnClear.ForeColor = SystemColors.ControlDark;
        btnClear.Location = new Point(560, 240);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(190, 60);
        btnClear.TabIndex = 16;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = false;
        // 
        // btnAdd
        // 
        btnAdd.BackColor = SystemColors.Highlight;
        btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btnAdd.ForeColor = SystemColors.ControlDark;
        btnAdd.Location = new Point(560, 335);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(190, 90);
        btnAdd.TabIndex = 17;
        btnAdd.Text = "Add Tutor";
        btnAdd.UseVisualStyleBackColor = false;
        // 
        // AddTutorForm
        // 
        ClientSize = new Size(800, 530);
        Controls.Add(label1);
        Controls.Add(label2);
        Controls.Add(label3);
        Controls.Add(label4);
        Controls.Add(label5);
        Controls.Add(label6);
        Controls.Add(label7);
        Controls.Add(label8);
        Controls.Add(txtTutorID);
        Controls.Add(txtTutorPhoneNo);
        Controls.Add(txtTutorEmail);
        Controls.Add(txtTutorLName);
        Controls.Add(txtTutorFName);
        Controls.Add(txtAcademicAverage);
        Controls.Add(cmbPreferredMode);
        Controls.Add(btnReturn);
        Controls.Add(btnClear);
        Controls.Add(btnAdd);
        Name = "AddTutorForm";
        Text = "Add Tutor";
        ResumeLayout(false);
        PerformLayout();
    }
}
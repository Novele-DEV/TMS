using System;
using System.Windows.Forms;
using TutoringAcademicSupport.Admin;


namespace TutoringAcademicSupport.Admin.AddTutor;

public partial class AddTutorForm : Form
{
    public AddTutorForm()
    {
        InitializeComponent();

        btnAdd.Click += AddTutorButton_Click;
        btnClear.Click += ClearButton_Click;
        btnReturn.Click += ReturnButton_Click;
    }

    private void AddTutorButton_Click(object? sender, EventArgs e)
    { //Code for adding to database

    }

    private void ClearButton_Click(object? sender, EventArgs e)
    {// This clears the input fields on the form when the "Clear" button is clicked.
        txtTutorID.Clear();
        txtTutorFName.Clear();
        txtTutorLName.Clear();
        txtTutorEmail.Clear();
        txtTutorPhoneNo.Clear();
        txtAcademicAverage.Clear();
        cmbPreferredMode.SelectedIndex = -1;
    }

    private void ReturnButton_Click(object? sender, EventArgs e)
    {// This method is called when the "Return" button is clicked.
     // It closes the current form and returns to the AdminForm.
        if (Owner is AdminForm adminForm)
        {
            adminForm.Show();
        }

        Close();
    }

    private void btnReturn_Click(object sender, EventArgs e)
    { // takes the user back to the AdminForm when the "Return" button is clicked.
        if (Owner is AdminForm adminForm)
        {
            adminForm.Show();
        }
        Close();

    }
}
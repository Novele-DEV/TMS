using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using TutoringAcademicSupport.Admin.Dashboard;


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
    { // This builds the request from the form, validates it and saves the new tutor to the database.
        var request = new AddTutorRequest(
            txtTutorFName.Text.Trim(),
            txtTutorLName.Text.Trim(),
            txtTutorEmail.Text.Trim(),
            txtTutorPhoneNo.Text.Trim(),
            txtAcademicAverage.Text.Trim(),
            cmbPreferredMode.SelectedItem?.ToString() ?? string.Empty);

        string problem = AddTutorValidator.Validate(request);
        if (problem.Length > 0)
        {
            MessageBox.Show(problem, "Check Tutor Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            AddTutorResult result = AddTutorHandler.Handle(request);
            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Tutor Not Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(result.Message, "Tutor Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearButton_Click(sender, e);
        }
        catch (Exception ex) when (ex is OleDbException or InvalidOperationException or FileNotFoundException)
        {
            Debug.WriteLine(ex);
            MessageBox.Show(
                "The tutor could not be saved to the database. Please try again.",
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
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
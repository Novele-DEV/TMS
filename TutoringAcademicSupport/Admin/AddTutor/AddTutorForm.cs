using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.Common.Branding;

namespace TutoringAcademicSupport.Admin.AddTutor;

public partial class AddTutorForm : Form
{
    // How many tutors were added while the form was open, and the latest new ID,
    // so the dashboard can confirm what happened.
    public int AddedCount { get; private set; }
    public string LastAddedTutorId { get; private set; } = string.Empty;

    public AddTutorForm()
    {
        InitializeComponent();
        ByteBetterBrand.AddLogo(this, 80, fitAbove: txtTutorID);
        ScreenLayout.CentreContent(this);
    }

    private void btnAdd_Click(object sender, EventArgs e)
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
            ShowError(problem);
            return;
        }

        try
        {
            AddTutorResult result = AddTutorHandler.Handle(request);
            if (!result.Success)
            {
                ShowError(result.Message);
                return;
            }

            AddedCount++;
            LastAddedTutorId = result.TutorId;

            // the form stays open, so several tutors can be added in a row
            ClearFields();
            ShowSuccess($"Tutor {result.TutorId} was added. ✓ You can add another tutor or return to the dashboard.");
        }
        catch (Exception ex) when (ex is OleDbException or InvalidOperationException or FileNotFoundException)
        {
            Debug.WriteLine(ex);
            ShowError("The tutor could not be saved to the database. Please try again.");
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {// This clears the input fields on the form when the "Clear" button is clicked.
        ClearFields();
        lblStatus.Text = string.Empty;
    }

    private void ClearFields()
    {
        txtTutorFName.Clear();
        txtTutorLName.Clear();
        txtTutorEmail.Clear();
        txtTutorPhoneNo.Clear();
        txtAcademicAverage.Clear();
        cmbPreferredMode.SelectedIndex = -1;
        txtTutorFName.Focus();
    }

    private void btnReturn_Click(object sender, EventArgs e)
    {// This method is called when the "Back" button is clicked.
     // It closes the current form and returns to the AdminForm.
        Close();
    }

    private void ShowSuccess(string text)
    {
        lblStatus.ForeColor = ColorTranslator.FromHtml("#2E7D32");
        lblStatus.Text = text;
    }

    private void ShowError(string text)
    {
        lblStatus.ForeColor = ColorTranslator.FromHtml("#C62828");
        lblStatus.Text = text;
    }
}

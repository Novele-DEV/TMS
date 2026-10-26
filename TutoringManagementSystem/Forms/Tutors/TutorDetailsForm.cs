using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutoring_Management_System
{
    public partial class TutorDetailsForm : Form
    {
        public TutorDetailsForm(string? tutorId)
        {
            InitializeComponent();
            _tutorId = tutorId;
        }

        private readonly string? _tutorId;

        private bool IsEditMode
        {
            get { return _tutorId != null; }
        }

        public string SavedTutorId
        {
            get; private set; 
        } = string.Empty;

        public TutorDetailsForm() : this(null)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void btnSaveTutor_Click(object sender, EventArgs e)
        {
            ClearFeedback();
            btnSaveTutor.Enabled = false;

            try
            {
                // 1. Shared validation helper: required fields, email, phone, average, duplicate email
                Dictionary<string, string> problems = TutorValidator.Validate(
                    txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text,
                    txtAverage.Text, cboPreference.Text,
                    IsEditMode ? _tutorId : null);

                if (problems.Count > 0)
                {
                    ShowErrors(problems);
                    SetStatus("Please correct the fields marked with a red icon.", true);
                    return;
                }

                // 2. Build the record
                double average;
                TutorValidator.TryParseAverage(txtAverage.Text, out average);

                var tutor = new TutorInfo
                {
                    Id = _tutorId ?? string.Empty,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = TutorValidator.NormalisePhone(txtPhone.Text),
                    AcademicAverage = average,
                    PreferredMode = cboPreference.Text
                };

                int rows;
                string savedId = _tutorId ?? string.Empty;
                if (IsEditMode)
                    rows = TutorRepository.Update(tutor);
                else
                    rows = TutorRepository.Insert(tutor, out savedId);

                // 4. Unsuccessful insert/update
                if (rows == 0)
                {
                    SetStatus("The tutor could not be saved and nothing was changed. Please try again.", true);
                    return;
                }

                // 5. Success: tell the list which tutor was saved, then close
                SavedTutorId = savedId;
                MessageBox.Show(IsEditMode ? "Tutor " + savedId + " was updated." : "Tutor " + savedId + " was added.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (OleDbException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                SetStatus("A database error occurred and the tutor was not saved. Check the database and try again.", true);
            }
            catch (InvalidOperationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                SetStatus("Could not connect to the database, so the tutor was not saved.", true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                SetStatus("An unexpected error occurred and the tutor was not saved. Please try again.", true);
            }
            finally
            {
                btnSaveTutor.Enabled = true;
            }
        }

        private void TutorDetailsForm_Load(object sender, EventArgs e)
        {
            this.Text = IsEditMode ? "Edit Tutor" : "Add Tutor";
            txtTutorID.Text = IsEditMode ? _tutorId : "(generated on save)";

            if (!IsEditMode)
                return;

            try
            {
                TutorInfo? tutor = TutorRepository.GetById(_tutorId ?? string.Empty);
                if (tutor == null)
                {
                    MessageBox.Show("That tutor could not be found. They may have been removed.","Tutor not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                txtFirstName.Text = tutor.FirstName;
                txtLastName.Text = tutor.LastName;
                txtEmail.Text = tutor.Email;
                txtPhone.Text = tutor.Phone;
                txtAverage.Text = tutor.AcademicAverage.HasValue ? tutor.AcademicAverage.Value.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture) : "";

                // If the saved preference is not one of the list items, add it so the value is not lost
                if (!string.IsNullOrEmpty(tutor.PreferredMode) && cboPreference.FindStringExact(tutor.PreferredMode) < 0)
                {
                    cboPreference.Items.Add(tutor.PreferredMode);
                }
                cboPreference.SelectedIndex = cboPreference.FindStringExact(tutor.PreferredMode);
            }
            catch (OleDbException)
            {
                MessageBox.Show("The tutor's details could not be loaded because of a database error.","Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Could not connect to the database. Check that the Access database file and its driver are available.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnCancelChange_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowErrors(Dictionary<string, string> problems)
        {
            string message;
            if (problems.TryGetValue("first", out message)) errors.SetError(txtFirstName, message);
            if (problems.TryGetValue("last", out message)) errors.SetError(txtLastName, message);
            if (problems.TryGetValue("email", out message)) errors.SetError(txtEmail, message);
            if (problems.TryGetValue("phone", out message)) errors.SetError(txtPhone, message);
            if (problems.TryGetValue("average", out message)) errors.SetError(txtAverage, message);
            if (problems.TryGetValue("preference", out message)) errors.SetError(cboPreference, message);
        }

        private void ClearFeedback()
        {
            errors.SetError(txtFirstName, "");
            errors.SetError(txtLastName, "");
            errors.SetError(txtEmail, "");
            errors.SetError(txtPhone, "");
            errors.SetError(txtAverage, "");
            errors.SetError(cboPreference, "");
            lblStatus.Text = "";
        }

        private void SetStatus(string text, bool isError)
        {
            lblStatus.ForeColor = isError ? Color.Firebrick : Color.SeaGreen;
            lblStatus.Text = text;
        }
    }
}

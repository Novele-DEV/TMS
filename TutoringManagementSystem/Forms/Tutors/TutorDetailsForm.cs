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
            AppTheme.Register(this);
            _tutorId = tutorId;
        }

        private readonly string? _tutorId;
        private string _originalEmail = string.Empty;
        private string _originalPhone = string.Empty;

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
                    txtFirstName.Text ?? string.Empty, txtLastName.Text ?? string.Empty,
                    txtEmail.Text ?? string.Empty, txtPhone.Text ?? string.Empty,
                    txtAverage.Text ?? string.Empty, cboPreference.Text ?? string.Empty,
                    IsEditMode ? _tutorId : null);

                if (IsEditMode &&
                    TutorRepository.PhoneExists(
                        TutorValidator.NormalisePhone(txtPhone.Text ?? string.Empty),
                        _tutorId))
                {
                    problems["phone"] = "A tutor with this phone number already exists.";
                }

                if (problems.Count > 0)
                {
                    ShowErrors(problems);
                    SetStatus("Please correct the fields marked with a red icon.", true);
                    return;
                }

                string email = (txtEmail.Text ?? string.Empty).Trim();
                string phone = TutorValidator.NormalisePhone(txtPhone.Text ?? string.Empty);
                if (IsEditMode &&
                    (!string.Equals(email, _originalEmail, StringComparison.OrdinalIgnoreCase) ||
                     !string.Equals(phone, _originalPhone, StringComparison.Ordinal)))
                {
                    SetStatus(
                        "The database currently rejects email or phone changes. No changes were saved; please contact the database owner.",
                        true);
                    return;
                }

                // 2. Build the record
                double average;
                TutorValidator.TryParseAverage(txtAverage.Text ?? string.Empty, out average);

                var tutor = new TutorInfo
                {
                    Id = _tutorId ?? string.Empty,
                    FirstName = (txtFirstName.Text ?? string.Empty).Trim(),
                    LastName = (txtLastName.Text ?? string.Empty).Trim(),
                    Email = email,
                    Phone = phone,
                    AcademicAverage = average,
                    PreferredMode = cboPreference.Text ?? string.Empty
                };

                int rows;
                string? savedId = _tutorId;
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

                if (string.IsNullOrWhiteSpace(savedId))
                {
                    SetStatus("The tutor was saved but its ID could not be returned.", true);
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
                _originalEmail = tutor.Email;
                _originalPhone = TutorValidator.NormalisePhone(tutor.Phone);
                txtAverage.Text = tutor.AcademicAverage.HasValue ? tutor.AcademicAverage.Value.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture) : "";

                if (IsEditMode)
                {
                    cboPreference.Items.Clear();
                    cboPreference.Items.AddRange(new object[] { "In-person", "Virtual", "Both" });
                }

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
            if (problems.TryGetValue("first", out string? message) && message != null)
                errors.SetError(txtFirstName, message);
            if (problems.TryGetValue("last", out message) && message != null)
                errors.SetError(txtLastName, message);
            if (problems.TryGetValue("email", out message) && message != null)
                errors.SetError(txtEmail, message);
            if (problems.TryGetValue("phone", out message) && message != null)
                errors.SetError(txtPhone, message);
            if (problems.TryGetValue("average", out message) && message != null)
                errors.SetError(txtAverage, message);
            if (problems.TryGetValue("preference", out message) && message != null)
                errors.SetError(cboPreference, message);
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

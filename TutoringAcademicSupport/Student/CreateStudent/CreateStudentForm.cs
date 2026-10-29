using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TutoringAcademicSupport.Student.CreateStudent
{
    public partial class CreateStudentForm : Form
    {
        private const string SaveErrorMessage = "Something went wrong and your changes were not saved. Please try again.";

        // these are the faculties and programmes taken from the student records.
        private static readonly Dictionary<string, string[]> Programmes = new Dictionary<string, string[]>
        {
            {"Commerce", new[] {"BCom Information Systems", "BCom Economics", "BCom Accounting"}},
            {"Science", new[] {"BSc Acturial Science", "BSc Statistics", "BSc Mathematical Sciences"} }
        };

        private bool busy; // prevents competing actions
        private bool created; // true once the student has been saved

        // this is read by the login form so it can fill in the login details after a successful account creation
        public int? CreatedStudentID { get; private set; }
        public string CreatedPassword { get; private set; } = string.Empty;

        public CreateStudentForm()
        {
            InitializeComponent();
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // these limits follow the data dictionary from Milestone 1
            txtStudentID.MaxLength = 7; // 7 digit number
            txtFirstName.MaxLength = 50; // 50 character first name
            txtLastName.MaxLength = 50; // 50 character last name
            txtEmail.MaxLength = 100; // 100 character email
            txtPhone.MaxLength = 12; // +27 + 9 digits 

            // the tick box makes the date a deliberate choice, an unticked box means that a date has not been entered yet. 
            dtpDoB.Format = DateTimePickerFormat.Custom;
            dtpDoB.CustomFormat = "dd MMM yyyy";
            dtpDoB.MaxDate = DateTime.Today;
            dtpDoB.Value = DateTime.Today.AddYears(-18);
            dtpDoB.ShowCheckBox = true;
            dtpDoB.Checked = false;

            txtPassword.MaxLength = 64;
            txtConfirmPassword.MaxLength = 64;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            cboProgramme.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (string faculty in Programmes.Keys) cboFaculty.Items.Add(faculty);

            lblRequired.Text = "* required";
            lblMessage.Text = "";
            UpdateControls();
        }

        // the programme list relies on the faculty it is associated with
        private void cboFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProgramme.Items.Clear();
            if (cboFaculty.SelectedItem is string faculty)
            {
                foreach (string programme in Programmes[faculty]) cboProgramme.Items.Add(programme);
            }
            cboProgramme.SelectedIndex = -1;
        }

        private void UpdateControls()
        {
            bool editable = !busy && !created;
            txtStudentID.Enabled = txtFirstName.Enabled = txtLastName.Enabled = editable;
            txtEmail.Enabled = txtPhone.Enabled = editable;
            dtpDoB.Enabled = cboFaculty.Enabled = cboProgramme.Enabled = editable;
            txtPassword.Enabled = txtConfirmPassword.Enabled = editable;
            btnCreate.Enabled = editable;
            btnBack.Enabled = !busy;
        }
        // the underlying code when the Create button is clicked
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (busy || created || !CheckRequired()) return;
            busy = true;
            UpdateControls();
            ShowNeutral("Creating student...");
            try
            {
                // the form first builds the request from the controls
                var request = new CreateStudentRequest
                {
                    StudentId = int.Parse(txtStudentID.Text.Trim()),
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    DateOfBirth = dtpDoB.Value.Date,
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Faculty = (string)cboFaculty.SelectedItem!,
                    Programme = (string)cboProgramme.SelectedItem!,
                    Password = txtPassword.Text,
                    ConfirmPassword = txtConfirmPassword.Text
                };

                // then, the validator will check the request before the handler does any work.
                string problem = CreateStudentValidator.Validate(request);
                if (problem.Length > 0)
                {
                    ShowError(problem);
                }
                else
                {
                    // the handler saves the request and returns a result, which the form presents.
                    CreateStudentResult result = CreateStudentHandler.Handle(request);
                    if (result.Success)
                    {
                        created = true;
                        CreatedStudentID = request.StudentId;
                        CreatedPassword = request.Password;
                        ShowSuccess("Account created successfully. You can now log in.");
                    }
                    else
                    {
                        // this would happen if the student number or email address already exists.
                        ShowError(result.Message);
                    }
                }
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Database operation failed.");
                MessageBox.Show(SaveErrorMessage);

            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Operation could not be completed.");
                MessageBox.Show(SaveErrorMessage);
            }
            finally
            {
                if (!created)
                {
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();
                }

                busy = false;
                UpdateControls();
            }
        }

        // the error provider supplies the error message, hence there is no need for a message bx
        // the validator and handler will take care of the business rules.
        private bool CheckRequired()
        {
            errorProvider.Clear();
            bool valid = true;

            string studentId = txtStudentID.Text.Trim();
            if (studentId.Length == 0)
                valid = Fail(txtStudentID, "Please enter the student number.");
            else if (studentId.Length != 7 || !studentId.All(char.IsDigit))
                valid = Fail(txtStudentID, "The student number must include 7 digits.");

            if (!dtpDoB.Checked)
                valid = Fail(dtpDoB, "Please tick the box and choose the date of birth.");

            if (txtFirstName.Text.Trim().Length == 0)
                valid = Fail(txtFirstName, "Please enter the first name.");
            if (txtLastName.Text.Trim().Length == 0)
                valid = Fail(txtLastName, "Please enter the last name.");

            if (txtEmail.Text.Trim().Length == 0)
                valid = Fail(txtEmail, "Please enter the email address.");

            if (txtPassword.Text.Length == 0)
                valid = Fail(txtPassword, "Please enter a password.");
            else if (txtPassword.Text.Length > 64)
                valid = Fail(txtPassword, "Password must be 64 characters or fewer.");
            else if (txtConfirmPassword.Text != txtPassword.Text)
                valid = Fail(txtConfirmPassword, "The passwords do not match.");

            // matches the stored format, for example + 27821234567.
            string phone = txtPhone.Text.Trim();
            if (phone.Length == 0)
                valid = Fail(txtPhone, "Please enter the phone number.");
            else if (!Regex.IsMatch(phone, @"^\+27\d{9}$"))
                valid = Fail(txtPhone, "Use the format +27821234567.");

            if (cboFaculty.SelectedIndex < 0)
                valid = Fail(cboFaculty, "Please select a faculty.");
            if (cboProgramme.SelectedIndex < 0)
                valid = Fail(cboProgramme, "Please select a programme of study.");

            if (!valid) ShowError("Correct the highlighted fields before creating the student.");
            return valid;
        }

        // this sets one inline error and returns false, shortening the validation rules above
        private bool Fail(Control control, string text)
        {
            errorProvider.SetError(control, text);
            return false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // closes the form and returns to the log in form.
            Close();
        }

        // the codes inside each "Show" method are placeholders for testing, replace the bodies with better logic if it exists.
        private void ShowError(string text)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#C62828");
            lblMessage.Text = text;
        }

        private void ShowSuccess(string text)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#2E7D32");
            lblMessage.Text = text;
        }

        private void ShowNeutral(string text)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = text;
        }


    }
}

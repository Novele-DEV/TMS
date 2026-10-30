using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TutoringAcademicSupport.Admin.Dashboard;
using TutoringAcademicSupport.Common.Branding;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.Student.CreateStudent;
using TutoringAcademicSupport.Student.Dashboard;
using TutoringAcademicSupport.Tutor;

namespace TutoringAcademicSupport.EntryPoint.Login
{

    public partial class LoginForm : Form
    {

        private bool busy; //prevents competing actions
        private readonly string selectedRole;

        public LoginForm(string role)
        {
            InitializeComponent();
            ByteBetterBrand.AddLogo(this, 80, fitAbove: txtUserID);
            ScreenLayout.CentreContent(this);
            ByteBetterBrand.KeepReadableWhenDisabled(btnLogIn);

            AcceptButton = btnLogIn;  // Enter logs in
            CancelButton = btnExit;   // Esc goes back to the main menu
            btnExit.Text = "&Back";   // it returns to the main menu, it does not close the program

            selectedRole = role; //this variable is used to display the role in the form
                                 //and to determine which landing page to open after a successful login.

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            lblIntro.Text = $"Enter your {selectedRole.ToLower()} ID and password.";
            string article = selectedRole == "Administrator" ? "an" : "a";
            lblMessage.Text = $"Logging in as {article} {selectedRole.ToLower()}.";
            lblUserID.Text = $"Enter your {selectedRole.ToLower()} ID:";
            txtUserID.PlaceholderText = selectedRole switch
            {
                "Administrator" => "ADM00001",
                "Tutor" => "TUT00001",
                _ => "2000001"
            };
            LnkCreateStudent.Visible = string.Equals(selectedRole, "Student", StringComparison.OrdinalIgnoreCase);
            txtPassword.MaxLength = 64; // this matches the database column size
            txtUserID.MaxLength = 16; // the admin ID is the longest with 16 characters
            txtPassword.UseSystemPasswordChar = true;

            UpdateControls();
        }

        public LoginForm() : this("Student") // default role is Student
        {
        }
        private void UpdateControls()
        {
            txtUserID.Enabled = txtPassword.Enabled = !busy;
            LnkCreateStudent.Enabled = !busy;
            btnLogIn.Enabled = !busy;
            btnExit.Enabled = !busy;
        }

        // this method calls for logging into the account 
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (busy || !CheckRequired()) return;
            busy = true;
            UpdateControls();
            ShowNeutral("Logging in...");

            LoginResult? result = null;
            try
            {
                var request = new LoginRequest(txtUserID.Text.Trim(), txtPassword.Text, selectedRole);

                // the validator will check the request before the handler does any work
                string problem = LoginValidator.Validate(request);
                if (problem.Length > 0)
                {
                    ShowError(problem);
                }
                else
                {
                    result = LoginHandler.Handle(request);
                    if (!result.Success)
                    {
                        ShowError(string.IsNullOrEmpty(result.Message) ? "Incorrect ID or password. Please try again." : result.Message);
                        result = null;
                    }
                }
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Database operation failed");
                MessageBox.Show(
    "An unexpected error has occurred while logging in. Please try again.",
    "Login Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Operation could not be completed.");
                MessageBox.Show("Please close this page and open it again before retrying.");
            }
            finally
            {
                // the password text box will be reset
                txtPassword.Clear();
                busy = false;
                UpdateControls();
            }

            // the next page will be opened only after the try block, so a problem inside the menus is not reported as a failed log in.
            if (result != null) OpenLandingForm(result);
        }

        // the error provider gives messages next to the fields, so there's no need for a message box
        private bool CheckRequired()
        {
            errorProvider.Clear();
            bool valid = true;

            if (txtUserID.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtUserID, $"Please fill in your {selectedRole.ToLower()} ID.");
                valid = false;
            }

            if (txtPassword.Text.Length == 0)
            {
                errorProvider.SetError(txtPassword, "Please enter your password.");
                valid = false;
            }

            if (!valid) ShowError("Correct the highlighted fields before logging in.");
            return valid;
        }

        // this method hides the log in form, shows the main menu and waits.
        // when closing the menu, the page resets and is shown again so the user ís not looking at a blank screen.
        // frmMainMenu is the current placeholder until an actual menu form is created.
        private void OpenLandingForm(LoginResult result)
        {
            Form landing = result.Role switch
            {
                "Administrator" => new AdminForm(result.FirstName),
                "Tutor" => new ViewAvailabilityForm(result.TutorId, result.FirstName), // the ID locks availability to this tutor
                _ => new StudentForm(result.UserId, result.FirstName) // the ID shows only that student's bookings; the name greets them
            };

            // the log in form is hidden while the landing page is open; logging out brings it back, reset
            ScreenNavigator.Open(this, landing, _ =>
            {
                txtUserID.Clear();
                txtPassword.Clear();
                ShowNeutral("You have been logged out.");
                txtUserID.Focus();
            });
        }

        private void LnkCreateStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (busy) return;
            ScreenNavigator.Open(this, new CreateStudentForm(), form =>
            {
                if (form.CreatedStudentID.HasValue)
                {
                    // The password chosen during registration is prefilled here.
                    txtUserID.Text = form.CreatedStudentID.Value.ToString();
                    txtPassword.Text = form.CreatedPassword;
                    ShowSuccess("Student account created successfully. Your password is ready.");
                }
            });
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowSuccess(string text)
        {
            lblMessage.ForeColor = AppTheme.SuccessText;
            lblMessage.Text = text;
        }

        private void ShowError(string text)
        {
            lblMessage.ForeColor = AppTheme.ErrorText;
            lblMessage.Text = text;
        }

        private void ShowNeutral(string text)
        {
            lblMessage.ForeColor = AppTheme.NormalText;
            lblMessage.Text = text;
        }




        private void frmLogIn_Load(object sender, EventArgs e)
        {

        }

        private void lblIntro_Click(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TutoringAcademicSupport.LogIn
{
    public partial class LoginForm : Form
    {
        private bool busy; // prevents competing actions 
        public LoginForm()
        {
            InitializeComponent();
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            lblIntro.Text = "Enter your ID and password to continue.";
            txtPassword.MaxLength = 64; // this length matches the database column size
            txtUserID.MaxLength = 16; // the admin ID is the longest with 16 characters
            txtPassword.UseSystemPasswordChar = true;
            UpdateControls();    
        }


        private void UpdateControls()
        {
            txtUserID.Enabled = txtPassword.Enabled = !busy;
            LnkCreateStudent.Enabled = !busy;
            btnLogIn.Enabled = !busy;
            btnExit.Enabled = !busy;
        }

        // this method calls for logging into the account 
        private void btnLogIn_Click (object sender, EventArgs e)
        { 
            if (busy || !CheckRequired()) return;
            busy = true;
            UpdateControls();
            ShowNeutral("Logging in...");

            LoginResult? result = null;
            try
            {
                var request = new LoginRequest(txtUserID.Text.Trim(), txtPassword.Text);

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
                MessageBox.Show("An unexpected error has occured while logging in. Please try again.", MessageBoxButtons.OK, );
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
                errorProvider.SetError(txtUserID, "Please fill in your student number or administrator ID.");
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
            if (result.Role == "Administrator")
            {
                using (var landing = new AdminForm(result.UserId, result.FirstName))
                    landing.ShowDialog(this);
            }
            else
            {
                using (var landing = new StudentForm(result.UserId, result.FirstName))
                    landing.ShowDialog(this);
            }
            txtUserID.Clear();
            txtPassword.Clear();
            ShowNeutral("You have been logged out.");
            Show();
            txtUserID.Focus();
        }

        private void LnkCreateStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (busy) return;
            using (var form = new CreateStudentForm())
            {
                form.ShowDialog(this);
                if (form.CreatedStudentId.HasValue)
                {
                    // simply fill in the log in details
                    txtUserID.Text = form.CreatedStudentId.Value.ToString();
                    txtPassword.Text = form.CreatedEmail;
                    ShowSuccess("Student account created successfully. \u2713");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowSuccess(string text)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("2E7D32");
            lblMessage.Text = text;
        }

        private void ShowError(string text)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#C62828");
            lblMessage.Text = text;
        }

        private void ShowNeutral(string text)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = text;
        }
        



        private void frmLogIn_Load(object sender, EventArgs e)
        {

        }

        private void lblIntro_Click(object sender, EventArgs e)
        {

        }
    }
}

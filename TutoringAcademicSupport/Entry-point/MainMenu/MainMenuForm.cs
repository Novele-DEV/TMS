using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.EntryPoint.Login;

namespace TutoringAcademicSupport.EntryPoint.MainMenu
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void OpenLoginForm(string role)
        { // the main menu is hidden while the login form is open and comes back when it closes
            ScreenNavigator.Open(this, new LoginForm(role));
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            OpenLoginForm("Student");
        }

        private void btnTutor_Click(object sender, EventArgs e)
        {
            OpenLoginForm("Tutor");
        }

        private void btnAdministrator_Click(object sender, EventArgs e)
        {
            OpenLoginForm("Administrator");
        }
    }
}
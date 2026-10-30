using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Branding;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.EntryPoint.Login;

namespace TutoringAcademicSupport.EntryPoint.MainMenu
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();

            picLogo.Image = ByteBetterBrand.Logo;
            Icon = ByteBetterBrand.WindowIcon;

            foreach (Button roleButton in new[] { btnStudent, btnTutor, btnAdministrator })
            {
                ByteBetterBrand.AddFocusOutline(roleButton);
            }

            // the first screen does not come through ScreenNavigator, so it does this itself
            Load += (_, _) => ScreenLayout.TidyLabels(this);
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

        private void btnExit_Click(object sender, EventArgs e)
        { // closing the main menu ends the program
            Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutoringAcademicSupport.EntryPoint.Login;
using TutoringAcademicSupport.EntryPoint.MainMenu;
using TutoringAcademicSupport.Tutor.UpdateAvailability;

namespace TutoringAcademicSupport.Tutor
{
    public partial class ViewAvailabilityForm : Form
    {
        public ViewAvailabilityForm(LoginForm loginForm)
        {
            InitializeComponent();

            lblTutorMessage.Text = "Welcome, Tutor !";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using UpdateAvailabilityForm updateForm = new();
            updateForm.ShowDialog(this);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            MainMenuForm? mainMenu = Application
                .OpenForms
                .OfType<MainMenuForm>()
                .FirstOrDefault();

            if (mainMenu != null)
            {
                mainMenu.Show();
                mainMenu.Activate();
            }

            Close();
        }
    }
}

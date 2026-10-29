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
            // this page is hidden while availability is being updated and comes back when that closes
            ScreenNavigator.Open(this, new UpdateAvailabilityForm());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // closing returns to the screen that opened this one
            Close();
        }
    }
}

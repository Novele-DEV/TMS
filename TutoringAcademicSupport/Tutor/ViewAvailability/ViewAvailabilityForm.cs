using System;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Branding;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.Tutor.UpdateAvailability;

namespace TutoringAcademicSupport.Tutor
{
    // The tutor's landing page after logging in.
    public partial class ViewAvailabilityForm : Form
    {
        private readonly string tutorId; // the logged-in tutor, e.g. TUT00001

        public ViewAvailabilityForm(string tutorId, string firstName)
        {
            InitializeComponent();
            this.tutorId = tutorId;

            picLogo.Image = ByteBetterBrand.Logo;
            Icon = ByteBetterBrand.WindowIcon;
            ByteBetterBrand.AddFocusOutline(btnUpdate);
            AppTheme.AddToggle(this);

            lblTutorMessage.Text = string.IsNullOrWhiteSpace(firstName)
                ? $"Logged in as tutor {tutorId}"
                : $"Welcome, {firstName}  ·  Tutor {tutorId}";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // opens this tutor's own availability with their ID locked, so they cannot change another tutor's
            ScreenNavigator.Open(this, new UpdateAvailabilityForm(tutorId));
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // logging out closes the menu, which returns to the log in form
            Close();
        }
    }
}

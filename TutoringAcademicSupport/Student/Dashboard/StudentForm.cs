using System.Windows.Forms;
using TutoringAcademicSupport.Common.Branding;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.Student.BookSession;
using TutoringAcademicSupport.Student.CancelBooking;
using TutoringAcademicSupport.Student.UpdateBooking;
using TutoringAcademicSupport.Student.ViewTutorAvailability;

namespace TutoringAcademicSupport.Student.Dashboard
{
    public partial class StudentForm : Form
    {
        // The ID of the student who logged in. The Cancel form needs it to list only this student's bookings.
        private readonly int studentId;

        public StudentForm(int studentId, string firstName = "")
        {
            InitializeComponent();
            this.studentId = studentId;

            picLogo.Image = ByteBetterBrand.Logo;
            Icon = ByteBetterBrand.WindowIcon;

            // greet the student by name, with the student number as a reference
            lblLoggedInAs.Text = string.IsNullOrWhiteSpace(firstName)
                ? $"Logged in as student {studentId}"
                : $"Welcome, {firstName}  ·  Student {studentId}";

            foreach (Button option in new[] { btnViewAvailability, btnBookSession, btnUpdateBooking, btnCancelBooking })
            {
                ByteBetterBrand.AddFocusOutline(option);
            }

            AppTheme.AddToggle(this);
        }

        // each page opens in place of this menu, which comes back when the page closes
        private void btnViewAvailability_Click(object sender, EventArgs e)
        {
            ScreenNavigator.Open(this, new ViewTutorAvailabilityForm());
        }

        private void btnBookSession_Click(object sender, EventArgs e)
        {
            ScreenNavigator.Open(this, new BookSessionForm(studentId));
        }

        private void btnUpdateBooking_Click(object sender, EventArgs e)
        {
            ScreenNavigator.Open(this, new UpdateBookingForm(studentId));
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            ScreenNavigator.Open(this, new CancelBookingForm(this.studentId));
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        { // logging out closes the menu, which returns to the log in form
            Close();
        }
    }
}

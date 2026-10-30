using System.Windows.Forms;
<<<<<<< Updated upstream
using TutoringAcademicSupport.Common.Navigation;
=======
using TutoringAcademicSupport.Student.BookSession;
using TutoringAcademicSupport.Student.CancelBooking;
using TutoringAcademicSupport.Student.UpdateBooking;
>>>>>>> Stashed changes
using TutoringAcademicSupport.Student.ViewTutorAvailability;

namespace TutoringAcademicSupport.Student.Dashboard
{
    public partial class StudentForm : Form
    {
        // The ID of the student who logged in. The Cancel form needs it to list only this student's bookings.
        private readonly int studentId;

        public StudentForm(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;

            Text = "Student Menu";
            Controls.Add(new Label
            {
                Text = "Student Menu",
                AutoSize = true,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(30, 25)
            });

            Button btnViewAvailability = new()
            {
                Text = "&View Tutor Availability",
                AutoSize = true,
                Location = new Point(30, 90)
            };
            btnViewAvailability.Click += (_, _) =>
            {
                // the menu is hidden while tutor availability is open and comes back when it closes
                ScreenNavigator.Open(this, new ViewTutorAvailabilityForm());
            };
            Controls.Add(btnViewAvailability);

<<<<<<< Updated upstream
            // logging out closes the menu, which returns to the log in form
            Button btnLogOut = new()
            {
                Text = "&Log Out",
                AutoSize = true,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(ClientSize.Width - 130, ClientSize.Height - 60)
            };
            btnLogOut.Click += (_, _) => Close();
            Controls.Add(btnLogOut);
=======
            Button btnBookSession = new()
            {
                Text = "Book a Tutorial Session",
                AutoSize = true,
                Location = new Point(30, 130)
            };
            btnBookSession.Click += (_, _) =>
            {
                using BookSessionForm form = new();
                form.ShowDialog(this);
            };
            Controls.Add(btnBookSession);

            Button btnUpdateBooking = new()
            {
                Text = "Update a Booking",
                AutoSize = true,
                Location = new Point(30, 170)
            };
            btnUpdateBooking.Click += (_, _) =>
            {
                using UpdateBookingForm form = new();
                form.ShowDialog(this);
            };
            Controls.Add(btnUpdateBooking);

            Button btnCancelBooking = new()
            {
                Text = "Cancel a Booking",
                AutoSize = true,
                Location = new Point(30, 210)
            };
            btnCancelBooking.Click += (_, _) =>
            {
                using CancelBookingForm form = new(this.studentId);
                form.ShowDialog(this);
            };
            Controls.Add(btnCancelBooking);
>>>>>>> Stashed changes
        }
    }
}

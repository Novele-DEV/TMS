using System.Windows.Forms;
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

            // each page opens in place of this menu, which comes back when the page closes
            Button btnViewAvailability = new()
            {
                Text = "&View Tutor Availability",
                AutoSize = true,
                Location = new Point(30, 90)
            };
            btnViewAvailability.Click += (_, _) => ScreenNavigator.Open(this, new ViewTutorAvailabilityForm());
            Controls.Add(btnViewAvailability);

            Button btnBookSession = new()
            {
                Text = "Book a Tutorial Session",
                AutoSize = true,
                Location = new Point(30, 130)
            };
            btnBookSession.Click += (_, _) => ScreenNavigator.Open(this, new BookSessionForm());
            Controls.Add(btnBookSession);

            Button btnUpdateBooking = new()
            {
                Text = "Update a Booking",
                AutoSize = true,
                Location = new Point(30, 170)
            };
            btnUpdateBooking.Click += (_, _) => ScreenNavigator.Open(this, new UpdateBookingForm());
            Controls.Add(btnUpdateBooking);

            Button btnCancelBooking = new()
            {
                Text = "Cancel a Booking",
                AutoSize = true,
                Location = new Point(30, 210)
            };
            btnCancelBooking.Click += (_, _) => ScreenNavigator.Open(this, new CancelBookingForm(this.studentId));
            Controls.Add(btnCancelBooking);

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
        }
    }
}

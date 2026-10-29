using System.Windows.Forms;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.Student.ViewTutorAvailability;

namespace TutoringAcademicSupport.Student.Dashboard
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();

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

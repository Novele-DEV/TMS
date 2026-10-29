using System.Windows.Forms;
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
                Text = "View Tutor Availability",
                AutoSize = true,
                Location = new Point(30, 90)
            };
            btnViewAvailability.Click += (_, _) =>
            {
                using ViewTutorAvailabilityForm form = new();
                form.ShowDialog(this);
            };
            Controls.Add(btnViewAvailability);
        }
    }
}

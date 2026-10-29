using System.Data.OleDb;
using System.Diagnostics;

namespace TutoringAcademicSupport.Student.ViewTutorAvailability
{
    public partial class ViewTutorAvailabilityForm : Form
    {
        private readonly TextBox txtTutorId = new();
        private readonly DataGridView availabilityGrid = new();
        private readonly Label lblMessage = new();

        public ViewTutorAvailabilityForm()
        {
            InitializeComponent();

            Text = "View Tutor Availability";
            ClientSize = new Size(850, 520);
            StartPosition = FormStartPosition.CenterParent;

            Controls.Add(new Label
            {
                Text = "Tutor ID (leave blank to view all)",
                AutoSize = true,
                Location = new Point(20, 23)
            });

            txtTutorId.Location = new Point(220, 18);
            txtTutorId.Size = new Size(150, 27);
            txtTutorId.MaxLength = 8;
            Controls.Add(txtTutorId);

            Button btnSearch = new()
            {
                Text = "Search",
                Location = new Point(385, 16),
                Size = new Size(100, 32)
            };
            btnSearch.Click += (_, _) => LoadAvailability();
            Controls.Add(btnSearch);

            availabilityGrid.Location = new Point(20, 65);
            availabilityGrid.Size = new Size(810, 390);
            availabilityGrid.ReadOnly = true;
            availabilityGrid.AllowUserToAddRows = false;
            availabilityGrid.AllowUserToDeleteRows = false;
            availabilityGrid.MultiSelect = false;
            availabilityGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            availabilityGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Controls.Add(availabilityGrid);

            lblMessage.Location = new Point(20, 470);
            lblMessage.Size = new Size(810, 30);
            Controls.Add(lblMessage);

            LoadAvailability();
        }

        private void LoadAvailability()
        {
            try
            {
                ViewTutorAvailabilityResult result = ViewTutorAvailabilityHandler.Handle(
                    new ViewTutorAvailabilityRequest { TutorId = txtTutorId.Text.Trim() });
                if (!result.Success)
                {
                    ShowError(result.Message);
                    return;
                }

                availabilityGrid.DataSource = result.Availability;
                foreach (string columnName in new[] { "Avail_StartTime", "Avail_EndTime" })
                {
                    if (availabilityGrid.Columns[columnName] != null)
                    {
                        availabilityGrid.Columns[columnName].DefaultCellStyle.Format = "HH:mm";
                    }
                }

                ShowNeutral(result.Message);
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Could not load tutor availability from the database.");
                MessageBox.Show(this, ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowError(string message)
        {
            lblMessage.ForeColor = Color.Firebrick;
            lblMessage.Text = message;
        }

        private void ShowNeutral(string message)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = message;
        }
    }
}

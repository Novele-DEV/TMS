using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using TutoringAcademicSupport.Common;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Student.BookSession
{
    public partial class BookSessionForm : Form
    {
        public BookSessionForm()
        {
            InitializeComponent();
            Load += BookSessionForm_Load;
        }



        private void BookSessionForm_Load(object? sender, EventArgs e)
        {
            cmbMode.SelectedIndex = 0;
            dtpSessionDate.MinDate = DateTime.Today;

            LoadTutors();
        }

        private void LoadTutors()
        {
            try
            {
                using (OleDbConnection connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        "SELECT [Tutor_ID], [Tutor_FName], [Tutor_LName] FROM [Tutor]";

                    using (OleDbCommand command =
                           new OleDbCommand(query, connection))
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        cmbTutor.Items.Clear();

                        while (reader.Read())
                        {
                            string id = reader["Tutor_ID"].ToString() ?? "";
                            string firstName = reader["Tutor_FName"].ToString() ?? "";
                            string lastName = reader["Tutor_LName"].ToString() ?? "";

                            cmbTutor.Items.Add(
                                new TutorItem(id, firstName + " " + lastName));
                        }
                    }
                }

                if (cmbTutor.Items.Count > 0)
                    cmbTutor.SelectedIndex = 0;
                else
                    lblMessage.Text = "No tutors are available.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load tutors. Check the database connection.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBookTutorial_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStudentID.Text.Trim(), out int studentId))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }

            if (cmbTutor.SelectedItem is not TutorItem tutor)
            {
                MessageBox.Show("Please select a tutor.");
                return;
            }

            DateTime sessionDate = dtpSessionDate.Value.Date;
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;

            DateTime start = sessionDate.Add(startTime.TimeOfDay);
            DateTime end = sessionDate.Add(endTime.TimeOfDay);

            if (start <= DateTime.Now)
            {
                MessageBox.Show("Please select a future session date and time.");
                return;
            }

            if (end <= start)
            {
                MessageBox.Show("The end time must be after the start time.");
                return;
            }

            if (cmbMode.SelectedItem == null)
            {
                MessageBox.Show("Please select a session mode.");
                return;
            }

            try
            {
                using (OleDbConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string dayName = sessionDate.DayOfWeek.ToString();

                    const string availabilityQuery =
                        "SELECT COUNT(*) FROM [TutorAvailability] " +
                        "WHERE [Tutor_ID] = ? AND [Avail_Day] = ? " +
                        "AND [Avail_StartTime] <= ? AND [Avail_EndTime] >= ?";

                    using (OleDbCommand availabilityCommand =
                           new OleDbCommand(availabilityQuery, connection))
                    {
                        availabilityCommand.Parameters.AddWithValue("@tutorId", tutor.Id);
                        availabilityCommand.Parameters.AddWithValue("@day", dayName);
                        availabilityCommand.Parameters.AddWithValue("@start", start.TimeOfDay);
                        availabilityCommand.Parameters.AddWithValue("@end", end.TimeOfDay);

                        int available = Convert.ToInt32(
                            availabilityCommand.ExecuteScalar());

                        if (available == 0)
                        {
                            MessageBox.Show(
                                "The selected tutor is not available for this day and time. Please choose another slot.");
                            return;
                        }
                    }

                    const string overlapQuery =
                        "SELECT COUNT(*) FROM [TutoringSession] " +
                        "WHERE [Tutor_ID] = ? AND [Session_Status] <> ? " +
                        "AND [Session_Date] = ? " +
                        "AND [Session_StartTime] < ? AND [Session_EndTime] > ?";

                    using (OleDbCommand overlapCommand =
                           new OleDbCommand(overlapQuery, connection))
                    {
                        overlapCommand.Parameters.AddWithValue("@tutorId", tutor.Id);
                        overlapCommand.Parameters.AddWithValue("@status", "Cancelled");
                        overlapCommand.Parameters.AddWithValue("@date", sessionDate);
                        overlapCommand.Parameters.AddWithValue("@end", end.TimeOfDay);
                        overlapCommand.Parameters.AddWithValue("@start", start.TimeOfDay);

                        int conflicts = Convert.ToInt32(overlapCommand.ExecuteScalar());

                        if (conflicts > 0)
                        {
                            MessageBox.Show(
                                "This tutor already has a booking during that time. Please choose another time.");
                            return;
                        }
                    }

                    const string insertQuery =
                        "INSERT INTO [TutoringSession] " +
                        "([Student_ID], [Tutor_ID], [Session_StartTime], " +
                        "[Session_EndTime], [Session_Date], [Session_ModeOfDelivery], [Session_Status]) " +
                        "VALUES (?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand insertCommand =
                           new OleDbCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@studentId", studentId);
                        insertCommand.Parameters.AddWithValue("@tutorId", tutor.Id);
                        insertCommand.Parameters.AddWithValue("@startTime", start.TimeOfDay);
                        insertCommand.Parameters.AddWithValue("@endTime", end.TimeOfDay);
                        insertCommand.Parameters.AddWithValue("@sessionDate", sessionDate);
                        insertCommand.Parameters.AddWithValue("@mode", cmbMode.SelectedItem.ToString());
                        insertCommand.Parameters.AddWithValue("@status", "Scheduled");

                        insertCommand.ExecuteNonQuery();
                    }
                }

                lblMessage.Text = "Session booked successfully!";
                MessageBox.Show("Your tutorial session has been booked.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not book the session. Please check the database and try again.\n\n" + ex.Message,
                    "Booking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();

            if (cmbTutor.Items.Count > 0)
                cmbTutor.SelectedIndex = 0;

            dtpSessionDate.Value = DateTime.Today;
            dtpStartTime.Value = DateTime.Today.AddHours(9);
            dtpEndTime.Value = DateTime.Today.AddHours(10);
            cmbMode.SelectedIndex = 0;
            lblMessage.Text = "";
        }

        private sealed class TutorItem
        {
            public string Id { get; }
            public string Name { get; }

            public TutorItem(string id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Id + " - " + Name;
            }
        }

        private void BookSessionForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
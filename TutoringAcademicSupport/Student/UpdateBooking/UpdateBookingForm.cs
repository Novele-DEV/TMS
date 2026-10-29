using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutoringAcademicSupport.Common;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Student.UpdateBooking
{
    public partial class UpdateBookingForm : Form

    {
        private string tutorId = string.Empty;
        public UpdateBookingForm()
        {
            InitializeComponent();
            // Add the available tutoring modes.
            cmbMode.Items.Clear();
            cmbMode.Items.Add("In-person");
            cmbMode.Items.Add("Virtual");

            // Select the first mode by default.
            cmbMode.SelectedIndex = 0;

            // Configure the time pickers to display time only.
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.ShowUpDown = true;

            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.ShowUpDown = true;

        }


        private void btnFindSession_Click(object sender, EventArgs e)
        {
            // Check that the Student ID and Session ID were entered.
            if (!int.TryParse(txtStudentID.Text.Trim(), out int studentId))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                txtStudentID.Focus();
                return;
            }

            if (!int.TryParse(txtSession.Text.Trim(), out int sessionId))
            {
                MessageBox.Show("Please enter a valid Session ID.");
                txtSession.Focus();
                return;
            }

            try
            {
                using (OleDbConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
    SELECT [Tutor_ID],
           [Session_Date],
           [Session_StartTime],
           [Session_EndTime],
           [Session_ModeOfDelivery]
    FROM [TutoringSession]
    WHERE [Session_ID] = ?
      AND [Student_ID] = ?";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // OleDb parameters must be added in the same order as the ? marks.
                        command.Parameters.Add("?", OleDbType.Integer).Value = sessionId;
                        command.Parameters.Add("?", OleDbType.Integer).Value = studentId;

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tutorId = reader["Tutor_ID"].ToString() ?? string.Empty;
                                dtpSession.Value = Convert.ToDateTime(reader["Session_Date"]);
                                dtpStartTime.Value = Convert.ToDateTime(reader["Session_StartTime"]);
                                dtpEndTime.Value = Convert.ToDateTime(reader["Session_EndTime"]);

                                cmbMode.Items.Clear();
                                cmbMode.Items.Add("In-person");
                                cmbMode.Items.Add("Virtual");

                                string mode = reader["Session_ModeOfDelivery"].ToString();

                                if (cmbMode.Items.Contains(mode))
                                {
                                    cmbMode.SelectedItem = mode;
                                }
                                else
                                {
                                    cmbMode.SelectedIndex = 0;
                                }

                                MessageBox.Show(
                                    "Tutoring session found! You can now update its details.",
                                    "Session Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(
                                    "No tutoring session was found for that Student ID and Session ID.",
                                    "Session Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not find the tutoring session.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnUpdateSession_Click(object sender, EventArgs e)
        {
            // Check the Student ID.
            if (!int.TryParse(txtStudentID.Text.Trim(), out int studentId))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                txtStudentID.Focus();
                return;
            }

            // Check the Session ID.
            if (!int.TryParse(txtSession.Text.Trim(), out int sessionId))
            {
                MessageBox.Show("Please enter a valid Session ID.");
                txtSession.Focus();
                return;
            }

            // Make sure a tutor was loaded by the Find Session button.
            if (string.IsNullOrWhiteSpace(tutorId))
            {
                MessageBox.Show("Please find the tutoring session before updating it.",
                    "Session Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check the delivery mode.
            if (cmbMode.SelectedItem == null)
            {
                MessageBox.Show("Please select a delivery mode.");
                return;
            }

            // Combine the selected date with the start and end times.
            DateTime sessionDate = dtpSession.Value.Date;
            DateTime sessionStart = sessionDate.Add(dtpStartTime.Value.TimeOfDay);
            DateTime sessionEnd = sessionDate.Add(dtpEndTime.Value.TimeOfDay);

            if (sessionEnd <= sessionStart)
            {
                MessageBox.Show("The end time must be after the start time.");
                return;
            }

            // Prepare the information for the update handler.
            UpdateBookingRequest request = new UpdateBookingRequest
            {
                SessionId = sessionId,
                StudentId = studentId,
                SessionDate = sessionDate,
                StartTime = sessionStart,
                EndTime = sessionEnd,
                TutorId = tutorId,
                ModeOfDelivery = cmbMode.SelectedItem.ToString() ?? string.Empty
            };

            // Let the handler validate and update the session.
            UpdateBookingHandler handler = new UpdateBookingHandler();
            UpdateBookingResult result = handler.Handle(request);

            MessageBox.Show(
                result.Message,
                result.Success ? "Success" : "Unable to Update Booking",
                MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void UpdateBookingForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateBookingForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}


using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TutoringManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbMode.Items.Clear();
            cmbMode.Items.Add("In-person");
            cmbMode.Items.Add("Virtual");
            cmbMode.SelectedIndex = 0;
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string query =
                         "SELECT * FROM [Tutor]";

                    using (var command = new OleDbCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        cmbTutor.Items.Clear();

                        while (reader.Read())
                        {
                            string tutorID = reader["Tutor_ID"].ToString();
                            string firstName = reader["Tutor_FName"].ToString();
                            string lastName = reader["Tutor_LName"].ToString();

                            cmbTutor.Items.Add(
                                tutorID + " - " + firstName + " " + lastName);
                        }
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Tutor Loading Error");
            }
        }


        private void btnBookTutorial_Click(object sender, EventArgs e)
        {
            // 1. Validate the Student ID
            if (!int.TryParse(txtStudentID.Text.Trim(), out int studentID))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            // 2. Check that a tutor has been selected
            if (cmbTutor.SelectedItem == null)
            {
                MessageBox.Show("Please select a tutor.");
                return;
            }

            string selectedTutor = cmbTutor.SelectedItem.ToString();
            string tutorID = selectedTutor.Split(
                new string[] { " - " },
                StringSplitOptions.None)[0];

            // 3. Combine the selected date and times
            DateTime sessionDate = dtpSessionDate.Value.Date;
            DateTime startTime = sessionDate.Add(dtpStartTime.Value.TimeOfDay);
            DateTime endTime = sessionDate.Add(dtpEndTime.Value.TimeOfDay);
            //Check that the session date isn't in the past
            if (sessionDate < DateTime.Today)
            {
                MessageBox.Show("Please select today or a future date.");
                return;
            }

            // 4. Validate the session
            string error = BookingRules.ValidateBooking(startTime);

            if (error != string.Empty)
            {
                MessageBox.Show(error, "Booking Error");
                return;
            }

            if (endTime <= startTime)
            {
                MessageBox.Show(
                    "The end time must be later than the start time.",
                    "Booking Error");
                return;
            }
            if (cmbMode.SelectedItem == null)
            {
                MessageBox.Show("Please select In-person or Virtual.");
                return;
            }

            string mode = cmbMode.SelectedItem.ToString();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // 5. Find the existing request for this student and tutor
                    string requestQuery =
                        "SELECT [Request_ID] FROM [TutoringRequest] " +
                        "WHERE [Student_ID] = ? AND [Tutor_ID] = ?";

                    int requestID;

                    using (var command = new OleDbCommand(
                        requestQuery, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.Parameters.AddWithValue("@TutorID", tutorID);
                       
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "No existing tutor request matches this student and tutor.",
                                    "Request Not Found");
                                return;
                            }

                            requestID = Convert.ToInt32(reader["Request_ID"]);

                            if (reader.Read())
                            {
                                MessageBox.Show(
                                    "More than one matching request was found. " +
                                    "Please identify the correct request before booking.",
                                    "Multiple Requests");
                                return;
                            }
                        }
                    }

                    // 6. Insert the session using the existing Request_ID
                    string insertQuery =
     "INSERT INTO [TutoringSession] " +
     "([Student_ID], [Tutor_ID], [Session_StartTime], " +
     "[Session_EndTime], [Session_Date], [Request_ID], " +
     "[Session_ModeOfDelivery], [Session_Status]) " +
     "VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
                    using (var command = new OleDbCommand(
                        insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.Parameters.AddWithValue("@TutorID", tutorID);
                        command.Parameters.Add("@StartTime", OleDbType.Date).Value = startTime;
                        command.Parameters.Add("@EndTime", OleDbType.Date).Value = endTime;
                        command.Parameters.Add("@SessionDate", OleDbType.Date).Value = sessionDate;
                        command.Parameters.AddWithValue("@RequestID", requestID);
                        command.Parameters.Add("@Mode", OleDbType.VarWChar).Value = mode;
                        command.Parameters.Add("@Status", OleDbType.VarWChar).Value = "Scheduled";

                        // Replace these with the exact values your database expects.


                        
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            MessageBox.Show(
                                "Tutorial booked and saved successfully!",
                                "Booking Successful");
                        }
                        else
                        {
                            MessageBox.Show(
                                "The booking was not saved.",
                                "Booking Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Booking Error");
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

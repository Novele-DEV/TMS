using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using TutoringAcademicSupport.Student.CancelBooking;

namespace TutoringAcademicSupport.Student.BookSession
{
    public partial class BookSessionForm : Form
    {
        private const string StartMessage = "Enter your student ID to see the requests you can book a session for.";
        private const string DatabaseErrorMessage = "The database could not be reached. Please try again.";

        private bool loading; // true while the code fills the controls, so their change events are ignored

        public BookSessionForm()
        {
            InitializeComponent();
        }

        private void BookSessionForm_Load(object? sender, EventArgs e)
        {
            loading = true;
            try
            {
                lblRules.Text = CancelBookingValidator.RuleNotice;

                cmbMode.Items.Clear();
                cmbMode.Items.AddRange(BookSessionValidator.Modes);
                cmbMode.SelectedIndex = 0;

                dtpSessionDate.MinDate = DateTime.Today;
                ResetPickers();
            }
            finally
            {
                loading = false;
            }

            UpdateControls();
            ShowNeutral(StartMessage);
        }

        // The pickers start at the current moment. The student chooses the real session date and times.
        private void ResetPickers()
        {
            DateTime now = DateTime.Now;
            dtpSessionDate.Value = DateTime.Today;
            dtpStartTime.Value = now;
            dtpEndTime.Value = now;
        }

        private void txtStudentID_Leave(object? sender, EventArgs e)
        {
            LoadRequests();
        }

        // The date, the times and the chosen request decide which tutors are available.
        private void AvailabilityInputs_Changed(object? sender, EventArgs e)
        {
            RefreshTutors();
        }

        private bool TryReadStudentId(out int studentId)
        {
            return int.TryParse(txtStudentID.Text.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out studentId)
                && studentId > 0;
        }

        // Fills the request list with the requests this student can book a session for.
        private void LoadRequests()
        {
            if (loading) return;

            loading = true;
            try
            {
                cmbRequest.Items.Clear();
            }
            finally
            {
                loading = false;
            }

            if (txtStudentID.Text.Trim().Length > 0)
            {
                if (!TryReadStudentId(out int studentId))
                {
                    ShowError("Please enter a valid student ID (numbers only).");
                }
                else
                {
                    FillRequests(studentId);
                }
            }

            RefreshTutors();
        }

        private void FillRequests(int studentId)
        {
            try
            {
                DataTable requests = BookSessionHandler.GetBookableRequests(studentId);

                loading = true;
                try
                {
                    foreach (DataRow row in requests.Rows)
                    {
                        cmbRequest.Items.Add(new RequestItem(
                            Convert.ToInt32(row["Request_ID"]),
                            Convert.ToString(row["Course_Code"]) ?? string.Empty,
                            Convert.ToString(row["Course_Name"]) ?? string.Empty,
                            Convert.ToString(row["Request_SupportType"]) ?? string.Empty));
                    }

                    if (cmbRequest.Items.Count > 0) cmbRequest.SelectedIndex = 0;
                }
                finally
                {
                    loading = false;
                }

                if (cmbRequest.Items.Count == 0)
                {
                    ShowError("There are no tutoring requests ready to book for this student ID. " +
                              "A request has to be verified or matched with a tutor first.");
                }
                else
                {
                    ShowNeutral("Choose the date and times to see which tutors are available.");
                }
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError(DatabaseErrorMessage);
            }
        }

        // Lists only the tutors who are verified for the request's course and free at the chosen time.
        // When nobody is available the student is told so, and booking is not possible.
        private void RefreshTutors()
        {
            if (loading) return;

            cmbTutor.Items.Clear();

            if (cmbRequest.SelectedItem is RequestItem request)
            {
                DateTime date = dtpSessionDate.Value.Date;
                DateTime start = BookSessionValidator.Combine(date, dtpStartTime.Value);
                DateTime end = BookSessionValidator.Combine(date, dtpEndTime.Value);

                if (end <= start)
                {
                    ShowNeutral("Choose an end time after the start time to see which tutors are available.");
                }
                else
                {
                    FillTutors(request, date, start, end);
                }
            }

            UpdateControls();
        }

        private void FillTutors(RequestItem request, DateTime date, DateTime start, DateTime end)
        {
            try
            {
                DataTable tutors = BookSessionHandler.GetAvailableTutors(request.CourseCode, date, start, end);

                foreach (DataRow row in tutors.Rows)
                {
                    cmbTutor.Items.Add(new TutorItem(
                        Convert.ToString(row["Tutor_ID"]) ?? string.Empty,
                        Convert.ToString(row["TutorName"]) ?? string.Empty));
                }

                string when = $"{request.CourseCode} on {date:dddd dd MMM yyyy} from {start:HH:mm} to {end:HH:mm}";
                if (cmbTutor.Items.Count > 0)
                {
                    cmbTutor.SelectedIndex = 0;
                    ShowNeutral($"{cmbTutor.Items.Count} tutor(s) available for {when}.");
                }
                else
                {
                    ShowError($"No tutor is available for {when}. Please choose a different day or time.");
                }
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError(DatabaseErrorMessage);
            }
        }

        // A session can only be booked once a request and an available tutor are selected.
        private void UpdateControls()
        {
            btnBookTutorial.Enabled = cmbRequest.SelectedItem is RequestItem && cmbTutor.SelectedItem is TutorItem;
        }

        private void btnBookTutorial_Click(object? sender, EventArgs e)
        {
            // The form only passes on what was entered. The validator and the handler decide whether it is acceptable.
            int.TryParse(txtStudentID.Text.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out int studentId);

            var request = new BookSessionRequest
            {
                StudentId = studentId,
                RequestId = (cmbRequest.SelectedItem as RequestItem)?.Id ?? 0,
                TutorId = (cmbTutor.SelectedItem as TutorItem)?.Id ?? string.Empty,
                SessionDate = dtpSessionDate.Value.Date,
                StartTime = dtpStartTime.Value,
                EndTime = dtpEndTime.Value,
                ModeOfDelivery = cmbMode.SelectedItem as string ?? string.Empty
            };

            try
            {
                BookSessionResult result = BookSessionHandler.Handle(request);

                if (result.Success)
                {
                    // The booked request is no longer open, so the lists are loaded again before the result is shown.
                    LoadRequests();
                    ShowSuccess(result.Message);
                    MessageBox.Show(result.Message, "Session booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowError(result.Message);
                }
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("The session could not be booked.");
                MessageBox.Show(
                    "Could not book the session. Please check the database and try again.",
                    "Booking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex);
                ShowError("The session could not be booked.");
                MessageBox.Show(
                    "Please close this page and open it again before retrying.",
                    "Booking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            loading = true;
            try
            {
                txtStudentID.Clear();
                cmbRequest.Items.Clear();
                cmbTutor.Items.Clear();
                cmbMode.SelectedIndex = 0;
                ResetPickers();
            }
            finally
            {
                loading = false;
            }

            UpdateControls();
            ShowNeutral(StartMessage);
        }

        private void ShowError(string text)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#C62828");
            lblMessage.Text = text;
        }

        private void ShowSuccess(string text)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#2E7D32");
            lblMessage.Text = text;
        }

        private void ShowNeutral(string text)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = text;
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

        private sealed class RequestItem
        {
            private readonly string courseName;
            private readonly string supportType;

            public int Id { get; }
            public string CourseCode { get; }

            public RequestItem(int id, string courseCode, string courseName, string supportType)
            {
                Id = id;
                CourseCode = courseCode;
                this.courseName = courseName;
                this.supportType = supportType;
            }

            public override string ToString()
            {
                return $"#{Id} - {CourseCode} {courseName} ({supportType})";
            }
        }
    }
}

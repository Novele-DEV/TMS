using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TutoringManagementSystem
{
    public partial class frmUpdateBooking : Form
    {
        private const string RuleNoticeText =
            "Bookings cannot be changed or cancelled less than 48 hours before the session.";
        private const string LoadingMessage = "Loading your bookings...";
        private const string NoTutorMessage =
            "No tutors are available for that time. Please choose another date or time.";
        private const string SaveErrorMessage =
            "Something went wrong and your changes were not saved. Please try again.";

        private readonly DataSet bookingData = new DataSet("BookingData");
        private readonly BindingSource bookingSource = new BindingSource();
        private readonly int studentId;      // the logged-in student; the menu passes this in
        private string connectionString;
        private bool connected;
        private bool loaded;
        private bool loading;                // true while the code fills the controls
        private bool busy;                   // prevents competing actions
        private int selectedSessionId;       // 0 = no booking selected
        private int selectedRequestId;
        private DateTime selectedStart;      // start of the EXISTING booking (48-hour rule)
        private string selectedCourse;
        private string currentTutorId;

        public frmUpdateBooking() : this(0)
        {
        }

        public frmUpdateBooking(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            dgvBookings.ReadOnly = true;
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.MultiSelect = false;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.RowHeadersVisible = false;

            dtpSessionDate.MinDate = DateTime.Today;        // no past dates
            dtpSessionDate.Format = DateTimePickerFormat.Custom;
            dtpSessionDate.CustomFormat = "dd MMM yyyy";
            cboTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTutor.DropDownStyle = ComboBoxStyle.DropDownList;
            // Availability blocks in the database end by 17:00 and sessions last one hour.
            for (int hour = 8; hour <= 16; hour++)
                cboTimeSlot.Items.Add(hour.ToString("00") + ":00");

            lblRule.Text = RuleNoticeText;
            lblMessage.Text = "";
            UpdateControls();
        }

       

        private void byteBetterTutoringDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void dgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            ShowCurrentBooking();
            UpdateControls();
        }

      
        // Connect and load

        private void frmUpdateBooking_Load(object sender, EventArgs e)
        {
            connected = ConnectToDatabase();
            if (connected) RefreshBookings(null);
            UpdateControls();
        }

        private static string GetConnectionString()
        {
            using (OleDbConnection cn = DatabaseHelper.GetConnection())
            {
                return cn.ConnectionString;
            }
        }

        private bool ConnectToDatabase()
        {
            try
            {
                connectionString = GetConnectionString();
                string path = new OleDbConnectionStringBuilder(connectionString).DataSource;
                if (!File.Exists(path))
                {
                    ShowError("Database file not found.");
                    MessageBox.Show("The database file is missing from " + Application.StartupPath);
                    return false;
                }
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                }
                return true;
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Connection failed.");
                MessageBox.Show("Check the ACE provider and database access.");
                return false;
            }
        }

        // Guarded wrapper: loads the list and handles failures without crashing.
        private void RefreshBookings(int? selectId)
        {
            if (!connected || busy) return;
            busy = true;
            UpdateControls();
            ShowNeutral(LoadingMessage);
            try
            {
                LoadBookings(selectId);
                if (lblMessage.Text == LoadingMessage) ShowNeutral("");
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Database operation failed.");
                MessageBox.Show("Unable to load your bookings. Check database access.");
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Operation could not be completed.");
                MessageBox.Show("Close this page and open it again before retrying.");
            }
            finally
            {
                busy = false;
                UpdateControls();
            }
        }

        // Retrieves the student's Scheduled bookings and binds the grid.
        private void LoadBookings(int? selectId)
        {
            using (var fresh = new DataSet("BookingData"))
            {
                using (var connection = new OleDbConnection(connectionString))
                using (var adapter = new OleDbDataAdapter(
                    "SELECT s.[Session_ID], s.[Request_ID], s.[Tutor_ID], r.[Course_Code], " +
                    "t.[Tutor_FName] & ' ' & t.[Tutor_LName] AS [TutorName], " +
                    "s.[Session_Date], s.[Session_StartTime], s.[Session_ModeOfDelivery] " +
                    "FROM ([TutoringSession] AS s " +
                    "INNER JOIN [Tutor] AS t ON t.[Tutor_ID] = s.[Tutor_ID]) " +
                    "INNER JOIN [TutoringRequest] AS r ON r.[Request_ID] = s.[Request_ID] " +
                    "WHERE s.[Student_ID] = ? AND s.[Session_Status] = 'Scheduled' " +
                    "ORDER BY s.[Session_Date], s.[Session_StartTime]", connection))
                {
                    adapter.SelectCommand.Parameters.Add("@student", OleDbType.Integer).Value = studentId;
                    connection.Open();
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    adapter.Fill(fresh, "Bookings");
                }

                // Replace the displayed data only after the retrieval has succeeded.
                loading = true;
                try
                {
                    bookingSource.DataSource = null;
                    if (bookingData.Tables.Contains("Bookings")) bookingData.Tables.Remove("Bookings");
                    bookingData.Tables.Add(fresh.Tables["Bookings"].Copy());
                    bookingSource.DataSource = bookingData;
                    bookingSource.DataMember = "Bookings";
                    dgvBookings.DataSource = bookingSource;
                    FormatGrid();
                    loaded = true;
                    if (selectId.HasValue)
                    {
                        int position = bookingSource.Find("Session_ID", selectId.Value);
                        if (position >= 0) bookingSource.Position = position;
                    }
                }
                finally
                {
                    loading = false;
                }
                ShowCurrentBooking();
                UpdateControls();
                if (bookingSource.Count == 0) ShowNeutral("You have no bookings to change.");
            }
        }

        // Friendly headers and formats, ID columns stay hidden.
        private void FormatGrid()
        {
            foreach (DataGridViewColumn column in dgvBookings.Columns) column.Visible = false;
            ShowColumn("Course_Code", "Course");
            ShowColumn("TutorName", "Tutor");
            ShowColumn("Session_Date", "Session date");
            ShowColumn("Session_StartTime", "Time");
            ShowColumn("Session_ModeOfDelivery", "Mode");
            dgvBookings.Columns["Session_Date"].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvBookings.Columns["Session_StartTime"].DefaultCellStyle.Format = "HH:mm";
        }

        private void ShowColumn(string name, string header)
        {
            dgvBookings.Columns[name].Visible = true;
            dgvBookings.Columns[name].HeaderText = header;
        }

       
        // The selected booking and the availability display
        private void bookingSource_PositionChanged(object sender, EventArgs e)
        {
            if (loading) return;
            ShowCurrentBooking();
            UpdateControls();
        }

        private void bookingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            UpdateControls();
        }

        // Copies the selected booking into the date, time and tutor controls.
        private void ShowCurrentBooking()
        {
            errorProvider.Clear();
            selectedSessionId = 0;
            var row = bookingSource.Current as DataRowView;
            if (row == null)
            {
                cboTutor.DataSource = null;
                return;
            }
            selectedSessionId = Convert.ToInt32(row["Session_ID"]);
            selectedRequestId = Convert.ToInt32(row["Request_ID"]);
            currentTutorId = Convert.ToString(row["Tutor_ID"]);
            selectedCourse = Convert.ToString(row["Course_Code"]);
            DateTime date = ((DateTime)row["Session_Date"]).Date;
            TimeSpan time = ((DateTime)row["Session_StartTime"]).TimeOfDay;
            selectedStart = date + time;

            // Setting the controls must not trigger a tutor search for each change.
            bool wasLoading = loading;
            loading = true;
            dtpSessionDate.Value = date < dtpSessionDate.MinDate ? dtpSessionDate.MinDate : date;
            cboTimeSlot.SelectedItem = time.ToString(@"hh\:mm");
            loading = wasLoading;
            LoadTutors();
        }

        private void dtpSessionDate_ValueChanged(object sender, EventArgs e)
        {
            LoadTutors();
        }

        private void cboTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTutors();
        }

        // Fills cboTutor with the tutors free at the chosen date and time.
        private void LoadTutors()
        {
            if (loading || !connected || selectedSessionId == 0 || cboTimeSlot.SelectedIndex < 0) return;
            cboTutor.DataSource = null;
            try
            {
                TimeSpan slot = TimeSpan.Parse((string)cboTimeSlot.SelectedItem);
                DataTable tutors = TutorAvailability.GetAvailableTutors(
                    dtpSessionDate.Value.Date, slot, selectedCourse, selectedSessionId);
                cboTutor.DisplayMember = "TutorName";
                cboTutor.ValueMember = "Tutor_ID";
                cboTutor.DataSource = tutors;
                if (tutors.Rows.Count == 0)
                {
                    // Not an error: the form stays open and keeps the user's other choices.
                    ShowError(NoTutorMessage);
                }
                else
                {
                    // force a deliberate choice unless the current tutor is availabile 
                    ShowNeutral("");
                    cboTutor.SelectedIndex = -1;               
                    cboTutor.SelectedValue = currentTutorId;    
                }
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Database operation failed.");
                MessageBox.Show("Unable to check tutor availability. Check database access.",
                    "Tutoring System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Control availability: never writes to the database
   
        private void UpdateControls()
        {
            bool ready = connected && loaded && !busy;
            bool hasRow = bookingSource.Current is DataRowView;
            dgvBookings.Enabled = ready;
            dtpSessionDate.Enabled = cboTimeSlot.Enabled = cboTutor.Enabled = ready && hasRow;
            btnSave.Enabled = ready && hasRow;
            btnBack.Enabled = !busy;
        }

        // Saving the data
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!loaded || busy || !ValidateBooking()) return;
            busy = true;
            UpdateControls();
            ShowNeutral("Saving...");
            try
            {
                SaveBooking();
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                if (IsDuplicateKey(ex))
                {
                    // A unique index refused it: another student took the time a moment ago.
                    LoadTutors();
                    ShowError("That time is taken. Please choose another.");
                }
                else
                {
                    ShowError("Database operation failed.");
                    MessageBox.Show(SaveErrorMessage);
                }
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Operation could not be completed.");
                MessageBox.Show(SaveErrorMessage);
            }
            finally
            {
                busy = false;
                UpdateControls();
            }
        }

        // Inline ErrorProvider messages next to the fields; no MessageBox for simple validation.
        private bool ValidateBooking()
        {
            errorProvider.Clear();
            if (selectedSessionId == 0)
            {
                errorProvider.SetError(dgvBookings, "Please select the booking you want to change.");
                return false;
            }
            bool valid = true;
            if (cboTimeSlot.SelectedIndex < 0)
            {
                errorProvider.SetError(cboTimeSlot, "Please select a time slot.");
                valid = false;
            }
            else
            {
                // The NEW date and time must be in the future.
                TimeSpan slot = TimeSpan.Parse((string)cboTimeSlot.SelectedItem);
                string futureMessage = BookingRules.ValidateBooking(dtpSessionDate.Value.Date + slot);
                if (futureMessage.Length > 0)
                {
                    errorProvider.SetError(dtpSessionDate, futureMessage);
                    valid = false;
                }
            }
            if (cboTutor.SelectedValue == null)
            {
                errorProvider.SetError(cboTutor, "Please select a tutor.");
                valid = false;
            }
            if (!valid)
                ShowError(cboTutor.Items.Count == 0
                    ? NoTutorMessage : "Correct the highlighted fields before saving.");
            return valid;
        }

        private void SaveBooking()
        {
            // 1. The 48-hour rule, checked on the existing booking.
            string ruleMessage = BookingRules.ValidateChangeOrCancellation(selectedStart);
            if (ruleMessage.Length > 0)
            {
                ShowError(ruleMessage);
                return;
            }

            DateTime date = dtpSessionDate.Value.Date;
            TimeSpan slot = TimeSpan.Parse((string)cboTimeSlot.SelectedItem);
            string tutorId = Convert.ToString(cboTutor.SelectedValue);

            // 2. Re-check availability just before saving as the list may be out of date.
            DataTable free = TutorAvailability.GetAvailableTutors(
                date, slot, selectedCourse, selectedSessionId);
            if (!ContainsTutor(free, tutorId))
            {
                LoadTutors();
                ShowError("Sorry, that tutor is no longer available at that time. Please choose another.");
                return;
            }

            // 3. The student must not already have another session at that time.
            if (StudentHasClash(date, slot))
            {
                ShowError("Session already scheduled at that time. Please choose a different time.");
                return;
            }

            UpdateSession(tutorId, date, slot);
            RefreshAfterWrite(selectedSessionId, "Booking updated.");
        }

        private static bool ContainsTutor(DataTable tutors, string tutorId)
        {
            foreach (DataRow row in tutors.Rows)
                if (Convert.ToString(row["Tutor_ID"]) == tutorId) return true;
            return false;
        }

        private bool StudentHasClash(DateTime date, TimeSpan slot)
        {
            TimeSpan end = slot + TimeSpan.FromMinutes(TutorAvailability.SessionMinutes);
            using (var connection = new OleDbConnection(connectionString))
            using (var cmd = new OleDbCommand(
                "SELECT COUNT(*) FROM [TutoringSession] WHERE [Student_ID] = ? AND [Session_Date] = ? " +
                "AND [Session_StartTime] < ? AND [Session_EndTime] > ? " +
                "AND [Session_Status] <> 'Cancelled' AND [Session_ID] <> ?", connection))
            {
                // Positional order MUST match the SQL question marks.
                cmd.Parameters.Add("@student", OleDbType.Integer).Value = studentId;
                cmd.Parameters.Add("@date", OleDbType.Date).Value = date.Date;
                cmd.Parameters.Add("@newEnd", OleDbType.Date).Value = TutorAvailability.TimeToDb(end);
                cmd.Parameters.Add("@newStart", OleDbType.Date).Value = TutorAvailability.TimeToDb(slot);
                cmd.Parameters.Add("@me", OleDbType.Integer).Value = selectedSessionId;
                connection.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Updates the session and the request's assigned tutor together.
        // Disposing the transaction without Commit rolls both back.
        private void UpdateSession(string tutorId, DateTime date, TimeSpan slot)
        {
            TimeSpan end = slot + TimeSpan.FromMinutes(TutorAvailability.SessionMinutes);
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var cmd = new OleDbCommand(
                        "UPDATE [TutoringSession] SET [Tutor_ID] = ?, [Session_Date] = ?, " +
                        "[Session_StartTime] = ?, [Session_EndTime] = ? WHERE [Session_ID] = ?",
                        connection, transaction))
                    {
                        // Positional order MUST match the SQL question marks.
                        cmd.Parameters.Add("@tutor", OleDbType.VarWChar, 16).Value = tutorId;
                        cmd.Parameters.Add("@date", OleDbType.Date).Value = date.Date;
                        cmd.Parameters.Add("@start", OleDbType.Date).Value = TutorAvailability.TimeToDb(slot);
                        cmd.Parameters.Add("@end", OleDbType.Date).Value = TutorAvailability.TimeToDb(end);
                        cmd.Parameters.Add("@id", OleDbType.Integer).Value = selectedSessionId;
                        if (cmd.ExecuteNonQuery() != 1)
                            throw new InvalidOperationException("The update did not affect one row.");
                    }
                    using (var cmd = new OleDbCommand(
                        "UPDATE [TutoringRequest] SET [Tutor_ID] = ? WHERE [Request_ID] = ?",
                        connection, transaction))
                    {
                        cmd.Parameters.Add("@tutor", OleDbType.VarWChar, 16).Value = tutorId;
                        cmd.Parameters.Add("@request", OleDbType.Integer).Value = selectedRequestId;
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        // 3022 = Access refused a duplicate value in a unique index.
        private static bool IsDuplicateKey(OleDbException ex)
        {
            return ex.Errors.Count > 0 && ex.Errors[0].NativeError == 3022;
        }

        private void RefreshAfterWrite(int? id, string outcome)
        {
            try
            {
                LoadBookings(id);
                ShowSuccess(outcome);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // The write succeeded. Do not misreport a later refresh as a failed save.
                connected = loaded = false;
                MessageBox.Show(outcome + " The list could not refresh. Open this page again to continue.");
                ShowSuccess(outcome + " Open this page again to reload your bookings.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();   // returns to the main menu
        }

        // The data below the methods will be replaced with UiHelper calls when they exist.
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
    }
}

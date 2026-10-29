using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Database;


namespace TutoringAcademicSupport.Student.CancelBooking
{
    public partial class CancelBookingForm : Form
    {
        private const string RuleNoticeText = "Bookings cannot be changed or cancelled less than 48 hours before the session.";
        private const string LoadingMessage = "Loading your bookings...";
        private const string SaveErrorMessage = "An unexpected error has occured. Please try again.";
        private readonly DataSet bookingData = new DataSet("BookingData");
        private readonly int StudentId; // the student is already logged in
        private bool connected;
        private bool loaded;
        private bool loading; // true while the code fills the controls
        private bool busy; // prevents competing actions 
        private int selectedSessionId; // 0 = no booking selected
        private int selectedRequestId;
        private DateTime selectedStart; // start of the selected booking
        private string selectedTutorName = string.Empty;


        public CancelBookingForm(int studentId)
        {
            InitializeComponent();
            this.StudentId = studentId;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            dgvBookings.ReadOnly = true;
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.MultiSelect = false;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.RowHeadersVisible = false;

            lblRules.Text = RuleNoticeText;
            lblSelected.Text = "";
            lblMessage.Text = "";
            UpdateControls();
        }

        private void CancelBooking_Load(object sender, EventArgs e)
        {
            connected = ConnectToDatabase();
            if (connected) RefreshBookings();
            UpdateControls();
        }

        private bool ConnectToDatabase()
        {
            try
            {
                using (OleDbConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                }
                return true;
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Connection failed");
                MessageBox.Show("Check the ACE provider and database access.");
                return false;
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Database file not found");
                MessageBox.Show("The database file is missing from " + Application.StartupPath);
                return false;
            }
        }

        // this loads the list and handles failures without crashing
        private void RefreshBookings()
        {
            if (!connected || busy) return;
            busy = true;
            UpdateControls();
            ShowNeutral(LoadingMessage);
            try
            {
                LoadBookings();
                if (lblMessage.Text == LoadingMessage) ShowNeutral("");
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Database operation failed.");
                MessageBox.Show("Unable to load bookings. Check database access.");
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Operation could not be completed.");
                MessageBox.Show("Please close this page and open it again before retrying.");
            }
            finally
            {
                busy = false;
                UpdateControls();
            }
        }

        // retrieves the student's scheduled bookings and binds the grid
        private void LoadBookings()
        {
            using (var fresh = new DataSet("BookingData"))
            {
                using (OleDbConnection connection = DatabaseConnection.GetConnection())
                using (var adapter = new OleDbDataAdapter(
                    "SELECT s.[Session_ID], s.[Request_ID], s.[Tutor_ID], r.[Course_Code], " +
                    "t.[Tutor_FName] & ' ' & t.[Tutor_LName] AS [TutorName], " +
                    "s.[Session_Date], s.[Session_StartTime], s.[Session_ModeOfDelivery] " +
                    "FROM ([TutoringSession] s " +
                    "INNER JOIN [Tutor] t ON t.[Tutor_ID] = s.[Tutor_ID]) " +
                    "INNER JOIN [TutoringRequest] r ON r.[Request_ID] = s.[Request_ID] " +
                    "WHERE s.[Student_ID] = ? AND s.[Session_Status] = 'Scheduled' " +
                    "ORDER BY s.[Session_Date], s.[Session_StartTime]", connection))
                {
                    if (adapter.SelectCommand != null)
                    {
                        adapter.SelectCommand.Parameters.Add("@student", OleDbType.Integer).Value = StudentId;
                    }
                    connection.Open();
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    adapter.Fill(fresh, "Bookings");
                }

                // replace the displayed data only after the retrieval has succeeded.
                loading = true; 
                try
                {
                    bookingSource.DataSource = null;
                    if (bookingData.Tables.Contains("Bookings")) bookingData.Tables.Remove("Bookings");

                    var bookingsTable = fresh.Tables["Bookings"];
                    if (bookingsTable != null)
                    {
                        bookingData.Tables.Add(bookingsTable.Copy());
                    }

                    bookingSource.DataSource = bookingData;
                    bookingSource.DataMember = "Bookings";
                    dgvBookings.DataSource = bookingSource;
                    FormatGrid();
                    loaded = true;
                }
                finally
                {
                    loading = false;
                }
                ShowCurrentBooking();
                UpdateControls();
                if (bookingSource.Count == 0) ShowNeutral("You have no bookings to cancel.");
            }
        }

        // formats the data grid, the ID columns will be hidden.
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

        private void bookingSource_PositioneChanged(object sender, EventArgs e)
        {
            if (loading) return;
            ShowCurrentBooking();
            UpdateControls();
        }

        private void bookingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            UpdateControls();
        }

        private void ShowCurrentBooking()
        {
            errorProvider.Clear();
            selectedSessionId = 0;
            selectedTutorName = string.Empty;

            var row = bookingSource.Current as DataRowView;
            if (row == null)
            {
                lblSelected.Text = "";
                return;
            }

            selectedSessionId = Convert.ToInt32(row["Session_ID"]);
            selectedRequestId = Convert.ToInt32(row["Request_ID"]);
            selectedTutorName = Convert.ToString(row["TutorName"]) ?? string.Empty;
            selectedStart = ((DateTime)row["Session_Date"]).Date +
                            ((DateTime)row["Session_StartTime"]).TimeOfDay;
            lblSelected.Text = "Selected: booking with " + selectedTutorName + " on " +
                selectedStart.ToString("dd MMM yyyy") + " at " + selectedStart.ToString("HH:mm");
        }

        // the availability control never writes to the database
        private void UpdateControls()
        {
            bool ready = connected && loaded && !busy;
            bool hasRow = bookingSource.Current is DataRowView;
            dgvBookings.Enabled = ready;
            btnCancel.Enabled = ready && hasRow;
            btnBack.Enabled = !busy;
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (!loaded || busy) return;
            if (selectedSessionId == 0)
            {
                errorProvider.SetError(dgvBookings, "Please select the booking you want to cancel.");
                return;
            }

            // Validate the 48 hour rule
            string validationMessage = CancelBookingValidator.Validate(selectedStart);
            if (validationMessage.Length > 0)
            {
                ShowError(validationMessage);
                return;
            }

            // Confirmation: Yes/No, Warning icon, names the booking that will be cancelled, the default button is no.
            if (MessageBox.Show(
                "Are you sure you want to cancel your booking with " + selectedTutorName + " on " +
                selectedStart.ToString("dd MMM yyyy") + "?",
                "Cancel booking", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            busy = true;
            UpdateControls();
            ShowNeutral("Cancelling...");
            try
            {
                var request = new CancelBookingRequest(selectedSessionId, selectedRequestId, selectedStart, selectedTutorName);
                CancelBookingResult result = CancelBookingHandler.Handle(request);

                if (result.Success)
                {
                    RefreshAfterWrite(result.Message);
                }
                else
                {
                    ShowError(result.Message);
                    LoadBookings();
                }
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Cancellation failed.");
                MessageBox.Show(SaveErrorMessage);
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
        private void RefreshAfterWrite(string outcome)
        {
            try
            {
                LoadBookings();
                ShowSuccess(outcome);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // The write succeeded. Do not misreport a later refresh as a failed cancellation.
                connected = loaded = false;
                MessageBox.Show(outcome + " The list could not refresh. Open this page again to continue.");
                ShowSuccess(outcome + " Open this page again to reload your bookings.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();   // returns to the main menu
        }

        // the UiHelper will replace the commands in the methods below
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

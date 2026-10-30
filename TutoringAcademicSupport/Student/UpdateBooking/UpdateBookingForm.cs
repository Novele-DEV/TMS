using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.Common.Branding;
using TutoringAcademicSupport.Student.CancelBooking;

namespace TutoringAcademicSupport.Student.UpdateBooking
{
    public partial class UpdateBookingForm : Form
    {
        private readonly int? studentId; // the logged-in student, passed in by the student menu

        public UpdateBookingForm()
        {
            InitializeComponent();
            ByteBetterBrand.AddLogo(this, 80, fitAbove: cmbBooking);
            ScreenLayout.CentreContent(this);

            // The notice period comes from the one place it is defined.
            lblRules.Text = CancelBookingValidator.RuleNotice;

            // the delivery modes a session can have
            cmbMode.Items.Clear();
            cmbMode.Items.Add("In-person");
            cmbMode.Items.Add("Virtual");
            cmbMode.SelectedIndex = 0;
        }

        // Opened from the student menu, so the student's own bookings can be listed.
        public UpdateBookingForm(int studentId) : this()
        {
            this.studentId = studentId;
        }

        private void UpdateBookingForm_Load(object sender, EventArgs e)
        {
            LoadBookings();
        }

        // Lists the student's scheduled sessions, so they choose one instead of typing a session ID.
        private void LoadBookings(int? selectSessionId = null)
        {
            cmbBooking.Items.Clear();

            if (!studentId.HasValue)
            {
                SetEditing(false);
                ShowError("Open this page from the student menu to see your bookings.");
                return;
            }

            List<ScheduledBooking> bookings;
            try
            {
                bookings = UpdateBookingHandler.GetScheduledBookings(studentId.Value);
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                SetEditing(false);
                ShowError("Your bookings could not be loaded from the database. Please go back and try again.");
                return;
            }

            foreach (ScheduledBooking booking in bookings)
            {
                cmbBooking.Items.Add(booking);
            }

            if (bookings.Count == 0)
            {
                SetEditing(false);
                ShowNeutral("You have no scheduled bookings to update. Book a session from the student menu first.");
                return;
            }

            SetEditing(true);
            int index = bookings.FindIndex(b => b.SessionId == selectSessionId);
            cmbBooking.SelectedIndex = index >= 0 ? index : 0;
            if (selectSessionId is null)
            {
                ShowNeutral("Choose the booking to change, then set the new date, times or mode.");
            }
        }

        // Choosing a booking fills in its current details, ready to change.
        private void cmbBooking_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBooking.SelectedItem is not ScheduledBooking booking) return;

            dtpSession.Value = booking.SessionDate.Date;
            dtpStartTime.Value = DateTime.Today.Add(booking.StartTime.TimeOfDay);
            dtpEndTime.Value = DateTime.Today.Add(booking.EndTime.TimeOfDay);
            cmbMode.SelectedItem = cmbMode.Items.Contains(booking.ModeOfDelivery) ? booking.ModeOfDelivery : cmbMode.Items[0];
        }

        private void btnUpdateSession_Click(object sender, EventArgs e)
        {
            if (!studentId.HasValue || cmbBooking.SelectedItem is not ScheduledBooking booking)
            {
                ShowError("Choose the booking you want to update.");
                cmbBooking.Focus();
                return;
            }

            // Combine the selected date with the start and end times.
            DateTime sessionDate = dtpSession.Value.Date;
            DateTime sessionStart = sessionDate.Add(dtpStartTime.Value.TimeOfDay);
            DateTime sessionEnd = sessionDate.Add(dtpEndTime.Value.TimeOfDay);

            if (sessionEnd <= sessionStart)
            {
                ShowError("The end time must be after the start time. Please choose a later end time.");
                dtpEndTime.Focus();
                return;
            }

            UpdateBookingRequest request = new UpdateBookingRequest
            {
                SessionId = booking.SessionId,
                StudentId = studentId.Value,
                SessionDate = sessionDate,
                StartTime = sessionStart,
                EndTime = sessionEnd,
                TutorId = booking.TutorId,
                ModeOfDelivery = cmbMode.SelectedItem?.ToString() ?? string.Empty
            };

            // show that the update is in progress and stop it being sent twice
            btnUpdateSession.Enabled = false;
            ShowNeutral("Updating your booking...");
            Cursor = Cursors.WaitCursor;
            try
            {
                UpdateBookingResult result = new UpdateBookingHandler().Handle(request);
                if (result.Success)
                {
                    // reload so the list shows the new details, keeping the same booking selected
                    LoadBookings(booking.SessionId);
                    ShowSuccess(result.Message);
                }
                else
                {
                    // the student's changes stay on screen so they can adjust and try again
                    ShowError(result.Message);
                }
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                ShowError("The booking could not be updated. Please try again.");
            }
            finally
            {
                Cursor = Cursors.Default;
                btnUpdateSession.Enabled = cmbBooking.Items.Count > 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // closing returns to the student menu that opened this page
            Close();
        }

        // The date, time and mode fields are only usable once there is a booking to change.
        private void SetEditing(bool enabled)
        {
            cmbBooking.Enabled = dtpSession.Enabled = dtpStartTime.Enabled = dtpEndTime.Enabled = enabled;
            cmbMode.Enabled = btnUpdateSession.Enabled = enabled;
        }

        private void ShowError(string message)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#C62828");
            lblMessage.Text = message;
        }

        private void ShowSuccess(string message)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#2E7D32");
            lblMessage.Text = message + " ✓";
        }

        private void ShowNeutral(string message)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = message;
        }
    }
}

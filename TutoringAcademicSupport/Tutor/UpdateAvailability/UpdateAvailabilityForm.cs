using System.Data;
using System.Data.OleDb;
using System.Diagnostics;

namespace TutoringAcademicSupport.Tutor.UpdateAvailability
{
    public partial class UpdateAvailabilityForm : Form
    {
        // the days in the order a week is read, rather than alphabetical order
        private static readonly string[] WeekDays =
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private int? selectedAvailabilityId; // null while a new slot is being entered
        private bool loading;                 // ignores selection changes while the grid is refilled

        public UpdateAvailabilityForm(string tutorId = "")
        {
            InitializeComponent();

            cmbAvailDay.Items.AddRange(WeekDays);

            availabilityGrid.ReadOnly = true;
            availabilityGrid.AllowUserToAddRows = false;
            availabilityGrid.AllowUserToDeleteRows = false;
            availabilityGrid.AllowUserToResizeRows = false;
            availabilityGrid.MultiSelect = false;
            availabilityGrid.RowHeadersVisible = false;
            availabilityGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            availabilityGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            availabilityGrid.BackgroundColor = SystemColors.Window;

            // a grid selects its first row by itself when it is filled or shown; clear that,
            // so the form starts ready for a new slot instead of silently editing the first one
            availabilityGrid.DataBindingComplete += (_, _) =>
            {
                loading = true;
                availabilityGrid.ClearSelection();
                availabilityGrid.CurrentCell = null;
                loading = false;
            };

            // opened from the dashboard for one tutor, the tutor cannot be changed here
            txtTutorId.Text = tutorId;
            if (!string.IsNullOrWhiteSpace(tutorId))
            {
                txtTutorId.ReadOnly = true;
                txtTutorId.TabStop = false;
                btnLoad.Visible = false;
                Text = $"Tutor Availability - {tutorId}";
            }

            StartNewSlot();
        }

        private void UpdateAvailabilityForm_Load(object sender, EventArgs e)
        {
            if (txtTutorId.Text.Trim().Length > 0)
            {
                LoadAvailability();
                ActiveControl = cmbAvailDay; // ready to enter a new slot
            }
            else
            {
                ShowNeutral("Enter a tutor ID and choose Load to see that tutor's availability.");
                txtTutorId.Focus();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAvailability();
        }

        // Loads the tutor's slots. Returns false (and says why) when they could not be loaded.
        private bool LoadAvailability(bool reportCount = true)
        {
            string tutorId = txtTutorId.Text.Trim();
            if (tutorId.Length == 0)
            {
                ShowError("Enter a tutor ID.");
                return false;
            }

            DataTable availability;
            try
            {
                availability = UpdateTutorAvailabilityHandler.LoadForTutor(tutorId);
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                availabilityGrid.DataSource = null;
                ShowError("The tutor's availability could not be loaded from the database. Please try again.");
                return false;
            }

            // sort Monday to Sunday, then by start time
            availability.Columns.Add("DayOrder", typeof(int));
            foreach (DataRow row in availability.Rows)
            {
                row["DayOrder"] = Array.IndexOf(WeekDays, Convert.ToString(row["Avail_Day"]));
            }

            DataView view = availability.DefaultView;
            view.Sort = "DayOrder, Avail_StartTime";

            loading = true;
            availabilityGrid.DataSource = view;
            ShowColumns();
            availabilityGrid.ClearSelection();
            loading = false;

            StartNewSlot();

            if (reportCount)
            {
                if (availability.Rows.Count == 0)
                    ShowNeutral("This tutor has no availability slots yet. Add one on the right.");
                else
                    ShowNeutral($"{availability.Rows.Count} availability slot(s). Select one to change or delete it.");
            }

            return true;
        }

        // Shows only Day, Start and End, with readable headings and 24-hour times.
        private void ShowColumns()
        {
            foreach (DataGridViewColumn column in availabilityGrid.Columns)
            {
                column.Visible = column.Name is "Avail_Day" or "Avail_StartTime" or "Avail_EndTime";
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (availabilityGrid.Columns["Avail_Day"] is DataGridViewColumn day) day.HeaderText = "Day";
            if (availabilityGrid.Columns["Avail_StartTime"] is DataGridViewColumn start)
            {
                start.HeaderText = "Start";
                start.DefaultCellStyle.Format = "HH:mm";
            }
            if (availabilityGrid.Columns["Avail_EndTime"] is DataGridViewColumn end)
            {
                end.HeaderText = "End";
                end.DefaultCellStyle.Format = "HH:mm";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool updating = selectedAvailabilityId.HasValue;
            UpdateTutorAvailabilityRequest request = new()
            {
                TutorId = txtTutorId.Text.Trim(),
                AvailabilityId = selectedAvailabilityId,
                Day = cmbAvailDay.SelectedItem?.ToString() ?? string.Empty,
                StartTime = dtpStartTime.Value,
                EndTime = dtpEndTime.Value
            };

            try
            {
                UpdateTutorAvailabilityResult result = UpdateTutorAvailabilityHandler.Save(request);
                if (!result.Success)
                {
                    ShowError(result.Message);
                    return;
                }

                // reload first, then confirm, so the confirmation is not replaced by the slot count
                if (LoadAvailability(reportCount: false))
                {
                    ShowSuccess($"{request.Day} {request.StartTime:HH:mm}-{request.EndTime:HH:mm} was {(updating ? "updated" : "added")}. ✓");
                }
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                ShowError("The availability slot could not be saved to the database. Please try again.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!selectedAvailabilityId.HasValue)
            {
                ShowError("Select an availability slot to delete.");
                return;
            }

            string slot = $"{cmbAvailDay.SelectedItem} {dtpStartTime.Value:HH:mm}-{dtpEndTime.Value:HH:mm}";
            DialogResult answer = MessageBox.Show(
                this,
                $"Delete the {slot} slot?",
                "Delete Slot",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes) return;

            try
            {
                UpdateTutorAvailabilityResult result = UpdateTutorAvailabilityHandler.Delete(
                    txtTutorId.Text.Trim(),
                    selectedAvailabilityId.Value);
                if (!result.Success)
                {
                    ShowError(result.Message);
                    return;
                }

                if (LoadAvailability(reportCount: false))
                {
                    ShowSuccess($"{slot} was deleted. ✓");
                }
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                ShowError("The availability slot could not be deleted. Please try again.");
            }
        }

        // Selecting a slot puts its details on the right, ready to update or delete.
        // Only a selection the user makes counts (a click, or arrow keys while the grid has focus),
        // not one the grid makes by itself.
        private void availabilityGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (!loading && availabilityGrid.Focused)
            {
                ShowSelectedSlot();
            }
        }

        private void availabilityGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowSelectedSlot();
            }
        }

        private void ShowSelectedSlot()
        {
            if (availabilityGrid.SelectedRows.Count == 0 ||
                availabilityGrid.SelectedRows[0].DataBoundItem is not DataRowView selectedRow)
            {
                return;
            }

            selectedAvailabilityId = Convert.ToInt32(selectedRow["Avail_ID"]);
            cmbAvailDay.SelectedItem = Convert.ToString(selectedRow["Avail_Day"]);
            dtpStartTime.Value = DateTime.Today.Add(Convert.ToDateTime(selectedRow["Avail_StartTime"]).TimeOfDay);
            dtpEndTime.Value = DateTime.Today.Add(Convert.ToDateTime(selectedRow["Avail_EndTime"]).TimeOfDay);

            grpSlot.Text = "Change selected slot";
            btnSave.Text = "&Update Slot";
            btnDelete.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            availabilityGrid.ClearSelection();
            StartNewSlot();
            ShowNeutral("Enter the day and times for the new slot, then choose Add Slot.");
            cmbAvailDay.Focus();
        }

        // Resets the panel on the right for entering a new slot.
        private void StartNewSlot()
        {
            selectedAvailabilityId = null;
            cmbAvailDay.SelectedIndex = 0;
            dtpStartTime.Value = DateTime.Today.AddHours(9);
            dtpEndTime.Value = DateTime.Today.AddHours(10);

            grpSlot.Text = "New slot";
            btnSave.Text = "&Add Slot";
            btnDelete.Enabled = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // closing returns to the screen that opened this one
            Close();
        }

        private void ShowError(string message)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#C62828");
            lblMessage.Text = message;
        }

        private void ShowSuccess(string message)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#2E7D32");
            lblMessage.Text = message;
        }

        private void ShowNeutral(string message)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = message;
        }
    }
}

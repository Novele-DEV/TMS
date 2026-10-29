using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using TutoringAcademicSupport.Tutor;

namespace TutoringAcademicSupport.Tutor
{
    public partial class UpdateAvailabilityForm : Form
    {
        private readonly TextBox txtTutorId = new();
        private readonly DataGridView availabilityGrid = new();
        private int? selectedAvailabilityId;

        public UpdateAvailabilityForm(string tutorId = "")
        {
            InitializeComponent();

            Text = "Update Tutor Availability";
            ClientSize = new Size(800, 570);
            StartPosition = FormStartPosition.CenterParent;

            Controls.Add(new Label { Text = "Tutor ID", AutoSize = true, Location = new Point(20, 20) });
            txtTutorId.Location = new Point(100, 16);
            txtTutorId.Size = new Size(140, 27);
            txtTutorId.MaxLength = 8;
            txtTutorId.Text = tutorId;
            Controls.Add(txtTutorId);

            Button btnLoad = new() { Text = "Load", Location = new Point(250, 15), Size = new Size(85, 30) };
            btnLoad.Click += (_, _) => LoadAvailability();
            Controls.Add(btnLoad);

            cmbAvailDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvailDay.Items.AddRange(Enum.GetNames<DayOfWeek>());
            cmbAvailDay.SelectedIndex = 0;

            ConfigureTimePicker(dtpStartTime, new Point(320, 60));

            ConfigureTimePicker(dtpEndTime, new Point(545, 60));
            dtpEndTime.Value = DateTime.Today.AddHours(10);

            availabilityGrid.Location = new Point(20, 110);
            availabilityGrid.Size = new Size(750, 350);
            availabilityGrid.ReadOnly = true;
            availabilityGrid.AllowUserToAddRows = false;
            availabilityGrid.AllowUserToDeleteRows = false;
            availabilityGrid.MultiSelect = false;
            availabilityGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            availabilityGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            availabilityGrid.SelectionChanged += AvailabilityGrid_SelectionChanged;
            Controls.Add(availabilityGrid);

            Button btnSave = new() { Text = "Save Slot", Location = new Point(20, 475), Size = new Size(120, 35) };
            btnSave.Click += (_, _) => SaveAvailability();
            Controls.Add(btnSave);

            Button btnNew = new() { Text = "New Slot", Location = new Point(155, 475), Size = new Size(120, 35) };
            btnNew.Click += (_, _) => ClearSelection();
            Controls.Add(btnNew);

            Button btnDelete = new() { Text = "Delete Slot", Location = new Point(290, 475), Size = new Size(120, 35) };
            btnDelete.Click += (_, _) => DeleteAvailability();
            Controls.Add(btnDelete);

            lblMessage.Location = new Point(20, 525);
            lblMessage.Size = new Size(750, 30);

            if (!string.IsNullOrWhiteSpace(tutorId))
            {
                LoadAvailability();
            }
        }

        private static void ConfigureTimePicker(DateTimePicker picker, Point location)
        {
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "HH:mm";
            picker.ShowUpDown = true;
            picker.Value = DateTime.Today.AddHours(9);
            picker.Location = location;
            picker.Size = new Size(100, 27);
        }

        private void LoadAvailability()
        {
            string tutorId = txtTutorId.Text.Trim();
            if (tutorId.Length == 0)
            {
                ShowError("Enter a tutor ID.");
                return;
            }

            try
            {
                DataTable availability = UpdateTutorAvailabilityHandler.LoadForTutor(tutorId);
                if (availability.Rows.Count == 0)
                {
                    ShowError("No availability found for that tutor.");
                }
                else
                {
                    ShowNeutral($"Loaded {availability.Rows.Count} availability slot(s).");
                }

                availabilityGrid.DataSource = availability;
                availabilityGrid.ClearSelection();
                selectedAvailabilityId = null;
                if (availabilityGrid.Columns["Avail_ID"] != null)
                {
                    availabilityGrid.Columns["Avail_ID"].Visible = false;
                    availabilityGrid.Columns["Avail_StartTime"].DefaultCellStyle.Format = "HH:mm";
                    availabilityGrid.Columns["Avail_EndTime"].DefaultCellStyle.Format = "HH:mm";
                }

                selectedAvailabilityId = null;
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Could not load tutor availability from the database.");
                MessageBox.Show(this, ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAvailability()
        {
            UpdateTutorAvailabilityRequest request = new()
            {
                TutorId = txtTutorId.Text.Trim(),
                AvailabilityId = selectedAvailabilityId,
                Day = cmbAvailDay.Text,
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

                ShowSuccess(result.Message);
                LoadAvailability();
                ClearSelection();
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Could not save tutor availability.");
                MessageBox.Show(this, ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex);
                ShowError(ex.Message);
            }
        }

        private void DeleteAvailability()
        {
            if (!selectedAvailabilityId.HasValue)
            {
                ShowError("Select an availability slot to delete.");
                return;
            }

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

                ShowSuccess(result.Message);
                LoadAvailability();
                ClearSelection();
            }
            catch (OleDbException ex)
            {
                Debug.WriteLine(ex);
                ShowError("Could not delete tutor availability.");
                MessageBox.Show(this, ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AvailabilityGrid_SelectionChanged(object? sender, EventArgs e)
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
        }

        private void ClearSelection()
        {
            selectedAvailabilityId = null;
            availabilityGrid.ClearSelection();
            if (cmbAvailDay.Items.Count > 0)
            {
                cmbAvailDay.SelectedIndex = 0;
            }

            dtpStartTime.Value = DateTime.Today.AddHours(9);
            dtpEndTime.Value = DateTime.Today.AddHours(10);
        }

        private void ShowError(string message)
        {
            lblMessage.ForeColor = Color.Firebrick;
            lblMessage.Text = message;
        }

        private void ShowSuccess(string message)
        {
            lblMessage.ForeColor = Color.DarkGreen;
            lblMessage.Text = message;
        }

        private void ShowNeutral(string message)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = message;
        }

        private void UpdateAvailabilityForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ViewAvailabilityForm? viewAvailabilityForm = Owner as ViewAvailabilityForm
                ?? Application.OpenForms.OfType<ViewAvailabilityForm>().FirstOrDefault();

            if (viewAvailabilityForm != null)
            {
                viewAvailabilityForm.Show();
                viewAvailabilityForm.Activate();
            }

            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSelection();
            cmbAvailDay.SelectedIndex = -1;
            ShowNeutral("Availability fields cleared.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAvailability();
        }
    }
}

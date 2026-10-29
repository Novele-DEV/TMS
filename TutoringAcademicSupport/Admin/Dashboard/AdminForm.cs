using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TutoringAcademicSupport.Admin.AddTutor;
using TutoringAcademicSupport.Admin.EditTutor;
using TutoringAcademicSupport.Admin.Reports;
using TutoringAcademicSupport.Common.Database;
using TutoringAcademicSupport.Tutor.UpdateAvailability;

namespace TutoringAcademicSupport.Admin.Dashboard
{
    public partial class AdminForm : Form
    {
        // friendly headings for the Tutor table columns, instead of the database column names
        private static readonly Dictionary<string, string> ColumnHeadings = new()
        {
            ["Tutor_ID"] = "Tutor ID",
            ["Tutor_FName"] = "First name",
            ["Tutor_LName"] = "Last name",
            ["Tutor_Email"] = "Email",
            ["Tutor_Phone"] = "Phone",
            ["Tutor_AcademicAverage"] = "Academic average",
            ["Tutor_PreferredMode"] = "Preferred mode"
        };

        // the columns the search box looks in
        private static readonly string[] SearchColumns = { "Tutor_ID", "Tutor_FName", "Tutor_LName", "Tutor_Email" };

        private bool tutorsLoaded; // false when the tutor list could not be read from the database

        public AdminForm() : this(string.Empty)
        {
        }

        public AdminForm(string adminName)
        {
            InitializeComponent();

            lblWelcome.Text = string.IsNullOrWhiteSpace(adminName) ? "Welcome" : $"Welcome, {adminName}";

            tutorDataGridView.AutoGenerateColumns = true;
            tutorDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tutorDataGridView.MultiSelect = false;
            tutorDataGridView.ReadOnly = true;
            tutorDataGridView.AllowUserToAddRows = false;
            tutorDataGridView.AllowUserToDeleteRows = false;
            tutorDataGridView.RowHeadersVisible = false;
            tutorDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tutorDataGridView.BackgroundColor = SystemColors.Window;
            tutorDataGridView.DataSource = tutorBindingSource;
            tutorDataGridView.DataBindingComplete += (_, _) => ApplyColumnHeadings();

            UpdateSelectionButtons();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {// This method is called when the AdminForm is loaded.
         // It attempts to load the tutor records from the database and bind them to the DataGridView.
            LoadTutorList();
        }

        // Loads the tutors into the grid. A failure clears the grid and says so,
        // so it never looks like there are simply no tutors.
        private bool LoadTutorList()
        {
            try
            {
                DatabaseConnection.LoadTutors(tutorBindingSource);
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException or FileNotFoundException)
            {
                Debug.WriteLine(ex);
                tutorsLoaded = false;
                tutorBindingSource.DataSource = null;
                UpdateCount();
                UpdateSelectionButtons();
                ShowError("The tutor list could not be loaded from the database. Please try again later.");
                return false;
            }

            tutorsLoaded = true;
            ApplySearch();
            return true;
        }

        private void ApplyColumnHeadings()
        {
            foreach (DataGridViewColumn column in tutorDataGridView.Columns)
            {
                if (ColumnHeadings.TryGetValue(column.DataPropertyName, out string? heading))
                {
                    column.HeaderText = heading;
                }

                // email addresses are the longest values, so that column gets more room
                column.FillWeight = column.DataPropertyName == "Tutor_Email" ? 220 : 100;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearch();
        }

        // Shows only the tutors whose ID, name or email contains the search text.
        private void ApplySearch()
        {
            if (!tutorsLoaded || tutorBindingSource.DataSource is not DataTable tutors) return;

            string text = txtSearch.Text.Trim();
            string escaped = EscapeLikeValue(text);

            tutorBindingSource.Filter = text.Length == 0
                ? null
                : string.Join(" OR ", SearchColumns
                    .Where(tutors.Columns.Contains)
                    .Select(column => $"Convert([{column}], 'System.String') LIKE '%{escaped}%'"));

            UpdateCount();
            UpdateSelectionButtons();
        }

        // Search text is placed inside a filter expression, so quotes and wildcard characters are escaped.
        private static string EscapeLikeValue(string value)
        {
            StringBuilder escaped = new();
            foreach (char c in value)
            {
                if (c is '*' or '%' or '[' or ']') escaped.Append('[').Append(c).Append(']');
                else if (c == '\'') escaped.Append("''");
                else escaped.Append(c);
            }

            return escaped.ToString();
        }

        private void UpdateCount()
        {
            if (!tutorsLoaded || tutorBindingSource.DataSource is not DataTable tutors)
            {
                lblCount.Text = string.Empty;
                return;
            }

            int shown = tutorBindingSource.Count;
            lblCount.Text = shown == 0 && txtSearch.Text.Trim().Length > 0
                ? $"No tutors match \"{txtSearch.Text.Trim()}\"."
                : $"Showing {shown} of {tutors.Rows.Count} tutors";
        }

        private void tutorDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectionButtons();
        }

        // Edit and Tutor Availability work on the selected tutor, so they are only available when one is selected.
        private void UpdateSelectionButtons()
        {
            bool tutorSelected = tutorsLoaded && tutorDataGridView.SelectedRows.Count > 0;
            btnEdit.Enabled = tutorSelected;
            btnUpdateAvailability.Enabled = tutorSelected;
        }

        private void btnAddTutor_Click(object sender, EventArgs e)
        {// This method is called when the "Add Tutor" button is clicked.
            using AddTutorForm addTutorForm = new();
            addTutorForm.ShowDialog(this);

            if (!LoadTutorList()) return;

            if (addTutorForm.AddedCount == 1)
            {
                SelectTutor(addTutorForm.LastAddedTutorId);
                ShowSuccess($"Tutor {addTutorForm.LastAddedTutorId} was added. ✓");
            }
            else if (addTutorForm.AddedCount > 1)
            {
                SelectTutor(addTutorForm.LastAddedTutorId);
                ShowSuccess($"{addTutorForm.AddedCount} tutors were added (latest: {addTutorForm.LastAddedTutorId}). ✓");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedTutor();
        }

        private void tutorDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { // double-clicking a tutor row opens it for editing, the same as Edit Selected
            if (e.RowIndex >= 0)
            {
                EditSelectedTutor();
            }
        }

        private void EditSelectedTutor()
        {
            string? tutorId = SelectedTutorId();
            if (tutorId is null) return;

            using EditTutorForm editTutorForm = new(tutorId);
            DialogResult result = editTutorForm.ShowDialog(this);

            if (!LoadTutorList()) return;

            SelectTutor(tutorId);
            if (result == DialogResult.OK)
            {
                ShowSuccess($"Tutor {tutorId} was updated. ✓");
            }
        }

        private void btnUpdateAvailability_Click(object sender, EventArgs e)
        {
            string? tutorId = SelectedTutorId();
            if (tutorId is null) return;

            using UpdateAvailabilityForm form = new(tutorId);
            form.ShowDialog(this);
        }

        // The Tutor_ID of the selected row, or null (after telling the admin why) when there is none.
        private string? SelectedTutorId()
        {
            if (tutorDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a tutor record first.",
                    "No Tutor Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return null;
            }

            if (tutorDataGridView.SelectedRows[0].DataBoundItem is not DataRowView selectedRow)
            {// This checks if the selected row is a valid DataRowView. If not, it shows an error message and returns.
                MessageBox.Show(
                    "The selected row is not a valid tutor record.",
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }

            return Convert.ToString(selectedRow["Tutor_ID"]) ?? string.Empty;
        }

        // Selects a tutor's row after the list is reloaded, so the admin keeps their place.
        private void SelectTutor(string tutorId)
        {
            foreach (DataGridViewRow row in tutorDataGridView.Rows)
            {
                if (row.DataBoundItem is DataRowView view && Convert.ToString(view["Tutor_ID"]) == tutorId)
                {
                    tutorDataGridView.CurrentCell = row.Cells.Cast<DataGridViewCell>().First(c => c.Visible);
                    row.Selected = true;
                    return;
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        { // closing the dashboard returns to the log in form, which shows "You have been logged out."
            Close();
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {// this method is called when the "Generate Reports" button is clicked.
         // It opens the ReportGenerationForm as a modal dialog.
            using ReportGenerationForm reportForm = new();
            reportForm.ShowDialog(this);
        }

        private void ShowSuccess(string text)
        {
            lblStatus.ForeColor = ColorTranslator.FromHtml("#2E7D32");
            lblStatus.Text = text;
        }

        private void ShowError(string text)
        {
            lblStatus.ForeColor = ColorTranslator.FromHtml("#C62828");
            lblStatus.Text = text;
        }
    }
}

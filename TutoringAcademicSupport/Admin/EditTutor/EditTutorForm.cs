using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Admin.EditTutor
{
    public partial class EditTutorForm : Form
    {
        private readonly string tutorId = string.Empty;

        public EditTutorForm()
        {
            InitializeComponent();
        }

        public EditTutorForm(string tutorId)
        {
            InitializeComponent();
            this.tutorId = tutorId;

            LoadTutorRecord();
        }
        private void LoadTutorRecord()
        {
            try
            {
                DataTable tutorTable = DatabaseConnection.LoadTutor(tutorId);

                if (tutorTable.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "The selected tutor could not be found.",
                        "Tutor Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    Close();
                    return;
                }

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = false;
                dataGridView1.SelectionMode =
                    DataGridViewSelectionMode.CellSelect;
                dataGridView1.DataSource = tutorTable;

                dataGridView1.Columns["Tutor_ID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            //return to the AdminForm when the "Return" button is clicked.
            if (Owner is AdminForm adminForm)
            {
                adminForm.Show();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clear updates made to the form when the "Clear" button is clicked.

            LoadTutorRecord();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //save changes made to the tutor record when the "Add" button is clicked.
            dataGridView1.EndEdit(); // commits a cell that is still being typed in

            if (dataGridView1.DataSource is not DataTable tutorTable || tutorTable.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There is no tutor record to save.",
                    "Nothing to Save",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            DataRow row = tutorTable.Rows[0];
            var request = new EditTutorRequest(
                tutorId,
                CellText(row, "Tutor_FName"),
                CellText(row, "Tutor_LName"),
                CellText(row, "Tutor_Email"),
                CellText(row, "Tutor_Phone"),
                CellText(row, "Tutor_AcademicAverage"),
                CellText(row, "Tutor_PreferredMode"));

            string problem = EditTutorValidator.Validate(request);
            if (problem.Length > 0)
            {
                MessageBox.Show(problem, "Check Tutor Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                EditTutorResult result = EditTutorHandler.Handle(request);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message, "Tutor Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(result.Message, "Tutor Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException or FileNotFoundException)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(
                    "The tutor changes could not be saved to the database. Please try again.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // reads a grid value as trimmed text; an empty cell becomes an empty string
        private static string CellText(DataRow row, string column)
        {
            return Convert.ToString(row[column], CultureInfo.CurrentCulture)?.Trim() ?? string.Empty;
        }
    }
}
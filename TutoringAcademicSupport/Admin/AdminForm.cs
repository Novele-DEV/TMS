using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TutoringAcademicSupport.Admin.AddTutor;
using TutoringAcademicSupport.Admin.EditTutor;
using TutoringAcademicSupport.Admin.Reports;
using TutoringAcademicSupport.Common.Database;
using TutoringAcademicSupport.LogIn;

namespace TutoringAcademicSupport.Admin
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();


            tutorDataGridView.AutoGenerateColumns = true;
            tutorDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tutorDataGridView.MultiSelect = false;
            tutorDataGridView.ReadOnly = true;
            tutorDataGridView.DataSource = tutorBindingSource;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {// This method is called when the AdminForm is loaded.
         // It attempts to load the tutor records from the database and bind them to the DataGridView.
            try
            {
                DatabaseConnection.LoadTutors(tutorBindingSource);
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

        private void btnAddTutor_Click(object sender, EventArgs e)
        {// This method is called when the "Add Tutor" button is clicked.
            using AddTutorForm addTutorForm = new();
            addTutorForm.ShowDialog(this);

            DatabaseConnection.LoadTutors(tutorBindingSource);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        { 
            if (tutorDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a tutor record first.",
                    "No Tutor Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (tutorDataGridView.SelectedRows[0].DataBoundItem is not DataRowView selectedRow)
            {// This checks if the selected row is a valid DataRowView. If not, it shows an error message and returns.
                MessageBox.Show(
                    "The selected row is not a valid tutor record.",
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            string tutorId = Convert.ToString(selectedRow["Tutor_ID"]) ?? string.Empty;

            using EditTutorForm editTutorForm = new(tutorId);
            editTutorForm.ShowDialog(this);

            DatabaseConnection.LoadTutors(tutorBindingSource);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        { // this button takes the user back to the MainMenuForm when clicked.
            MainMenuForm? mainMenu = Application
                .OpenForms
                .OfType<MainMenuForm>()
                .FirstOrDefault();

            if (mainMenu != null)
            {
                mainMenu.Show();
                mainMenu.Activate();
            }

            Close();
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {// this method is called when the "Generate Reports" button is clicked.
         // It opens the ReportGenerationForm as a modal dialog.
            using ReportGenerationForm reportForm = new();
            reportForm.ShowDialog(this);
        }
    }
}
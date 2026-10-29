using System;
using System.Data;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Admin.EditTutor
{
    public partial class EditTutorForm : Form
    {
        private readonly int tutorId;

        public EditTutorForm()
        {
            InitializeComponent();
        }

        public EditTutorForm(int tutorId)
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

        }
    }
}
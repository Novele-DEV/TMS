using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutoring_Management_System
{
    public partial class TutorManagementForm : Form
    {
        public TutorManagementForm()
        {
            InitializeComponent();
        }

        private void tutorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tutorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.byteBetter_TutoringDataSet);

        }

        private void TutorManagementForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'byteBetter_TutoringDataSet.Tutor' table. You can move, or remove it, as needed.
            this.tutorTableAdapter.Fill(this.byteBetter_TutoringDataSet.Tutor);
            
        }

        //The edit button before changing it to btnEdit
        private void button2_Click(object sender, EventArgs e)
        {
            EditSelectedTutor();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tutorDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSelectedTutor();
            }
        }

        private void LoadTutors(string selectTutorId)
        {
            try
            {
                this.tutorTableAdapter.Fill(this.byteBetter_TutoringDataSet.Tutor);
                if (!string.IsNullOrEmpty(selectTutorId))
                {
                    int index = this.tutorBindingSource.Find("Tutor_ID", selectTutorId);
                    if (index >= 0)
                    {
                        this.tutorBindingSource.Position = index;
                    }
                }
                btnEdit.Enabled = this.tutorBindingSource.Count > 0;
            }
            catch (OleDbException)
            {
                MessageBox.Show("The tutor list could not be loaded because of a database error. Check the database file and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Could not connect to the database. Check that the Access database file and its driver are available.","Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditSelectedTutor()
        {
            DataRowView row = this.tutorBindingSource.Current as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Select a tutor in the list first.", "No tutor selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OpenTutorDetails(Convert.ToString(row["Tutor_ID"]));
        }

        private void OpenTutorDetails(string? tutorId)
        {
            using (var f = new TutorDetailsForm(tutorId))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                    LoadTutors(f.SavedTutorId);
            }
        }

        private void btnAddTutor_Click(object sender, EventArgs e)
        {
            OpenTutorDetails(null);
        }
    }
}

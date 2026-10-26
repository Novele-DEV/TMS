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
            AppTheme.Register(this);
            tutorDataGridView.CellDoubleClick += tutorDataGridView_CellDoubleClick;
            tutorDataGridView.KeyDown += tutorDataGridView_KeyDown;
        }

        private void tutorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tutorBindingSource.EndEdit();
            try
            {
                this.tableAdapterManager.UpdateAll(this.byteBetter_TutoringDataSet);
            }
            catch (OleDbException)
            {
                MessageBox.Show(
                    "The tutoring database could not be opened. Close Microsoft Access and try again.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(
                    "The tutor changes could not be saved. Please try again.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TutorManagementForm_Load(object sender, EventArgs e)
        {
            LoadTutors(string.Empty);
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
                tutorDataGridView.Rows[e.RowIndex].Selected = true;
        }

        private void tutorDataGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= tutorDataGridView.Rows.Count)
                return;

            DataRowView? row = tutorDataGridView.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Select a tutor in the list first.", "No tutor selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string? tutorId = Convert.ToString(row["Tutor_ID"]);
            if (string.IsNullOrWhiteSpace(tutorId))
            {
                MessageBox.Show("The selected tutor could not be identified.", "Tutor Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenTutorDetails(tutorId);
        }

        private void tutorDataGridView_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;
            EditSelectedTutor();
        }

        private void LoadTutors(string selectTutorId)
        {
            try
            {
                this.tutorTableAdapter.Fill(this.byteBetter_TutoringDataSet.Tutor);
                tutorDataGridView.ClearSelection();
                if (!string.IsNullOrEmpty(selectTutorId))
                {
                    int index = this.tutorBindingSource.Find("Tutor_ID", selectTutorId);
                    if (index >= 0)
                    {
                        this.tutorBindingSource.Position = index;
                        if (index < tutorDataGridView.Rows.Count)
                        {
                            tutorDataGridView.Rows[index].Selected = true;
                            if (tutorDataGridView.Rows[index].Cells.Count > 0)
                                tutorDataGridView.CurrentCell = tutorDataGridView.Rows[index].Cells[0];
                        }
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
            DataRowView? row = null;
            if (tutorDataGridView.SelectedRows.Count > 0)
                row = tutorDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
            else if (tutorDataGridView.SelectedCells.Count > 0)
                row = tutorDataGridView.SelectedCells[0].OwningRow.DataBoundItem as DataRowView;

            if (row == null)
            {
                MessageBox.Show("Select a tutor in the list first.", "No tutor selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string? tutorId = Convert.ToString(row["Tutor_ID"]);
            if (string.IsNullOrWhiteSpace(tutorId))
            {
                MessageBox.Show("The selected tutor could not be identified.", "Tutor Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenTutorDetails(tutorId);
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

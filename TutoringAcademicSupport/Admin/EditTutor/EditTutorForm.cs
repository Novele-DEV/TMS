using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.Common.Branding;
using TutoringAcademicSupport.Common.Database;
using TutoringAcademicSupport.Common.Files;

namespace TutoringAcademicSupport.Admin.EditTutor
{
    public partial class EditTutorForm : Form
    {
        private readonly string tutorId = string.Empty;

        // the values as loaded from the database, used by Undo Changes and the unsaved-changes check
        private string[] savedValues = Array.Empty<string>();
        private string? selectedCurriculumVitaePath;
        private bool hasCurriculumVitae;

        // copies opened with View CV, removed again when the form closes
        private readonly List<string> temporaryCopies = new();

        public EditTutorForm()
        {
            InitializeComponent();
            ByteBetterBrand.AddLogo(this, 80, fitAbove: txtTutorID);
            ScreenLayout.CentreContent(this);
            FormClosed += (_, _) => DeleteTemporaryCopies();
        }

        public EditTutorForm(string tutorId) : this()
        {
            this.tutorId = tutorId;
        }

        private void EditTutorForm_Load(object sender, EventArgs e)
        {
            if (tutorId.Length > 0)
            {
                LoadTutorRecord();
            }
        }

        private void LoadTutorRecord()
        {
            DataTable tutorTable;
            try
            {
                tutorTable = DatabaseConnection.LoadTutor(tutorId);
                hasCurriculumVitae = TutorHasCurriculumVitae();
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException or FileNotFoundException)
            {
                Debug.WriteLine(ex);
                SetFieldsEnabled(false);
                ShowError("The tutor's details could not be loaded from the database. Please return and try again.");
                return;
            }

            if (tutorTable.Rows.Count == 0)
            {
                MessageBox.Show(
                    "The selected tutor could not be found.",
                    "Tutor Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                BeginInvoke(Close); // the form cannot close while it is still loading
                return;
            }

            DataRow row = tutorTable.Rows[0];
            txtTutorID.Text = tutorId;
            Text = $"Edit Tutor - {tutorId}";

            ShowValues(new[]
            {
                CellText(row, "Tutor_FName"),
                CellText(row, "Tutor_LName"),
                CellText(row, "Tutor_Email"),
                CellText(row, "Tutor_Phone"),
                AverageText(row["Tutor_AcademicAverage"]),
                CellText(row, "Tutor_PreferredMode")
            });

            savedValues = CurrentValues();
            lblStatus.Text = string.Empty;
            txtTutorFName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //save changes made to the tutor record when the "Save Changes" button is clicked.
            string[] values = CurrentValues();
            var request = new EditTutorRequest(
                tutorId,
                values[0],
                values[1],
                values[2],
                values[3],
                values[4],
                values[5],
                selectedCurriculumVitaePath);

            string problem = EditTutorValidator.Validate(request);
            if (problem.Length > 0)
            {
                ShowError(problem);
                return;
            }

            try
            {
                EditTutorResult result = EditTutorHandler.Handle(request);
                if (!result.Success)
                {
                    ShowError(result.Message);
                    return;
                }

                savedValues = values;
                DialogResult = DialogResult.OK; // tells the dashboard the save worked, so it can confirm the update
                Close();
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException or FileNotFoundException)
            {
                Debug.WriteLine(ex);
                ShowError("The tutor changes could not be saved to the database. Please try again.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //undo changes made on the form, putting back the details as they were loaded.
            if (savedValues.Length == 0) return;

            ShowValues(savedValues);
            ShowNeutral("Your changes were undone.");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //return to the AdminForm when the "Back" button is clicked.
            Close();
        }

        private void btnBrowseCurriculumVitae_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new()
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Select Curriculum Vitae PDF",
                CheckFileExists = true,
                Multiselect = false
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            selectedCurriculumVitaePath = dialog.FileName;
            txtCurriculumVitae.Text = Path.GetFileName(dialog.FileName);
            UpdateCurriculumVitaeStatus();
        }

        private void btnViewCurriculumVitae_Click(object sender, EventArgs e)
        {
            byte[]? curriculumVitae = ReadSavedCurriculumVitae();
            if (curriculumVitae is null) return;

            try
            {
                // the PDF is in the database, so a temporary copy is what opens in the PDF viewer
                string copy = Path.Combine(Path.GetTempPath(), $"CV-{tutorId}-{Guid.NewGuid():N}.pdf");
                File.WriteAllBytes(copy, curriculumVitae);
                temporaryCopies.Add(copy);
                Process.Start(new ProcessStartInfo(copy) { UseShellExecute = true });
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidOperationException or System.ComponentModel.Win32Exception)
            {
                Debug.WriteLine(ex);
                ShowError("The CV could not be opened. Use Download CV to save a copy instead.");
            }
        }

        private void btnDownloadCurriculumVitae_Click(object sender, EventArgs e)
        {
            byte[]? curriculumVitae = ReadSavedCurriculumVitae();
            if (curriculumVitae is null) return;

            using SaveFileDialog dialog = new()
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save Curriculum Vitae",
                FileName = $"{tutorId} CV.pdf"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                File.WriteAllBytes(dialog.FileName, curriculumVitae);
                ShowNeutral("The CV was saved.");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                Debug.WriteLine(ex);
                ShowError("The CV could not be saved. Close the file if it is open, then try again.");
            }
        }

        // Reads the stored CV, or says why it cannot be used and returns null.
        private byte[]? ReadSavedCurriculumVitae()
        {
            try
            {
                byte[]? curriculumVitae = DatabaseConnection.LoadCurriculumVitae(tutorId);
                if (curriculumVitae is not null && CurriculumVitaeFile.IsPdf(curriculumVitae))
                {
                    return curriculumVitae;
                }

                ShowError("The saved CV could not be read as a PDF.");
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException or FileNotFoundException)
            {
                Debug.WriteLine(ex);
                ShowError("The CV could not be loaded from the database. Please try again.");
            }

            return null;
        }

        // A copy that is still open in a PDF viewer cannot be deleted, so it is left for Windows to clear out.
        private void DeleteTemporaryCopies()
        {
            foreach (string copy in temporaryCopies)
            {
                try
                {
                    File.Delete(copy);
                }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        // Asks before closing when there are changes that have not been saved.
        private void EditTutorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK || !HasUnsavedChanges()) return;

            DialogResult answer = MessageBox.Show(
                "You have changes that have not been saved. Close without saving?",
                "Unsaved Changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            e.Cancel = answer != DialogResult.Yes;
        }

        private bool HasUnsavedChanges()
        {
            return savedValues.Length > 0 &&
                (!savedValues.SequenceEqual(CurrentValues()) || selectedCurriculumVitaePath is not null);
        }

        private string[] CurrentValues()
        {
            return new[]
            {
                txtTutorFName.Text.Trim(),
                txtTutorLName.Text.Trim(),
                txtTutorEmail.Text.Trim(),
                txtTutorPhoneNo.Text.Trim(),
                txtAcademicAverage.Text.Trim(),
                cmbPreferredMode.SelectedItem?.ToString() ?? string.Empty
            };
        }

        private void ShowValues(string[] values)
        {
            selectedCurriculumVitaePath = null;
            txtCurriculumVitae.Clear();
            UpdateCurriculumVitaeStatus();
            txtTutorFName.Text = values[0];
            txtTutorLName.Text = values[1];
            txtTutorEmail.Text = values[2];
            txtTutorPhoneNo.Text = values[3];
            txtAcademicAverage.Text = values[4];
            cmbPreferredMode.SelectedIndex = cmbPreferredMode.Items.IndexOf(values[5]);
        }

        private void SetFieldsEnabled(bool enabled)
        {
            txtTutorFName.Enabled = txtTutorLName.Enabled = txtTutorEmail.Enabled = enabled;
            txtTutorPhoneNo.Enabled = txtAcademicAverage.Enabled = cmbPreferredMode.Enabled = enabled;
            btnAdd.Enabled = btnClear.Enabled = btnBrowseCurriculumVitae.Enabled = enabled;
        }

        private bool TutorHasCurriculumVitae()
        {
            const string query = """
                SELECT COUNT(*)
                FROM [Tutor]
                WHERE [Tutor_ID] = ? AND [CurriculumVitae] IS NOT NULL
                """;

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            using OleDbCommand command = new(query, connection);
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        private void UpdateCurriculumVitaeStatus()
        {
            lblCurriculumVitaeStatus.Text = selectedCurriculumVitaePath is not null
                ? "New CV selected"
                : hasCurriculumVitae ? "CV on file" : "No CV uploaded";

            btnViewCurriculumVitae.Enabled = btnDownloadCurriculumVitae.Enabled = hasCurriculumVitae;
        }

        // reads a database value as trimmed text; an empty value becomes an empty string
        private static string CellText(DataRow row, string column)
        {
            return Convert.ToString(row[column], CultureInfo.CurrentCulture)?.Trim() ?? string.Empty;
        }

        // the average is shown the way it is typed, e.g. "82,5" where a decimal comma is used
        private static string AverageText(object value)
        {
            return value is DBNull ? string.Empty : Convert.ToDouble(value).ToString("0.##", CultureInfo.CurrentCulture);
        }

        private void ShowError(string text)
        {
            lblStatus.ForeColor = ColorTranslator.FromHtml("#C62828");
            lblStatus.Text = text;
        }

        private void ShowNeutral(string text)
        {
            lblStatus.ForeColor = SystemColors.ControlText;
            lblStatus.Text = text;
        }
    }
}

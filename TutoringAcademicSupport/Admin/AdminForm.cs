using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Admin
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

            try
            {
                DatabaseConnection.LoadTutors(tutorBindingSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unable to load tutors: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

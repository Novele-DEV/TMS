using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutoring_Management_System
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var f = new TutorManagementForm())
            {
                f.ShowDialog();
            }
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Are you sure you want to log out?", "LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
                this.Close();
        }

        private void btnBookTutorial_Click(object sender, EventArgs e)
        {
            using (var form = new TutoringManagementSystem.SessionBookingForm())
            {
                form.ShowDialog(this);
            }
        }
    }
}

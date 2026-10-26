using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using TutoringManagementSystem;

namespace Tutoring_Management_System
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
            AppTheme.Register(this);
        }

        private void studentPanel_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = AppTheme.IsDarkMode
                ? Color.FromArgb(144, 180, 255)
                : Color.FromArgb(0, 56, 152);
            int borderWidth = cboStudent.Focused ? 2 : 1;
            Rectangle bounds = cboStudent.Bounds;
            bounds.Inflate(borderWidth, borderWidth);

            using (var pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen, bounds);
            }
        }

        private void cboStudent_FocusChanged(object sender, EventArgs e)
        {
            studentPanel.Invalidate();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                cboStudent.DataSource = StudentRepository.GetAll();
                cboStudent.DisplayMember = "DisplayName";
                cboStudent.ValueMember = "Student_ID";
                cboStudent.SelectedIndex = -1;
            }
            catch (OleDbException)
            {
                MessageBox.Show(
                    "Student information could not be loaded. Please check the database connection and try again.",
                    "Student Loading Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(
                    "Student information could not be loaded. Please try again.",
                    "Student Loading Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnManageTutors_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var f = new TutorManagementForm())
            {
                f.ShowDialog();
            }
            this.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Are you sure you want to log out?", "LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
                this.Close();
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            AppTheme.Toggle();
            string logoResource = AppTheme.IsDarkMode ? "LogoDark" : "LogoLight";
            picLogo.Image = new ComponentResourceManager(typeof(AdminDashboardForm)).GetObject(logoResource) as Image
                ?? throw new InvalidOperationException("The selected logo resource is missing.");
            btnToggleTheme.Text = AppTheme.IsDarkMode ? "Switch to light mode" : "Switch to dark mode";
        }

        private void btnBookTutorial_Click(object sender, EventArgs e)
        {
            using (var form = new TutoringManagementSystem.SessionBookingForm())
            {
                form.ShowDialog(this);
            }
        }

        private void btnUpdateBooking_Click(object sender, EventArgs e)
        {
            if (!(cboStudent.SelectedValue is int studentId))
            {
                MessageBox.Show("Please select a student first.", "Student Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboStudent.Focus();
                return;
            }

            using (var form = new frmUpdateBooking(studentId))
            {
                form.ShowDialog(this);
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (!(cboStudent.SelectedValue is int studentId))
            {
                MessageBox.Show("Please select a student first.", "Student Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboStudent.Focus();
                return;
            }

            using (var form = new frmCancelBooking(studentId))
            {
                form.ShowDialog(this);
            }
        }


        private void btnGetReport_Click(object sender, EventArgs e)
        {
            using (var form = new frmReports())
            {
                form.ShowDialog(this);
            }
        }

    }
}

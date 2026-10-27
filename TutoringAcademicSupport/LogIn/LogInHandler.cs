using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TutoringAcademicSupport.Admin;
using TutoringAcademicSupport.Student;

namespace TutoringAcademicSupport.LogIn
{
    public partial class LogInHandler : Form
    {
    public string password = txtpassowrd.Text;
    public int StudentId = txtStudentNo.Text;
    public int AdminId = txtAdminNo.Text;
    
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //fetch password from db
            //bring it forward and verify
            string hashedPassword;
            if (VerifyPassword(hashedPassword, password))
            {
                this.Hide();
                if (cboStudent)
                {
                    using(var page = new StudentForm(StudentId))
                    {
                        form.ShowDialog(this);
                    }
                }
                else
                {
                    using (var page = new AdminForm(AdminId))
                    {
                        form.ShowDialog(this);
                    }
                }  
            }
            else
            {
                MessageBox.Show("Incorrect Password. Try again.", "Incorrect Password",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (cboStudent)
                {
                    txtStudentNo.Focus();
                    return;
                }
                txtAdminNo.Focus();
            }
            
            
        }
    }
}
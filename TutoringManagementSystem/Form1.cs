
using System;
using System.Windows.Forms;

namespace TutoringManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Open the Reports form for testing
            new frmReports().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form load event
        }
    }
}

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
    public partial class frmManageTutor : Form
    {
        public frmManageTutor()
        {
            InitializeComponent();
        }

        private void tutorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tutorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.byteBetter_TutoringDataSet);

        }

        private void frmManageTutor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'byteBetter_TutoringDataSet.Tutor' table. You can move, or remove it, as needed.
            this.tutorTableAdapter.Fill(this.byteBetter_TutoringDataSet.Tutor);

        }
    }
}

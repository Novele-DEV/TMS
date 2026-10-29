using TutoringAcademicSupport.Admin.Reports.AgedSubmittedTutoringRequests;
using TutoringAcademicSupport.Admin.Reports.CourseSupportDemandAndTutorCoverage;
using TutoringAcademicSupport.Admin.Reports.TutorWorkloadAndCompletionRates;

namespace TutoringAcademicSupport.Admin.Reports
{
    // Lets the administrator choose one of the three agreed reports.
    public partial class ReportGenerationForm : Form
    {
        public ReportGenerationForm()
        {
            InitializeComponent();
        }

        private void btnAgedRequests_Click(object sender, EventArgs e)
        { // report 5.1
            using AgedSubmittedTutoringRequestsForm reportForm = new();
            reportForm.ShowDialog(this);
        }

        private void btnTutorWorkload_Click(object sender, EventArgs e)
        { // report 5.2
            using TutorWorkloadAndCompletionRatesForm reportForm = new();
            reportForm.ShowDialog(this);
        }

        private void btnCourseDemand_Click(object sender, EventArgs e)
        { // report 5.3
            using CourseSupportAndTutorCoverageForm reportForm = new();
            reportForm.ShowDialog(this);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

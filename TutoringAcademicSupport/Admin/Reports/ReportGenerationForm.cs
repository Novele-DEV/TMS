using TutoringAcademicSupport.Common.Branding;
using TutoringAcademicSupport.Admin.Reports.AgedSubmittedTutoringRequests;
using TutoringAcademicSupport.Admin.Reports.CourseSupportDemandAndTutorCoverage;
using TutoringAcademicSupport.Admin.Reports.TutorWorkloadAndCompletionRates;
using TutoringAcademicSupport.Common.Navigation;

namespace TutoringAcademicSupport.Admin.Reports
{
    // Lets the administrator choose one of the three agreed reports.
    // Each report opens in place of this menu, and returning from it comes back here.
    public partial class ReportGenerationForm : Form
    {
        public ReportGenerationForm()
        {
            InitializeComponent();
            ByteBetterBrand.AddLogo(this, 90);
            ScreenLayout.CentreContent(this);
            CancelButton = btnReturn; // Esc returns to the dashboard
        }

        private void btnAgedRequests_Click(object sender, EventArgs e)
        { // report 5.1
            ScreenNavigator.Open(this, new AgedSubmittedTutoringRequestsForm());
        }

        private void btnTutorWorkload_Click(object sender, EventArgs e)
        { // report 5.2
            ScreenNavigator.Open(this, new TutorWorkloadAndCompletionRatesForm());
        }

        private void btnCourseDemand_Click(object sender, EventArgs e)
        { // report 5.3
            ScreenNavigator.Open(this, new CourseSupportAndTutorCoverageForm());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

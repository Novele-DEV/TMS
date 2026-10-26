using System.IO;
using System.Windows.Forms;

namespace Tutoring_Management_System
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData(
                "DataDirectory",
                Path.Combine(AppContext.BaseDirectory, "Data"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdminDashboardForm());
        }
    }
}

using System;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Branding;
using TutoringAcademicSupport.EntryPoint.MainMenu;

namespace TutoringAcademicSupport
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            AppTheme.LoadSavedChoice();
            Application.Run(new MainMenuForm());
        }
    }
}
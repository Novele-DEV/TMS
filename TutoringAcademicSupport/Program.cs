using System;
using System.Windows.Forms;
using TutoringAcademicSupport.EntryPoint.MainMenu;

namespace TutoringAcademicSupport
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenuForm());
        }
    }
}
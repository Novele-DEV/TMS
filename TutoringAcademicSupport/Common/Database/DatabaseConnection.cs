using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace TutoringAcademicSupport.Common.Database
{
    public static class DatabaseConnection
    {
        private const string DatabaseFileName = "ByteBetter_Tutoring.accdb";

        private static readonly string DatabasePath = FindDatabasePath();

        // While developing (Debug build), the app uses the project's own database file
        // (TutoringAcademicSupport\Common\Database), so saved changes such as new tutors are kept
        // and can be opened in Access. Otherwise each build's copy in bin\ would be used, and that
        // copy is replaced whenever the project's file is newer. A Release build uses the copy
        // next to the program.
        private static string FindDatabasePath()
        {
            string outputCopy = Path.Combine(AppContext.BaseDirectory, "Common", "Database", DatabaseFileName);

#if DEBUG
            for (DirectoryInfo? folder = new(AppContext.BaseDirectory); folder is not null; folder = folder.Parent)
            {
                string projectCopy = Path.Combine(folder.FullName, "Common", "Database", DatabaseFileName);
                if (File.Exists(projectCopy) && folder.EnumerateFiles("*.csproj").Any())
                {
                    return projectCopy;
                }
            }
#endif

            return outputCopy;
        }

        private static readonly string ConnectionString =
            $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DatabasePath};Persist Security Info=False;";

        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(ConnectionString);
        }

        public static void LoadTutors(BindingSource tutorBindingSource)
        {
            if (!File.Exists(DatabasePath))
            {
                throw new FileNotFoundException(
                    $"The database file was not found at:{Environment.NewLine}{DatabasePath}");
            }

            // the columns are named so the password hash is never loaded into the dashboard grid
            const string query = """
        SELECT
            [Tutor_ID],
            [Tutor_FName],
            [Tutor_LName],
            [Tutor_Email],
            [Tutor_Phone],
            [Tutor_AcademicAverage],
            [Tutor_PreferredMode]
        FROM [Tutor]
        """;

            using OleDbConnection connection = new(ConnectionString);
            using OleDbDataAdapter adapter = new(query, connection);

            DataTable tutorTable = new();

            connection.Open();
            adapter.Fill(tutorTable);

            tutorBindingSource.DataSource = tutorTable;
        }

        public static DataTable LoadTutor(string tutorId)
        {
            const string query = """
        SELECT
            [Tutor_ID],
            [Tutor_FName],
            [Tutor_LName],
            [Tutor_Email],
            [Tutor_Phone],
            [Tutor_AcademicAverage],
            [Tutor_PreferredMode]
        FROM [Tutor]
        WHERE [Tutor_ID] = ?
        """;

            using OleDbConnection connection = new(ConnectionString);
            using OleDbCommand command = new(query, connection);
            using OleDbDataAdapter adapter = new(command);

            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;

            DataTable tutorTable = new();

            connection.Open();
            adapter.Fill(tutorTable);

            return tutorTable;
        }
    }
}
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace TutoringAcademicSupport.Common.Database
{
    public static class DatabaseConnection
    {
        private static readonly string DatabasePath = Path.Combine(
            AppContext.BaseDirectory,
            "Common",
            "Database",
            "ByteBetter_Tutoring.accdb");

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

            const string query = "SELECT * FROM [Tutor]";

            using OleDbConnection connection = new(ConnectionString);
            using OleDbDataAdapter adapter = new(query, connection);

            DataTable tutorTable = new();

            connection.Open();
            adapter.Fill(tutorTable);

            tutorBindingSource.DataSource = tutorTable;
        }

        public static DataTable LoadTutor(int tutorId)
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

            command.Parameters.Add("@Tutor_ID", OleDbType.Integer).Value = tutorId;

            DataTable tutorTable = new();

            connection.Open();
            adapter.Fill(tutorTable);

            return tutorTable;
        }
    }
}
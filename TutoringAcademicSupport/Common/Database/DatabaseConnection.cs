
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace TutoringAcademicSupport.Common.Database
{
    public static class DatabaseConnection
    {
        // Path to the Access database
        private static readonly string DatabasePath =
            Path.Combine(
                AppContext.BaseDirectory,
                "Common",
                "Database",
                "ByteBetter_Tutoring.accdb"
            );

        // Connection string for Microsoft Access
        private static readonly string ConnectionString =
            $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DatabasePath};";

        // Create a new database connection
        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(ConnectionString);
        }

        // Load a database table into a BindingSource
        public static void LoadBindingSource(
            BindingSource bindingSource,
            string tableName)
        {
            using OleDbConnection connection = GetConnection();

            string query = $"SELECT * FROM [{tableName}]";

            using OleDbDataAdapter adapter =
                new OleDbDataAdapter(query, connection);

            DataTable table = new DataTable();
            adapter.Fill(table);

            bindingSource.DataSource = table;
        }

        // Load the Tutor table specifically
        public static void LoadTutors(BindingSource tutorBindingSource)
        {
            LoadBindingSource(tutorBindingSource, "Tutor");
        }
    
    public static void AddTutor(
    int tutorId,
    string firstName,
    string lastName,
    string email,
    string phoneNumber,
    double average,
    string preferredMode)
        {
            const string query = """
        INSERT INTO [Tutor]
        (
            [Tutor_ID],
            [Tutor_FName],
            [Tutor_LName],
            [Tutor_Email],
            [Tutor_Phone],
            [Tutor_AcademicAverage],
            [Tutor_PreferredMode]
        )
        VALUES (?, ?, ?, ?, ?, ?, ?)
        """;

            using OleDbConnection connection = GetConnection();
            using OleDbCommand command = new OleDbCommand(query, connection);

            command.Parameters.Add("@Tutor_ID", OleDbType.Integer).Value = tutorId;
            command.Parameters.Add("@Tutor_FName", OleDbType.VarWChar).Value = firstName;
            command.Parameters.Add("@Tutor_LName", OleDbType.VarWChar).Value = lastName;
            command.Parameters.Add("@Tutor_Email", OleDbType.VarWChar).Value = email;
            command.Parameters.Add("@Tutor_Phone", OleDbType.VarWChar).Value = phoneNumber;
            command.Parameters.Add("@Tutor_AcademicAverage", OleDbType.Double).Value = average;
            command.Parameters.Add("@Tutor_PreferredMode", OleDbType.VarWChar).Value =
                preferredMode;

            connection.Open();
            command.ExecuteNonQuery();
        }
    } }

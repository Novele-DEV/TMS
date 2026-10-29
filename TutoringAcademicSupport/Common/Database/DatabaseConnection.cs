using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using TutoringAcademicSupport.Common.Authentication;

namespace TutoringAcademicSupport.Common.Database
{
    public static class DatabaseConnection
    {
        private static readonly object StudentPasswordSchemaLock = new();
        private static bool studentPasswordSchemaReady;

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

        public static void EnsureStudentPasswordSchema()
        {
            lock (StudentPasswordSchemaLock)
            {
                if (studentPasswordSchemaReady)
                {
                    return;
                }

                using OleDbConnection connection = GetConnection();
                connection.Open();

                DataTable columns = connection.GetSchema("Columns");
                bool hasPasswordColumn = columns.Rows
                    .Cast<DataRow>()
                    .Any(column =>
                        string.Equals(Convert.ToString(column["TABLE_NAME"]), "Student", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(Convert.ToString(column["COLUMN_NAME"]), "Student_Password", StringComparison.OrdinalIgnoreCase));

                if (!hasPasswordColumn)
                {
                    using OleDbCommand alter = new(
                        "ALTER TABLE [Student] ADD COLUMN [Student_Password] TEXT(255)",
                        connection);
                    alter.ExecuteNonQuery();
                }

                using OleDbTransaction transaction = connection.BeginTransaction();
                List<(int StudentId, string FirstName)> studentsMissingPasswords = new();
                using (OleDbCommand select = new(
                    "SELECT [Student_ID], [Student_FName] FROM [Student] WHERE [Student_Password] IS NULL OR [Student_Password] = ''",
                    connection,
                    transaction))
                using (OleDbDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        studentsMissingPasswords.Add((reader.GetInt32(0), reader.GetString(1)));
                    }
                }

                foreach ((int studentId, string firstName) in studentsMissingPasswords)
                {
                    string generatedPassword = StudentPasswordGenerator.Generate(studentId, firstName);
                    string passwordHash = PasswordService.HashPassword(generatedPassword);
                    using OleDbCommand update = new(
                        "UPDATE [Student] SET [Student_Password] = ? WHERE [Student_ID] = ? AND ([Student_Password] IS NULL OR [Student_Password] = '')",
                        connection,
                        transaction);
                    update.Parameters.Add("@Student_Password", OleDbType.VarWChar, 255).Value = passwordHash;
                    update.Parameters.Add("@Student_ID", OleDbType.Integer).Value = studentId;
                    update.ExecuteNonQuery();
                }

                transaction.Commit();
                studentPasswordSchemaReady = true;
            }
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
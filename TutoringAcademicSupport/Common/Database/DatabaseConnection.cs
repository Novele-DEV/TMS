
using System;
using System.Data.OleDb;
using System.IO;

namespace TutoringAcademicSupport.Common
{
    public static class DatabaseConnection
    {
        public static OleDbConnection GetConnection()
        {
            string databasePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ByteBetter_Tutoring.accdb");

            string connectionString =
                $"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={databasePath};Persist Security Info=False;";

            return new OleDbConnection(connectionString);
        }
    }
}

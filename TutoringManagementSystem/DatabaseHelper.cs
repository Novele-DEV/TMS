
using System;
using System.Data.OleDb;
using System.IO;

namespace TutoringManagementSystem
{
    public static class DatabaseHelper
    {
        public static OleDbConnection GetConnection()
        {
            string databasePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "ByteBetter_Tutoring.accdb"
            );

            string connectionString =
                $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;";

            return new OleDbConnection(connectionString);
        }
    }
}


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

            if (!File.Exists(databasePath))
            {
                throw new FileNotFoundException(
                    "The tutoring database could not be found.",
                    databasePath
                );
            }

            string connectionString =
                $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;";

            return new OleDbConnection(connectionString);
        }
    }
}

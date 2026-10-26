using System.Data;
using System.Data.OleDb;
using TutoringManagementSystem;

namespace Tutoring_Management_System
{
    internal static class StudentRepository
    {
        private static OleDbConnection NewConnection()
        {
            return DatabaseHelper.GetConnection();
        }

        public static DataTable GetAll()
        {
            const string sql = "SELECT Student_ID, Student_FName, Student_LName FROM Student";
            var students = new DataTable();
            students.Columns.Add("Student_ID", typeof(int));
            students.Columns.Add("DisplayName", typeof(string));

            try
            {
                using (var con = NewConnection())
                using (var cmd = new OleDbCommand(sql, con))
                {
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = Convert.ToInt32(reader["Student_ID"]);
                            string firstName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            string lastName = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            students.Rows.Add(studentId, (firstName + " " + lastName).Trim());
                        }
                    }
                }
            }
            catch (OleDbException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }

            return students;
        }
    }
}

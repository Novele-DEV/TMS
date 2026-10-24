using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutoring_Management_System
{
    
    // All SQL for tutors lives here (Access via OleDb).
    internal static class TutorRepository
    {
        private static OleDbConnection NewConnection()
        {
            return new OleDbConnection(Properties.Settings.Default.ByteBetter_TutoringConnectionString);
        }

        public static TutorInfo? GetById(string tutorId)
        {
            const string sql =
                "SELECT Tutor_ID, Tutor_FName, Tutor_LName, Tutor_Email, Tutor_Phone, " +
                "Tutor_AcademicAverage, Tutor_PreferredMode FROM Tutor WHERE Tutor_ID = ?";

            using (var con = NewConnection())
            using (var cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.Add("@id", OleDbType.VarWChar, 8).Value = tutorId;
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;
                    return new TutorInfo
                    {
                        Id = rd.GetString(0),
                        FirstName = rd.IsDBNull(1) ? "" : rd.GetString(1),
                        LastName = rd.IsDBNull(2) ? "" : rd.GetString(2),
                        Email = rd.IsDBNull(3) ? "" : rd.GetString(3),
                        Phone = rd.IsDBNull(4) ? "" : rd.GetString(4),
                        AcademicAverage = rd.IsDBNull(5) ? (double?)null : Convert.ToDouble(rd.GetValue(5)),
                        PreferredMode = rd.IsDBNull(6) ? "" : rd.GetString(6)
                    };
                }
            }
        }

        // True if another tutor already uses this email
        public static bool EmailExists(string email, string? excludeTutorId)
        {
            const string sql = "SELECT COUNT(*) FROM Tutor WHERE Tutor_Email = ? AND Tutor_ID <> ?";

            using (var con = NewConnection())
            using (var cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.Add("@email", OleDbType.VarWChar, 100).Value = email;
                cmd.Parameters.Add("@excludeId", OleDbType.VarWChar, 8).Value = excludeTutorId ?? "";
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Adds a tutor with the next free ID (TUT00172- I think that's what we use please correct me guys).
        // Returns the number of rows inserted
        public static int Insert(TutorInfo t, out string? newTutorId)
        {
            newTutorId = null;
            const string sql =
                "INSERT INTO Tutor (Tutor_ID, Tutor_FName, Tutor_LName, Tutor_Email, Tutor_Phone, " +
                "Tutor_AcademicAverage, Tutor_PreferredMode) VALUES (?, ?, ?, ?, ?, ?, ?)";

            using (var con = NewConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    string id = NextTutorId(con, tx);
                    int rows;
                    using (var cmd = new OleDbCommand(sql, con, tx))
                    {
                        cmd.Parameters.Add("@id", OleDbType.VarWChar, 8).Value = id;
                        cmd.Parameters.Add("@fname", OleDbType.VarWChar, 50).Value = t.FirstName;
                        cmd.Parameters.Add("@lname", OleDbType.VarWChar, 50).Value = t.LastName;
                        cmd.Parameters.Add("@email", OleDbType.VarWChar, 100).Value = t.Email;
                        cmd.Parameters.Add("@phone", OleDbType.VarWChar, 12).Value = t.Phone;
                        cmd.Parameters.Add("@avg", OleDbType.Double).Value = AverageValue(t.AcademicAverage);
                        cmd.Parameters.Add("@mode", OleDbType.VarWChar, 20).Value = t.PreferredMode;
                        rows = cmd.ExecuteNonQuery();
                    }

                    if (rows != 1)
                    {
                        tx.Rollback();
                        return 0;
                    }

                    tx.Commit();
                    newTutorId = id;
                    return rows;
                }
            }
        }

        // Updates an existing tutor. Returns rows updated (0 = unsuccessful update).
        public static int Update(TutorInfo t)
        {
            const string sql =
                "UPDATE Tutor SET Tutor_FName = ?, Tutor_LName = ?, Tutor_Email = ?, Tutor_Phone = ?, " +
                "Tutor_AcademicAverage = ?, Tutor_PreferredMode = ? WHERE Tutor_ID = ?";

            using (var con = NewConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    int rows;
                    using (var cmd = new OleDbCommand(sql, con, tx))
                    {
                        cmd.Parameters.Add("@fname", OleDbType.VarWChar, 50).Value = t.FirstName;
                        cmd.Parameters.Add("@lname", OleDbType.VarWChar, 50).Value = t.LastName;
                        cmd.Parameters.Add("@email", OleDbType.VarWChar, 100).Value = t.Email;
                        cmd.Parameters.Add("@phone", OleDbType.VarWChar, 12).Value = t.Phone;
                        cmd.Parameters.Add("@avg", OleDbType.Double).Value = AverageValue(t.AcademicAverage);
                        cmd.Parameters.Add("@mode", OleDbType.VarWChar, 20).Value = t.PreferredMode;
                        cmd.Parameters.Add("@id", OleDbType.VarWChar, 8).Value = t.Id;
                        rows = cmd.ExecuteNonQuery();
                    }

                    if (rows != 1)
                    {
                        tx.Rollback();
                        return 0;
                    }

                    tx.Commit();
                    return rows;
                }
            }
        }

        private static object AverageValue(double? average)
        {
            return average.HasValue ? (object)average.Value : DBNull.Value;
        }

        // Highest existing number + 1, formatted as TUT + 5 digits (always 8 characters)
        private static string NextTutorId(OleDbConnection con, OleDbTransaction tx)
        {
            int max = 0;
            using (var cmd = new OleDbCommand("SELECT Tutor_ID FROM Tutor", con, tx))
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    string id = rd.IsDBNull(0) ? "" : rd.GetString(0);
                    int n;
                    if (id.Length > 3 && id.StartsWith("TUT", StringComparison.OrdinalIgnoreCase) && int.TryParse(id.Substring(3), out n) && n > max)
                    {
                        max = n;
                    }
                }
            }
            return "TUT" + (max + 1).ToString("D5");
        }
        
    }
}

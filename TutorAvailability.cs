using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;

namespace UpdateBookings
{
    internal class TutorAvailability
    {
        public const int SessionMinutes = 60;

        public static DataTable GetAvailableTutors(DateTime date, TimeSpan start, string courseCode, int excludeSessionId)
        {
            bool filterByCourse = !string.IsNullOrEmpty(courseCode);
            TimeSpan end = start + TimeSpan.FromMinutes(SessionMinutes);

            var sql = @"
SELECT t.Tutor_ID, t.Tutor_FName & ' ' & t.Tutor_LName AS TutorName
FROM Tutors AS t
WHERE EXISTS (
    SELECT * FROM TutorAvailabilty AS ta
    WHERE ta.Tutor_ID = t.Tutor_ID AND ta.Avail_Day = ?
        AND ta.Avail_StartTime <= ? AND ta.Avail_EndTime >= ?)
";
            if (filterByCourse)
            {
                sql += @"AND EXISTS (
    SELECT * FROM TutorQualifications AS tq
    WHERE tq.Tutor_ID = t.Tutor_ID AND tq.Course_Code = ?
        AND tq.Verification_Date IS NOT NULL)
";
            }
            sql += @"AND NOT EXISTS (
    SELECT * FROM TutoringSession AS s
    WHERE s.Tutor_ID = t.Tutor_ID AND s.Session_Date = ?
        AND s.Session_StartTime < ? AND s.Session_EndTime > ?
        AND s.Session_Status <> 'Cancelled' AND s.Session_ID <> ?)
ORDER BY t.Tutor_FName, t.Tutor_LName";

            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ByteBetter_Tutoring.accdb");
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databasePath + ";Persist Security Info=False;";

            using (var cn = new OleDbConnection(connectionString))
            using (var da = new OleDbDataAdapter(sql, cn))
            {
                OleDbParameterCollection p = da.SelectCommand.Parameters;
                p.Add("@day", OleDbType.VarWChar, 20).Value = date.ToString("dddd", CultureInfo.InvariantCulture);
                p.Add("@AvailStart", OleDbType.Date).Value = TimeToDb(start);
                p.Add("@AvailEnd", OleDbType.Date).Value = TimeToDb(end);
                if (filterByCourse)
                {
                    p.Add("@Course", OleDbType.VarWChar, 18).Value = courseCode;
                }

                p.Add("@sessionDate", OleDbType.Date).Value = date.Date;
                p.Add("@newEnd", OleDbType.Date).Value = TimeToDb(end);
                p.Add("@newStart", OleDbType.Date).Value = TimeToDb(start);
                p.Add("@exclude", OleDbType.Integer).Value = excludeSessionId;

                var tutors = new DataTable();
                da.Fill(tutors);

                if (date.Date + start <= DateTime.Now) tutors.Rows.Clear();
                return tutors;
            }
        }

        public static DateTime TimeToDb(TimeSpan time)
        {
            return new DateTime(1899, 12, 30) + time;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using TutoringAcademicSupport.Common.Database;
using TutoringAcademicSupport.Student.CancelBooking;

namespace TutoringAcademicSupport.Student.BookSession
{
    public static class BookSessionHandler
    {
        private const string ScheduledStatus = "Scheduled";
        private const string CancelledStatus = "Cancelled";

        // A request can be booked once an administrator has verified it or matched it with a tutor.
        private static readonly string[] BookableRequestStatuses = { "Verified", "Matched" };

        // Access stores a time of day as a date-time on this base date.
        private static readonly DateTime AccessTimeBase = new(1899, 12, 30);

        private sealed record RequestInfo(int StudentId, string CourseCode, string TutorId, string Status);

        // Lists the student's requests that are ready to have a session booked. The form can fill its request list from this.
        public static DataTable GetBookableRequests(int studentId)
        {
            string placeholders = string.Join(", ", BookableRequestStatuses.Select(_ => "?"));
            string query = $"""
                SELECT r.[Request_ID], r.[Course_Code], c.[Course_Name],
                       r.[Request_SupportType], r.[Request_PriorityLevel], r.[Request_Status]
                FROM [TutoringRequest] AS r
                INNER JOIN [Course] AS c ON c.[Course_Code] = r.[Course_Code]
                WHERE r.[Student_ID] = ? AND r.[Request_Status] IN ({placeholders})
                ORDER BY r.[Request_SubmissionDate], r.[Request_ID]
                """;

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            using OleDbCommand command = new(query, connection);
            command.Parameters.Add("@Student_ID", OleDbType.Integer).Value = studentId;
            foreach (string status in BookableRequestStatuses)
            {
                command.Parameters.Add("@Status", OleDbType.VarWChar, 30).Value = status;
            }

            DataTable requests = new();
            connection.Open();
            using OleDbDataAdapter adapter = new(command);
            adapter.Fill(requests);
            return requests;
        }

        // Lists the tutors who can take a session for this course at this time: verified for the course,
        // available at that day and time, and not already booked. An empty table means no tutor is available.
        public static DataTable GetAvailableTutors(string courseCode, DateTime sessionDate, DateTime startTime, DateTime endTime)
        {
            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            return GetAvailableTutors(connection, null, courseCode, sessionDate, startTime, endTime);
        }

        // Database failures (OleDbException) are deliberately not caught here. The form catches them
        // and shows the student a message, in the same way as the other handlers.
        public static BookSessionResult Handle(BookSessionRequest request)
        {
            string validationMessage = BookSessionValidator.Validate(request);
            if (validationMessage.Length > 0)
            {
                return Fail(validationMessage);
            }

            string tutorId = request.TutorId.Trim();
            DateTime date = request.SessionDate.Date;
            DateTime start = BookSessionValidator.Combine(date, request.StartTime);
            DateTime end = BookSessionValidator.Combine(date, request.EndTime);

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using OleDbTransaction transaction = connection.BeginTransaction();

            // The request decides who the booking is for and which course it covers.
            RequestInfo? info = ReadRequest(connection, transaction, request.RequestId);
            if (info == null)
            {
                return Fail("That tutoring request could not be found.");
            }

            if (info.StudentId != request.StudentId)
            {
                return Fail("That tutoring request does not belong to you.");
            }

            if (string.Equals(info.Status, ScheduledStatus, StringComparison.OrdinalIgnoreCase) ||
                CountScheduledSessions(connection, transaction, request.RequestId) > 0)
            {
                return Fail("This request already has a booked session. Use Update Booking to change it.");
            }

            if (!BookableRequestStatuses.Contains(info.Status, StringComparer.OrdinalIgnoreCase))
            {
                return Fail("A session can only be booked once the request has been verified or matched with a tutor. " +
                            $"This request is currently {info.Status.ToLowerInvariant()}.");
            }

            string? tutorName = ReadTutorName(connection, transaction, tutorId);
            if (tutorName == null)
            {
                return Fail("The selected tutor could not be found.");
            }

            if (!IsVerifiedForCourse(connection, transaction, tutorId, info.CourseCode))
            {
                return Fail($"{tutorName} is not verified to tutor {info.CourseCode}. Please choose another tutor.");
            }

            // The tutor must be available for the whole session on that day of the week.
            if (!IsTutorAvailable(connection, transaction, tutorId, date, start, end))
            {
                return Fail(DescribeUnavailability(connection, transaction, tutorId, tutorName, info.CourseCode, date, start, end));
            }

            if (HasOverlap(connection, transaction, "Tutor_ID", OleDbType.VarWChar, tutorId, date, start, end))
            {
                return Fail(WithAlternatives(connection, transaction,
                    $"{tutorName} already has a session during that time.", info.CourseCode, date, start, end));
            }

            if (HasOverlap(connection, transaction, "Student_ID", OleDbType.Integer, request.StudentId, date, start, end))
            {
                return Fail("You already have a session booked during that time.");
            }

            int sessionId = NextSessionId(connection, transaction);
            InsertSession(connection, transaction, sessionId, request, tutorId, date, start, end);

            if (!MarkRequestScheduled(connection, transaction, info, request.RequestId, tutorId))
            {
                return Fail("This request has changed. Please refresh and try again.");
            }

            transaction.Commit();

            return new BookSessionResult
            {
                Success = true,
                SessionId = sessionId,
                Message = $"Session booked with {tutorName} on {date:dddd dd MMM yyyy} from {start:HH:mm} to {end:HH:mm}. " +
                          $"Your session ID is {sessionId}. {CancelBookingValidator.RuleNotice}"
            };
        }

        private static RequestInfo? ReadRequest(OleDbConnection connection, OleDbTransaction transaction, int requestId)
        {
            const string query = """
                SELECT [Student_ID], [Course_Code], [Tutor_ID], [Request_Status]
                FROM [TutoringRequest]
                WHERE [Request_ID] = ?
                """;

            using OleDbCommand command = new(query, connection, transaction);
            command.Parameters.Add("@Request_ID", OleDbType.Integer).Value = requestId;
            using OleDbDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            return new RequestInfo(
                Convert.ToInt32(reader["Student_ID"]),
                Convert.ToString(reader["Course_Code"]) ?? string.Empty,
                reader["Tutor_ID"] is DBNull ? string.Empty : Convert.ToString(reader["Tutor_ID"]) ?? string.Empty,
                Convert.ToString(reader["Request_Status"]) ?? string.Empty);
        }

        private static int CountScheduledSessions(OleDbConnection connection, OleDbTransaction transaction, int requestId)
        {
            const string query = "SELECT COUNT(*) FROM [TutoringSession] WHERE [Request_ID] = ? AND [Session_Status] = ?";

            using OleDbCommand command = new(query, connection, transaction);
            command.Parameters.Add("@Request_ID", OleDbType.Integer).Value = requestId;
            command.Parameters.Add("@Session_Status", OleDbType.VarWChar, 20).Value = ScheduledStatus;
            return Convert.ToInt32(command.ExecuteScalar());
        }

        private static string? ReadTutorName(OleDbConnection connection, OleDbTransaction transaction, string tutorId)
        {
            const string query = "SELECT [Tutor_FName] & ' ' & [Tutor_LName] FROM [Tutor] WHERE [Tutor_ID] = ?";

            using OleDbCommand command = new(query, connection, transaction);
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
            object? name = command.ExecuteScalar();
            return name == null || name is DBNull ? null : Convert.ToString(name);
        }

        // A qualification counts only once it has a verification date, in the same way as the admin coverage report.
        private static bool IsVerifiedForCourse(OleDbConnection connection, OleDbTransaction transaction, string tutorId, string courseCode)
        {
            const string query = """
                SELECT COUNT(*)
                FROM [TutorQualifications]
                WHERE [Tutor_ID] = ? AND [Course_Code] = ? AND [Verification_Date] IS NOT NULL
                """;

            using OleDbCommand command = new(query, connection, transaction);
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
            command.Parameters.Add("@Course_Code", OleDbType.VarWChar, 9).Value = courseCode;
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        // The availability window has to contain the whole session, not just touch it.
        private static bool IsTutorAvailable(
            OleDbConnection connection,
            OleDbTransaction transaction,
            string tutorId,
            DateTime date,
            DateTime start,
            DateTime end)
        {
            const string query = """
                SELECT COUNT(*)
                FROM [TutorAvailability]
                WHERE [Tutor_ID] = ? AND [Avail_Day] = ?
                  AND [Avail_StartTime] <= ? AND [Avail_EndTime] >= ?
                """;

            using OleDbCommand command = new(query, connection, transaction);
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
            command.Parameters.Add("@Avail_Day", OleDbType.VarWChar, 10).Value = DayName(date);
            command.Parameters.Add("@Avail_StartTime", OleDbType.Date).Value = ToAccessTime(start);
            command.Parameters.Add("@Avail_EndTime", OleDbType.Date).Value = ToAccessTime(end);
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        // True when an active session for the same tutor (or the same student) overlaps the requested time.
        // The column name always comes from a constant in this file, never from user input.
        private static bool HasOverlap(
            OleDbConnection connection,
            OleDbTransaction transaction,
            string column,
            OleDbType columnType,
            object value,
            DateTime date,
            DateTime start,
            DateTime end)
        {
            string query = $"""
                SELECT COUNT(*)
                FROM [TutoringSession]
                WHERE [{column}] = ? AND [Session_Status] <> ? AND [Session_Date] = ?
                  AND [Session_StartTime] < ? AND [Session_EndTime] > ?
                """;

            using OleDbCommand command = new(query, connection, transaction);
            command.Parameters.Add("@Value", columnType).Value = value;
            command.Parameters.Add("@Session_Status", OleDbType.VarWChar, 20).Value = CancelledStatus;
            command.Parameters.Add("@Session_Date", OleDbType.Date).Value = date;
            command.Parameters.Add("@Existing_Start_Before", OleDbType.Date).Value = ToAccessTime(end);
            command.Parameters.Add("@Existing_End_After", OleDbType.Date).Value = ToAccessTime(start);
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        private static DataTable GetAvailableTutors(
            OleDbConnection connection,
            OleDbTransaction? transaction,
            string courseCode,
            DateTime sessionDate,
            DateTime startTime,
            DateTime endTime)
        {
            DateTime date = sessionDate.Date;
            DateTime start = BookSessionValidator.Combine(date, startTime);
            DateTime end = BookSessionValidator.Combine(date, endTime);

            DataTable tutors = new();
            if (string.IsNullOrWhiteSpace(courseCode) || end <= start)
            {
                return tutors;
            }

            const string query = """
                SELECT t.[Tutor_ID], t.[Tutor_FName] & ' ' & t.[Tutor_LName] AS [TutorName]
                FROM [Tutor] AS t
                WHERE EXISTS (
                        SELECT * FROM [TutorQualifications] AS q
                        WHERE q.[Tutor_ID] = t.[Tutor_ID] AND q.[Course_Code] = ?
                          AND q.[Verification_Date] IS NOT NULL)
                  AND EXISTS (
                        SELECT * FROM [TutorAvailability] AS a
                        WHERE a.[Tutor_ID] = t.[Tutor_ID] AND a.[Avail_Day] = ?
                          AND a.[Avail_StartTime] <= ? AND a.[Avail_EndTime] >= ?)
                  AND NOT EXISTS (
                        SELECT * FROM [TutoringSession] AS s
                        WHERE s.[Tutor_ID] = t.[Tutor_ID] AND s.[Session_Status] <> ?
                          AND s.[Session_Date] = ?
                          AND s.[Session_StartTime] < ? AND s.[Session_EndTime] > ?)
                ORDER BY t.[Tutor_FName], t.[Tutor_LName]
                """;

            using OleDbCommand command = new(query, connection, transaction);
            command.Parameters.Add("@Course_Code", OleDbType.VarWChar, 9).Value = courseCode.Trim();
            command.Parameters.Add("@Avail_Day", OleDbType.VarWChar, 10).Value = DayName(date);
            command.Parameters.Add("@Avail_StartTime", OleDbType.Date).Value = ToAccessTime(start);
            command.Parameters.Add("@Avail_EndTime", OleDbType.Date).Value = ToAccessTime(end);
            command.Parameters.Add("@Session_Status", OleDbType.VarWChar, 20).Value = CancelledStatus;
            command.Parameters.Add("@Session_Date", OleDbType.Date).Value = date;
            command.Parameters.Add("@Existing_Start_Before", OleDbType.Date).Value = ToAccessTime(end);
            command.Parameters.Add("@Existing_End_After", OleDbType.Date).Value = ToAccessTime(start);

            using OleDbDataAdapter adapter = new(command);
            adapter.Fill(tutors);
            return tutors;
        }

        // Explains why the chosen tutor cannot take the session, then says who else can.
        private static string DescribeUnavailability(
            OleDbConnection connection,
            OleDbTransaction transaction,
            string tutorId,
            string tutorName,
            string courseCode,
            DateTime date,
            DateTime start,
            DateTime end)
        {
            string day = DayName(date);
            List<string> windows = ReadAvailabilityWindows(connection, transaction, tutorId, day);

            string reason;
            if (windows.Count > 0)
            {
                reason = $"{tutorName} is not available on {day} from {start:HH:mm} to {end:HH:mm}. " +
                         $"Available {day} times: {string.Join(", ", windows)}.";
            }
            else
            {
                List<string> days = ReadAvailableDays(connection, transaction, tutorId);
                reason = days.Count > 0
                    ? $"{tutorName} is not available on {day}s. Available days: {string.Join(", ", days)}."
                    : $"{tutorName} has not set any availability yet.";
            }

            return WithAlternatives(connection, transaction, reason, courseCode, date, start, end);
        }

        // Adds the other tutors who could take the session, or says plainly that nobody can.
        private static string WithAlternatives(
            OleDbConnection connection,
            OleDbTransaction transaction,
            string reason,
            string courseCode,
            DateTime date,
            DateTime start,
            DateTime end)
        {
            DataTable others = GetAvailableTutors(connection, transaction, courseCode, date, start, end);
            if (others.Rows.Count == 0)
            {
                return reason + " No qualified tutor is available for " + courseCode +
                       " at that time. Please choose a different day or time.";
            }

            IEnumerable<string> names = others.Rows.Cast<DataRow>()
                .Select(row => $"{row["TutorName"]} ({row["Tutor_ID"]})");
            return reason + " Tutors available at that time: " + string.Join(", ", names) + ".";
        }

        private static List<string> ReadAvailabilityWindows(OleDbConnection connection, OleDbTransaction transaction, string tutorId, string day)
        {
            const string query = """
                SELECT [Avail_StartTime], [Avail_EndTime]
                FROM [TutorAvailability]
                WHERE [Tutor_ID] = ? AND [Avail_Day] = ?
                ORDER BY [Avail_StartTime]
                """;

            using OleDbCommand command = new(query, connection, transaction);
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
            command.Parameters.Add("@Avail_Day", OleDbType.VarWChar, 10).Value = day;
            using OleDbDataReader reader = command.ExecuteReader();

            List<string> windows = new();
            while (reader.Read())
            {
                DateTime from = Convert.ToDateTime(reader["Avail_StartTime"]);
                DateTime to = Convert.ToDateTime(reader["Avail_EndTime"]);
                windows.Add($"{from:HH:mm}-{to:HH:mm}");
            }

            return windows;
        }

        private static List<string> ReadAvailableDays(OleDbConnection connection, OleDbTransaction transaction, string tutorId)
        {
            const string query = "SELECT DISTINCT [Avail_Day] FROM [TutorAvailability] WHERE [Tutor_ID] = ?";

            using OleDbCommand command = new(query, connection, transaction);
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
            using OleDbDataReader reader = command.ExecuteReader();

            List<string> days = new();
            while (reader.Read())
            {
                days.Add(Convert.ToString(reader["Avail_Day"]) ?? string.Empty);
            }

            // Monday first, so the days read in the order of a normal week.
            return days
                .Where(day => day.Length > 0)
                .OrderBy(day => Enum.TryParse(day, out DayOfWeek parsed) ? ((int)parsed + 6) % 7 : 7)
                .ToList();
        }

        // The project assigns IDs itself (see the tutor availability handler), so the next ID is the highest plus one.
        private static int NextSessionId(OleDbConnection connection, OleDbTransaction transaction)
        {
            using OleDbCommand command = new("SELECT MAX([Session_ID]) FROM [TutoringSession]", connection, transaction);
            object? highest = command.ExecuteScalar();
            if (highest == null || highest == DBNull.Value)
            {
                return 1;
            }

            int current = Convert.ToInt32(highest);
            if (current == int.MaxValue)
            {
                throw new InvalidOperationException("No more session IDs are available.");
            }

            return current + 1;
        }

        private static void InsertSession(
            OleDbConnection connection,
            OleDbTransaction transaction,
            int sessionId,
            BookSessionRequest request,
            string tutorId,
            DateTime date,
            DateTime start,
            DateTime end)
        {
            const string insert = """
                INSERT INTO [TutoringSession]
                    ([Session_ID], [Student_ID], [Tutor_ID], [Request_ID],
                     [Session_StartTime], [Session_EndTime], [Session_Date],
                     [Session_ModeOfDelivery], [Session_Status], [Session_StudentInAttendance])
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """;

            using OleDbCommand command = new(insert, connection, transaction);
            command.Parameters.Add("@Session_ID", OleDbType.Integer).Value = sessionId;
            command.Parameters.Add("@Student_ID", OleDbType.Integer).Value = request.StudentId;
            command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
            command.Parameters.Add("@Request_ID", OleDbType.Integer).Value = request.RequestId;
            command.Parameters.Add("@Session_StartTime", OleDbType.Date).Value = ToAccessTime(start);
            command.Parameters.Add("@Session_EndTime", OleDbType.Date).Value = ToAccessTime(end);
            command.Parameters.Add("@Session_Date", OleDbType.Date).Value = date;
            command.Parameters.Add("@Session_ModeOfDelivery", OleDbType.VarWChar, 20).Value = request.ModeOfDelivery;
            command.Parameters.Add("@Session_Status", OleDbType.VarWChar, 20).Value = ScheduledStatus;
            command.Parameters.Add("@Session_StudentInAttendance", OleDbType.Boolean).Value = false;
            command.ExecuteNonQuery();
        }

        // Moves the request to Scheduled. The tutor is recorded on the request only when none was matched yet.
        // The status condition makes sure a request that changed in the meantime is not overwritten.
        private static bool MarkRequestScheduled(
            OleDbConnection connection,
            OleDbTransaction transaction,
            RequestInfo info,
            int requestId,
            string tutorId)
        {
            bool recordTutor = info.TutorId.Length == 0;
            string update = recordTutor
                ? "UPDATE [TutoringRequest] SET [Request_Status] = ?, [Tutor_ID] = ? WHERE [Request_ID] = ? AND [Request_Status] = ?"
                : "UPDATE [TutoringRequest] SET [Request_Status] = ? WHERE [Request_ID] = ? AND [Request_Status] = ?";

            using OleDbCommand command = new(update, connection, transaction);
            command.Parameters.Add("@Request_Status", OleDbType.VarWChar, 30).Value = ScheduledStatus;
            if (recordTutor)
            {
                command.Parameters.Add("@Tutor_ID", OleDbType.VarWChar, 8).Value = tutorId;
            }

            command.Parameters.Add("@Request_ID", OleDbType.Integer).Value = requestId;
            command.Parameters.Add("@Current_Status", OleDbType.VarWChar, 30).Value = info.Status;
            return command.ExecuteNonQuery() == 1;
        }

        private static string DayName(DateTime date)
        {
            return date.DayOfWeek.ToString();
        }

        private static DateTime ToAccessTime(DateTime value)
        {
            return AccessTimeBase.Add(value.TimeOfDay);
        }

        private static BookSessionResult Fail(string message)
        {
            return new BookSessionResult { Message = message };
        }
    }
}

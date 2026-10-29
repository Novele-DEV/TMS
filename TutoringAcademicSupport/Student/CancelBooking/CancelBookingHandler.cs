using System;
using System.Data.OleDb;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Student.CancelBooking
{
    public static class CancelBookingHandler
    {
        private const string ScheduledStatus = "Scheduled";
        private const string CancelledStatus = "Cancelled";

        // Database failures (OleDbException) are deliberately not caught here. The form already
        // catches them and shows the student a message.
        public static CancelBookingResult Handle(CancelBookingRequest request)
        {
            string validationMessage = CancelBookingValidator.Validate(request);
            if (validationMessage.Length > 0)
            {
                return Fail(validationMessage);
            }

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using OleDbTransaction transaction = connection.BeginTransaction();

            // Read the real booking. Nothing the form sent is trusted for the decision.
            const string find = """
                SELECT [Student_ID], [Request_ID], [Session_Date], [Session_StartTime], [Session_Status]
                FROM [TutoringSession]
                WHERE [Session_ID] = ?
                """;

            int ownerId;
            int requestId;
            DateTime start;
            string status;

            using (OleDbCommand command = new(find, connection, transaction))
            {
                command.Parameters.Add("@Session_ID", OleDbType.Integer).Value = request.SessionId;
                using OleDbDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return Fail("This booking no longer exists. Please refresh your list.");
                }

                ownerId = Convert.ToInt32(reader["Student_ID"]);
                requestId = Convert.ToInt32(reader["Request_ID"]);
                start = Convert.ToDateTime(reader["Session_Date"]).Date +
                        Convert.ToDateTime(reader["Session_StartTime"]).TimeOfDay;
                status = Convert.ToString(reader["Session_Status"]) ?? string.Empty;
            }

            if (request.StudentId > 0 && ownerId != request.StudentId)
            {
                return Fail("You can only cancel your own bookings.");
            }

            if (requestId != request.RequestId)
            {
                return Fail("This booking has changed. Please refresh your list and try again.");
            }

            if (!string.Equals(status, ScheduledStatus, StringComparison.OrdinalIgnoreCase))
            {
                return Fail($"This booking is {status.ToLowerInvariant()} and cannot be cancelled.");
            }

            // The 48 hour rule, applied to the start time stored in the database.
            string ruleMessage = CancelBookingValidator.Validate(start);
            if (ruleMessage.Length > 0)
            {
                return Fail(ruleMessage);
            }

            // The Scheduled condition makes sure a booking that changed in the meantime is not overwritten.
            const string cancel = """
                UPDATE [TutoringSession]
                SET [Session_Status] = ?
                WHERE [Session_ID] = ? AND [Session_Status] = ?
                """;

            using (OleDbCommand command = new(cancel, connection, transaction))
            {
                command.Parameters.Add("@Session_Status", OleDbType.VarWChar, 20).Value = CancelledStatus;
                command.Parameters.Add("@Session_ID", OleDbType.Integer).Value = request.SessionId;
                command.Parameters.Add("@Current_Status", OleDbType.VarWChar, 20).Value = ScheduledStatus;
                if (command.ExecuteNonQuery() != 1)
                {
                    return Fail("This booking has changed. Please refresh your list and try again.");
                }
            }

            CancelRequest(connection, transaction, requestId, request.SessionId);

            transaction.Commit();

            string tutor = request.TutorName.Trim().Length > 0 ? " with " + request.TutorName.Trim() : string.Empty;
            return new CancelBookingResult
            {
                Success = true,
                Message = $"Your booking{tutor} on {start:dd MMM yyyy} at {start:HH:mm} has been cancelled."
            };
        }

        // Marks the tutoring request as Cancelled, as in the existing data (request 4). It is only done when this
        // was the request's last Scheduled booking and the request is still Scheduled. A request in another stage
        // (for example In Progress) is left alone.
        private static void CancelRequest(
            OleDbConnection connection,
            OleDbTransaction transaction,
            int requestId,
            int cancelledSessionId)
        {
            const string otherBookings = """
                SELECT COUNT(*)
                FROM [TutoringSession]
                WHERE [Request_ID] = ? AND [Session_ID] <> ? AND [Session_Status] = ?
                """;

            using (OleDbCommand command = new(otherBookings, connection, transaction))
            {
                command.Parameters.Add("@Request_ID", OleDbType.Integer).Value = requestId;
                command.Parameters.Add("@Session_ID", OleDbType.Integer).Value = cancelledSessionId;
                command.Parameters.Add("@Session_Status", OleDbType.VarWChar, 20).Value = ScheduledStatus;
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                {
                    return;
                }
            }

            // The Scheduled condition leaves a request in any other stage untouched.
            const string cancelRequest = """
                UPDATE [TutoringRequest]
                SET [Request_Status] = ?
                WHERE [Request_ID] = ? AND [Request_Status] = ?
                """;

            using OleDbCommand update = new(cancelRequest, connection, transaction);
            update.Parameters.Add("@Request_Status", OleDbType.VarWChar, 30).Value = CancelledStatus;
            update.Parameters.Add("@Request_ID", OleDbType.Integer).Value = requestId;
            update.Parameters.Add("@Current_Status", OleDbType.VarWChar, 30).Value = ScheduledStatus;
            update.ExecuteNonQuery();
        }

        private static CancelBookingResult Fail(string message)
        {
            return new CancelBookingResult { Message = message };
        }
    }
}

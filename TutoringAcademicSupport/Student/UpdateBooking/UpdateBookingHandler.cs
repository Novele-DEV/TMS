
using System;
using System.Data;
using System.Data.OleDb;
using TutoringAcademicSupport.Common;
using TutoringAcademicSupport.Common.Database;
using TutoringAcademicSupport.Student.CancelBooking;

namespace TutoringAcademicSupport.Student.UpdateBooking
{
    public class UpdateBookingHandler
    {
        private const string ScheduledStatus = "Scheduled";

        private static DateTime TimeToDb(DateTime time)
        {
            return new DateTime(1899, 12, 30).Add(time.TimeOfDay);
        }

        // The student's scheduled sessions, soonest first, for the "Your booking" list.
        // Read-only: it only lists bookings; Handle still does the update.
        public static List<ScheduledBooking> GetScheduledBookings(int studentId)
        {
            const string query = """
                SELECT s.[Session_ID], s.[Tutor_ID], t.[Tutor_FName], t.[Tutor_LName], r.[Course_Code],
                       s.[Session_Date], s.[Session_StartTime], s.[Session_EndTime], s.[Session_ModeOfDelivery]
                FROM ([TutoringSession] AS s
                    INNER JOIN [Tutor] AS t ON t.[Tutor_ID] = s.[Tutor_ID])
                    INNER JOIN [TutoringRequest] AS r ON r.[Request_ID] = s.[Request_ID]
                WHERE s.[Student_ID] = ? AND s.[Session_Status] = ?
                ORDER BY s.[Session_Date], s.[Session_StartTime]
                """;

            using OleDbConnection connection = DatabaseConnection.GetConnection();
            using OleDbCommand command = new(query, connection);
            command.Parameters.Add("@Student_ID", OleDbType.Integer).Value = studentId;
            command.Parameters.Add("@Session_Status", OleDbType.VarWChar, 20).Value = ScheduledStatus;

            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();

            List<ScheduledBooking> bookings = new();
            while (reader.Read())
            {
                bookings.Add(new ScheduledBooking(
                    Convert.ToInt32(reader["Session_ID"]),
                    Convert.ToString(reader["Tutor_ID"]) ?? string.Empty,
                    $"{reader["Tutor_FName"]} {reader["Tutor_LName"]}",
                    Convert.ToString(reader["Course_Code"]) ?? string.Empty,
                    Convert.ToDateTime(reader["Session_Date"]),
                    Convert.ToDateTime(reader["Session_StartTime"]),
                    Convert.ToDateTime(reader["Session_EndTime"]),
                    Convert.ToString(reader["Session_ModeOfDelivery"]) ?? string.Empty));
            }

            return bookings;
        }

        public UpdateBookingResult Handle(UpdateBookingRequest request)
        {
            string validationMessage = UpdateBookingValidator.Validate(request);

            if (!string.IsNullOrEmpty(validationMessage))
            {
                return new UpdateBookingResult
                {
                    Success = false,
                    Message = validationMessage
                };
            }

            DateTime newStart = request.SessionDate.Date
                .Add(request.StartTime.TimeOfDay);

            DateTime newEnd = request.SessionDate.Date
                .Add(request.EndTime.TimeOfDay);

            if (newEnd <= newStart)
            {
                return new UpdateBookingResult
                {
                    Success = false,
                    Message = "The end time must be after the start time."
                };
            }

            try
            {
                using (OleDbConnection connection =  DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Find the original session and verify ownership.
                    DateTime originalStart;
                    string originalStatus;

                    string findSql = @"
                        SELECT [Session_Date], [Session_StartTime], [Session_Status]
                        FROM [TutoringSession]
                        WHERE [Session_ID] = ?
                          AND [Student_ID] = ?";

                    using (OleDbCommand command =
                           new OleDbCommand(findSql, connection))
                    {
                        command.Parameters.Add("?", OleDbType.Integer)
                            .Value = request.SessionId;
                        command.Parameters.Add("?", OleDbType.Integer)
                            .Value = request.StudentId;

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                return new UpdateBookingResult
                                {
                                    Success = false,
                                    Message = "Session not found for this student."
                                };
                            }

                            DateTime sessionDate =
                                Convert.ToDateTime(reader["Session_Date"]);

                            DateTime sessionTime =
                                Convert.ToDateTime(reader["Session_StartTime"]);

                            originalStart = sessionDate.Date
                                .Add(sessionTime.TimeOfDay);

                            originalStatus =
                                Convert.ToString(reader["Session_Status"]) ?? string.Empty;
                        }
                    }

                    // Only a booking that is still scheduled can be changed.
                    if (!string.Equals(originalStatus, ScheduledStatus,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        return new UpdateBookingResult
                        {
                            Success = false,
                            Message = "This session is " + originalStatus.ToLowerInvariant() +
                                      " and can no longer be changed."
                        };
                    }

                    // Changes must be made far enough ahead. The notice period is defined once, in CancelBookingValidator.
                    if (originalStart - DateTime.Now <
                        TimeSpan.FromHours(CancelBookingValidator.MinimumNoticeHours))
                    {
                        return new UpdateBookingResult
                        {
                            Success = false,
                            Message = "Changes must be made at least " +
                                      CancelBookingValidator.MinimumNoticeHours +
                                      " hours before the tutorial."
                        };
                    }

                    // Check that the selected tutor is available that day and time.
                    string availabilitySql = @"
                        SELECT COUNT(*)
                        FROM [TutorAvailability]
                        WHERE [Tutor_ID] = ?
                          AND [Avail_Day] = ?
                          AND [Avail_StartTime] <= ?
                          AND [Avail_EndTime] >= ?";

                    using (OleDbCommand command =
                           new OleDbCommand(availabilitySql, connection))
                    {
                        command.Parameters.Add("?", OleDbType.VarWChar)
                            .Value = request.TutorId;
                        command.Parameters.Add("?", OleDbType.VarWChar)
                            .Value = request.SessionDate.DayOfWeek.ToString();
                        // The availability window must contain the whole session:
                        // Avail_StartTime <= session start AND Avail_EndTime >= session end.
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = TimeToDb(request.StartTime);
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = TimeToDb(request.EndTime);

                        int available = Convert.ToInt32(command.ExecuteScalar());

                        if (available == 0)
                        {
                            return new UpdateBookingResult
                            {
                                Success = false,
                                Message = "The tutor is not available for that day and time."
                            };
                        }
                    }

                    // Prevent overlapping sessions for the same tutor.
                    string overlapSql = @"
                        SELECT COUNT(*)
                        FROM [TutoringSession]
                        WHERE [Tutor_ID] = ?
                          AND [Session_ID] <> ?
                          AND [Session_Status] <> ?
                          AND [Session_Date] = ?
                          AND [Session_StartTime] < ?
                          AND [Session_EndTime] > ?";

                    using (OleDbCommand command =
                           new OleDbCommand(overlapSql, connection))
                    {
                        command.Parameters.Add("?", OleDbType.VarWChar)
                            .Value = request.TutorId;
                        command.Parameters.Add("?", OleDbType.Integer)
                            .Value = request.SessionId;
                        command.Parameters.Add("?", OleDbType.VarWChar)
                            .Value = "Cancelled";
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = request.SessionDate.Date;
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = TimeToDb(request.EndTime);
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = TimeToDb(request.StartTime);

                        int overlaps = Convert.ToInt32(command.ExecuteScalar());

                        if (overlaps > 0)
                        {
                            return new UpdateBookingResult
                            {
                                Success = false,
                                Message = "The tutor already has a session during that time."
                            };
                        }
                    }

                    // Save the changes.
                    string updateSql = @"
                        UPDATE [TutoringSession]
                        SET [Tutor_ID] = ?,
                            [Session_Date] = ?,
                            [Session_StartTime] = ?,
                            [Session_EndTime] = ?,
                            [Session_ModeOfDelivery] = ?
                        WHERE [Session_ID] = ?
                          AND [Student_ID] = ?
                          AND [Session_Status] = ?";

                    using (OleDbCommand command =
                           new OleDbCommand(updateSql, connection))
                    {
                        command.Parameters.Add("?", OleDbType.VarWChar)
                            .Value = request.TutorId;
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = request.SessionDate.Date;
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = TimeToDb(request.StartTime);
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = TimeToDb(request.EndTime);
                        command.Parameters.Add("?", OleDbType.VarWChar)
                            .Value = request.ModeOfDelivery;
                        command.Parameters.Add("?", OleDbType.Integer)
                            .Value = request.SessionId;
                        command.Parameters.Add("?", OleDbType.Integer)
                            .Value = request.StudentId;
                        command.Parameters.Add("?", OleDbType.VarWChar)
                            .Value = ScheduledStatus;

                        int rowsUpdated = command.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {
                            return new UpdateBookingResult
                            {
                                Success = false,
                                Message = "The session could not be updated."
                            };
                        }
                    }
                }

                return new UpdateBookingResult
                {
                    Success = true,
                    Message = "Tutoring session updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new UpdateBookingResult
                {
                    Success = false,
                    Message = "Could not update the session: " + ex.Message
                };
            }
        }
    }
}


using System;
using System.Data;
using System.Data.OleDb;
using TutoringAcademicSupport.Common;

namespace TutoringAcademicSupport.Student.UpdateBooking
{
    public class UpdateBookingHandler
    {

        private static DateTime TimeToDb(DateTime time)
        {
            return new DateTime(1899, 12, 30).Add(time.TimeOfDay);
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
                using (OleDbConnection connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Find the original session and verify ownership.
                    DateTime originalStart;

                    string findSql = @"
                        SELECT [Session_Date], [Session_StartTime]
                        FROM [TutoringSession]
                        WHERE [Session_ID] = ?
                          AND [Student_ID] = ?
                          AND [Session_Status] <> ?";

                    using (OleDbCommand command =
                           new OleDbCommand(findSql, connection))
                    {
                        command.Parameters.Add("?", OleDbType.Integer)
                            .Value = request.SessionId;
                        command.Parameters.Add("?", OleDbType.Integer)
                            .Value = request.StudentId;
                        command.Parameters.Add("?", OleDbType.VarWChar)
                            .Value = "Cancelled";

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
                        }
                    }

                    // Changes must be made at least 48 hours beforehand.
                    if (originalStart - DateTime.Now < TimeSpan.FromHours(48))
                    {
                        return new UpdateBookingResult
                        {
                            Success = false,
                            Message = "Changes must be made at least 48 hours before the tutorial."
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
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = TimeToDb(request.EndTime);
                        command.Parameters.Add("?", OleDbType.Date)
                            .Value = TimeToDb(request.StartTime);

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
                          AND [Session_Status] <> ?";

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
                            .Value = "Cancelled";

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

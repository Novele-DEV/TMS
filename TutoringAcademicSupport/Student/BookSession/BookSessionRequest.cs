using System;

namespace TutoringAcademicSupport.Student.BookSession
{
    // Everything the handler needs to book one tutoring session.
    public sealed class BookSessionRequest
    {
        public int StudentId { get; init; }

        // The tutoring request this session is booked for. TutoringSession.Request_ID is required.
        public int RequestId { get; init; }

        public string TutorId { get; init; } = string.Empty;

        // Only the date part is used.
        public DateTime SessionDate { get; init; }

        // Only the time-of-day part of StartTime and EndTime is used.
        public DateTime StartTime { get; init; }

        public DateTime EndTime { get; init; }

        public string ModeOfDelivery { get; init; } = string.Empty;
    }
}

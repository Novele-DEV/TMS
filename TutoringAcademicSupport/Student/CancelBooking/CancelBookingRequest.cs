using System;

namespace TutoringAcademicSupport.Student.CancelBooking
{
    // Carries the booking the student chose to cancel from the form to the handler.
    public sealed class CancelBookingRequest
    {
        public CancelBookingRequest(int sessionId, int requestId, DateTime sessionStart, string tutorName)
        {
            SessionId = sessionId;
            RequestId = requestId;
            SessionStart = sessionStart;
            TutorName = tutorName ?? string.Empty;
        }

        public int SessionId { get; }

        public int RequestId { get; }

        // What the form displayed. The handler re-reads the real start time from the database
        // so the 48 hour rule is never decided by a value the form supplied.
        public DateTime SessionStart { get; }

        public string TutorName { get; }

        // The logged-in student. When it is supplied, the handler also confirms that the
        // booking belongs to this student. Zero means the caller did not provide it.
        public int StudentId { get; init; }
    }
}

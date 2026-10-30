namespace TutoringAcademicSupport.Student.UpdateBooking
{
    public class UpdateBookingResult
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;
    }

    // One of the student's scheduled sessions, listed so they can choose it instead of typing a session ID.
    public sealed record ScheduledBooking(
        int SessionId,
        string TutorId,
        string TutorName,
        string CourseCode,
        DateTime SessionDate,
        DateTime StartTime,
        DateTime EndTime,
        string ModeOfDelivery)
    {
        // e.g. "Mon 03 Nov 2026, 09:00-10:00  ·  INFO2001A with Thabo Khumalo"
        public override string ToString() =>
            $"{SessionDate:ddd dd MMM yyyy}, {StartTime:HH:mm}-{EndTime:HH:mm}  ·  {CourseCode} with {TutorName}";
    }
}

namespace TutoringAcademicSupport.Student.BookSession
{
    public sealed class BookSessionResult
    {
        public bool Success { get; init; }

        public string Message { get; init; } = string.Empty;

        // The ID of the new booking. The student needs it to update a booking later. Zero when nothing was booked.
        public int SessionId { get; init; }
    }
}

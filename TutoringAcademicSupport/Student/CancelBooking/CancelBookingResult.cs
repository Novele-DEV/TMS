namespace TutoringAcademicSupport.Student.CancelBooking
{
    // The outcome the form shows to the student.
    public sealed class CancelBookingResult
    {
        public bool Success { get; init; }

        public string Message { get; init; } = string.Empty;
    }
}


using System;

namespace TutoringAcademicSupport.Student.UpdateBooking
{
    public class UpdateBookingRequest
    {
        public int SessionId { get; set; }

        public int StudentId { get; set; }

        public DateTime SessionDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string TutorId { get; set; } = string.Empty;

        public string ModeOfDelivery { get; set; } = string.Empty;
    }
}

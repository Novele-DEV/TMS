using System;

namespace Tutoring_Management_System
{
    internal class TutorInfo
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public double? AcademicAverage { get; set; }
        public string PreferredMode { get; set; } = string.Empty;
    }
}

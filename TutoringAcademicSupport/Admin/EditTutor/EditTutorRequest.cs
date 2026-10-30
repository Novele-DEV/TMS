namespace TutoringAcademicSupport.Admin.EditTutor
{
    // Carries the edited values for one tutor.
    // The academic average stays as text so the validator can report a badly typed number.
    public sealed class EditTutorRequest
    {
        public string TutorId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string AcademicAverage { get; }
        public string PreferredMode { get; }
        public string? CurriculumVitaePath { get; }

        public EditTutorRequest(
            string tutorId,
            string firstName,
            string lastName,
            string email,
            string phone,
            string academicAverage,
            string preferredMode,
            string? curriculumVitaePath = null)
        {
            TutorId = tutorId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            AcademicAverage = academicAverage;
            PreferredMode = preferredMode;
            CurriculumVitaePath = curriculumVitaePath;
        }
    }
}

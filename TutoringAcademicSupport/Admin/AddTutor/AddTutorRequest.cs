namespace TutoringAcademicSupport.Admin.AddTutor;

// Carries the values typed into the Add Tutor form.
// The academic average stays as text so the validator can report a badly typed number.
public sealed class AddTutorRequest
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }
    public string AcademicAverage { get; }
    public string PreferredMode { get; }
    public string? CurriculumVitaePath { get; }

    public AddTutorRequest(
        string firstName,
        string lastName,
        string email,
        string phone,
        string academicAverage,
        string preferredMode,
        string? curriculumVitaePath = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        AcademicAverage = academicAverage;
        PreferredMode = preferredMode;
        CurriculumVitaePath = curriculumVitaePath;
    }
}

namespace TutoringAcademicSupport.Student.CreateStudent;

public sealed class CreateStudentRequest
{
    public int StudentId { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; init; }
    public string Email { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string Faculty { get; init; } = string.Empty;
    public string Programme { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string ConfirmPassword { get; init; } = string.Empty;
}

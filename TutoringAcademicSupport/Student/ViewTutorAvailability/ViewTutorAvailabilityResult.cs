using System.Data;

namespace TutoringAcademicSupport.Student.ViewTutorAvailability;

public sealed class ViewTutorAvailabilityResult
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public DataTable Availability { get; init; } = new();
}
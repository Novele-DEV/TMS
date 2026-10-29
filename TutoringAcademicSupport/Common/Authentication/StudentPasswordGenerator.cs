using System.Globalization;

namespace TutoringAcademicSupport.Common.Authentication;

public static class StudentPasswordGenerator
{
    public static string Generate(int studentId, string firstName)
    {
        string normalizedFirstName = firstName.Trim();
        if (studentId <= 0 || normalizedFirstName.Length == 0)
        {
            throw new ArgumentException("A valid student ID and first name are required.");
        }

        string lastThreeDigits = (studentId % 1000).ToString("D3", CultureInfo.InvariantCulture);
        return $"{normalizedFirstName[^1]}{lastThreeDigits}#TMS";
    }
}

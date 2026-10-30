using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using TutoringAcademicSupport.Common.Files;

namespace TutoringAcademicSupport.Admin.AddTutor;

public static class AddTutorValidator
{
    // These values and lengths match the Tutor table in the database.
    private static readonly string[] PreferredModes = { "Virtual", "In-person", "Both" };

    public static string Validate(AddTutorRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName))
            return "Please enter the tutor's first name.";
        if (request.FirstName.Length > 50)
            return "The first name cannot be longer than 50 characters.";

        if (string.IsNullOrWhiteSpace(request.LastName))
            return "Please enter the tutor's last name.";
        if (request.LastName.Length > 50)
            return "The last name cannot be longer than 50 characters.";

        if (string.IsNullOrWhiteSpace(request.Email))
            return "Please enter the tutor's email address.";
        if (request.Email.Length > 100)
            return "The email address cannot be longer than 100 characters.";
        if (!MailAddress.TryCreate(request.Email, out _))
            return "Please enter a valid email address.";

        if (string.IsNullOrWhiteSpace(request.Phone))
            return "Please enter the tutor's phone number.";
        // matches the database rule: +27 followed by 9 digits
        if (!Regex.IsMatch(request.Phone, @"^\+27\d{9}$"))
            return "The phone number must look like +27821234567.";

        if (request.AcademicAverage.Length > 0)
        {
            if (!double.TryParse(request.AcademicAverage, NumberStyles.Number, CultureInfo.CurrentCulture, out double average))
                return "The academic average must be a number.";
            if (average < 0 || average > 100)
                return "The academic average must be between 0 and 100.";
        }

        if (Array.IndexOf(PreferredModes, request.PreferredMode) < 0)
            return "Please select a preferred mode.";

        return CurriculumVitaeFile.Validate(request.CurriculumVitaePath);
    }
}

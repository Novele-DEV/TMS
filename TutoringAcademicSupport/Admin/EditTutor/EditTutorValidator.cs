using System.IO;
using System.Globalization;
using System.Net.Mail;
using System.Security;
using System.Text.RegularExpressions;

namespace TutoringAcademicSupport.Admin.EditTutor
{
    public static class EditTutorValidator
    {
        public const int MaximumCurriculumVitaeSizeBytes = 5 * 1024 * 1024;

        // These values and lengths match the Tutor table in the database.
        private static readonly string[] PreferredModes = { "Virtual", "In-person", "Both" };

        public static string Validate(EditTutorRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.TutorId))
                return "No tutor was selected.";

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
                return "The preferred mode must be Virtual, In-person or Both.";

            return ValidateCurriculumVitae(request.CurriculumVitaePath);
        }

        private static string ValidateCurriculumVitae(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return string.Empty;

            try
            {
                if (!string.Equals(Path.GetExtension(path), ".pdf", StringComparison.OrdinalIgnoreCase))
                    return "The Curriculum Vitae file must be a PDF.";

                using FileStream file = new(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                if (file.Length > MaximumCurriculumVitaeSizeBytes)
                    return "The Curriculum Vitae PDF must be 5 MB or smaller.";

                Span<byte> signature = stackalloc byte[4];
                int bytesRead = 0;
                while (bytesRead < signature.Length)
                {
                    int count = file.Read(signature[bytesRead..]);
                    if (count == 0)
                        break;
                    bytesRead += count;
                }

                if (bytesRead != 4 ||
                    signature[0] != (byte)'%' ||
                    signature[1] != (byte)'P' ||
                    signature[2] != (byte)'D' ||
                    signature[3] != (byte)'F')
                {
                    return "The selected file does not have a valid PDF signature.";
                }

                return string.Empty;
            }
            catch (FileNotFoundException)
            {
                return "The selected Curriculum Vitae file no longer exists.";
            }
            catch (DirectoryNotFoundException)
            {
                return "The selected Curriculum Vitae file no longer exists.";
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or SecurityException or ArgumentException or NotSupportedException)
            {
                return "The selected Curriculum Vitae file could not be read. Check that it is not in use and that you have access.";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutoring_Management_System
{
    internal class TutorValidator
    {
        // Maximum lengths come from the Tutor table in our database
        public const int MaxName = 50;
        public const int MaxEmail = 100;
        public const int MaxPhone = 12;
        public const int MaxPreference = 20;

        public static Dictionary<string, string> Validate(string firstName, string lastName, string email, string phone, string academicAverage, string preference, string? excludeTutorId = null)
        {
            var errors = new Dictionary<string, string>();

            // Required fields
            if (string.IsNullOrWhiteSpace(firstName))
                errors["first"] = "First name is required.";
            else if (firstName.Trim().Length > MaxName)
                errors["first"] = "First name must be " + MaxName + " characters or fewer.";

            if (string.IsNullOrWhiteSpace(lastName))
                errors["last"] = "Last name is required.";
            else if (lastName.Trim().Length > MaxName)
                errors["last"] = "Last name must be " + MaxName + " characters or fewer.";

            if (string.IsNullOrWhiteSpace(email))
                errors["email"] = "Email is required.";
            else if (!IsValidEmail(email))
                errors["email"] = "Enter a valid email address, e.g. name@university.ac.za.";

            if (string.IsNullOrWhiteSpace(phone))
                errors["phone"] = "Phone number is required.";
            else if (!IsValidPhone(phone))
                errors["phone"] = "Enter a valid phone number, e.g. 0821234567 or +27821234567.";

            double average;
            if (string.IsNullOrWhiteSpace(academicAverage))
                errors["average"] = "Academic average is required.";
            else if (!TryParseAverage(academicAverage, out average))
                errors["average"] = "Enter a number between 0 and 100, e.g. 72.5.";

            if (string.IsNullOrWhiteSpace(preference))
                errors["preference"] = "Select a preference.";

            // Duplicate check (only when the email itself is valid)
            if (!errors.ContainsKey("email") && TutorRepository.EmailExists(email.Trim(), excludeTutorId))
                errors["email"] = "A tutor with this email address already exists.";

            return errors;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string e = email.Trim();
            return e.Length <= MaxEmail && Regex.IsMatch(e, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static string NormalisePhone(string phone)
        {
            return Regex.Replace(phone ?? "", @"[\s\-()]", "");
        }

        // South African format: 0 + 9 digits, or +27 + 9 digits
        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(NormalisePhone(phone), @"^(\+27|0)\d{9}$");
        }

        // Accepts "72.5" or "72,5". Must be 0 to 100.(My laptops had problem with the two)
        public static bool TryParseAverage(string text, out double value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(text)) return false;
            string cleaned = text.Trim().Replace("%", "").Replace(',', '.');
            if (!double.TryParse(cleaned, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return false;
            return value >= 0 && value <= 100;
        }
    }
}

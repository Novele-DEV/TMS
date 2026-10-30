using System.Security;

namespace TutoringAcademicSupport.Common.Files
{
    // The rules for a tutor's CV, shared by Add Tutor and Edit Tutor so they cannot disagree.
    // CVs are saved inside the database file, which the team shares through Git, so the size is kept small.
    public static class CurriculumVitaeFile
    {
        public const int MaximumSizeBytes = 2 * 1024 * 1024;

        private static string TooLargeMessage => $"The Curriculum Vitae PDF must be {MaximumSizeBytes / (1024 * 1024)} MB or smaller.";

        // Returns the problem with the chosen file, or an empty string when it is fine or no file was chosen.
        public static string Validate(string? path)
        {
            TryRead(path, out _, out string error);
            return error;
        }

        // Reads the chosen file after checking it. No file chosen is fine, because a CV is optional.
        public static bool TryRead(string? path, out byte[]? bytes, out string error)
        {
            bytes = null;
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(path))
                return true;

            try
            {
                if (!string.Equals(Path.GetExtension(path), ".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    error = "The Curriculum Vitae file must be a PDF.";
                    return false;
                }

                FileInfo file = new(path);
                if (!file.Exists)
                {
                    error = "The selected Curriculum Vitae file no longer exists.";
                    return false;
                }

                if (file.Length > MaximumSizeBytes)
                {
                    error = TooLargeMessage;
                    return false;
                }

                bytes = File.ReadAllBytes(path);
            }
            catch (Exception ex) when (ex is FileNotFoundException or DirectoryNotFoundException)
            {
                error = "The selected Curriculum Vitae file no longer exists.";
                return false;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or SecurityException or ArgumentException or NotSupportedException)
            {
                error = "The selected Curriculum Vitae file could not be read. Check that it is not in use and that you have access.";
                return false;
            }

            // checked again on the bytes actually read, because the file could have changed
            if (bytes.Length > MaximumSizeBytes)
            {
                bytes = null;
                error = TooLargeMessage;
                return false;
            }

            if (!IsPdf(bytes))
            {
                bytes = null;
                error = "The selected file does not have a valid PDF signature.";
                return false;
            }

            return true;
        }

        // Every PDF starts with %PDF, so a renamed Word document or image does not pass.
        public static bool IsPdf(byte[] bytes)
        {
            return bytes.Length >= 4 &&
                   bytes[0] == (byte)'%' &&
                   bytes[1] == (byte)'P' &&
                   bytes[2] == (byte)'D' &&
                   bytes[3] == (byte)'F';
        }
    }
}

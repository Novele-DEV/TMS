using System;

namespace TutoringAcademicSupport.Student.BookSession
{
    public static class BookSessionValidator
    {
        public const string ModeInPerson = "In-person";
        public const string ModeVirtual = "Virtual";

        // The delivery modes a booking can use. The form can fill its list from here.
        public static readonly string[] Modes = { ModeInPerson, ModeVirtual };

        // Tutor_ID is a Text(8) column.
        public const int TutorIdMaxLength = 8;

        // Combines the date with a time of day. Seconds are dropped because tutor availability
        // is stored in whole minutes, so 09:00:37 must be treated as 09:00.
        public static DateTime Combine(DateTime date, DateTime time)
        {
            TimeSpan timeOfDay = time.TimeOfDay;
            return date.Date.Add(new TimeSpan(timeOfDay.Hours, timeOfDay.Minutes, 0));
        }

        public static string Validate(BookSessionRequest request)
        {
            return Validate(request, DateTime.Now);
        }

        // The current time is a parameter so the rules can be checked at exact boundaries.
        public static string Validate(BookSessionRequest request, DateTime now)
        {
            if (request == null)
            {
                return "The booking details are missing.";
            }

            if (request.StudentId <= 0)
            {
                return "Please enter a valid student ID.";
            }

            if (request.RequestId <= 0)
            {
                return "Please select the tutoring request you want to book a session for.";
            }

            if (string.IsNullOrWhiteSpace(request.TutorId))
            {
                return "Please select a tutor.";
            }

            if (request.TutorId.Trim().Length > TutorIdMaxLength)
            {
                return $"Tutor ID must be {TutorIdMaxLength} characters or fewer.";
            }

            DateTime start = Combine(request.SessionDate, request.StartTime);
            DateTime end = Combine(request.SessionDate, request.EndTime);

            if (start <= now)
            {
                return "Please select a session date and start time in the future.";
            }

            if (end <= start)
            {
                return "The end time must be after the start time.";
            }

            if (string.IsNullOrWhiteSpace(request.ModeOfDelivery))
            {
                return "Please select a mode of delivery.";
            }

            if (Array.IndexOf(Modes, request.ModeOfDelivery) < 0)
            {
                return "Please select " + string.Join(" or ", Modes) + ".";
            }

            return string.Empty;
        }
    }
}

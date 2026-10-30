using System;

namespace TutoringAcademicSupport.Student.CancelBooking
{
    public static class CancelBookingValidator
    {
        // The notice period is defined once here. The check, the error message and the
        // notice shown to the student are all built from this value so they cannot disagree.
        public const int MinimumNoticeHours = 48;

        public static string RuleNotice =>
            $"Bookings cannot be changed or cancelled less than {MinimumNoticeHours} hours before the session.";

        // The same rule for the screens with room for only one short line.
        public static string ShortRuleNotice =>
            $"No changes or cancellations within {MinimumNoticeHours} hours of a session.";

        // Used by the form before it asks the student to confirm.
        public static string Validate(DateTime sessionStart)
        {
            return Validate(sessionStart, DateTime.Now);
        }

        // The current time is a parameter so the rule can be checked at exact boundaries.
        public static string Validate(DateTime sessionStart, DateTime now)
        {
            if (sessionStart <= now)
            {
                return "This session has already started or passed, so it cannot be cancelled.";
            }

            if (sessionStart - now < TimeSpan.FromHours(MinimumNoticeHours))
            {
                return $"This session starts in less than {MinimumNoticeHours} hours, so it can no longer be cancelled.";
            }

            return string.Empty;
        }

        // Used by the handler. Returns an empty string when the request is acceptable.
        public static string Validate(CancelBookingRequest request)
        {
            if (request == null)
            {
                return "The booking details are missing.";
            }

            if (request.SessionId <= 0 || request.RequestId <= 0)
            {
                return "Please select the booking you want to cancel.";
            }

            return Validate(request.SessionStart);
        }
    }
}

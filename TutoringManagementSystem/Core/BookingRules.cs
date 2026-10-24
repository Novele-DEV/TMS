
using System;

namespace TutoringManagementSystem
{
    public static class BookingRules
    {
        // Checks whether a tutorial is in the future.
        public static bool IsFutureSession(DateTime sessionDateTime)
        {
            return sessionDateTime > DateTime.Now;
        }

        // Checks whether at least 48 hours remain.
        public static bool IsAtLeast48HoursAway(DateTime sessionDateTime)
        {
            return sessionDateTime - DateTime.Now
                   >= TimeSpan.FromHours(48);
        }

        // Validates a new booking.
        public static string ValidateBooking(DateTime sessionDateTime)
        {
            if (sessionDateTime <= DateTime.Now)
            {
                return "Please select a future tutorial date and time.";
            }

            return string.Empty;
        }

        // Validates changes or cancellation.
        public static string ValidateChangeOrCancellation(
            DateTime sessionDateTime)
        {
            if (!IsAtLeast48HoursAway(sessionDateTime))
            {
                return "Changes and cancellations must be made " +
                       "at least 48 hours before the tutorial.";
            }

            return string.Empty;
        }
    }
}

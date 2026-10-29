
using System;

namespace TutoringAcademicSupport.Student.UpdateBooking
{
    public static class UpdateBookingValidator
    {
        public static string Validate(UpdateBookingRequest request)
        {
            if (request == null)
            {
                return "The booking details are missing.";
            }

            if (request.SessionId <= 0)
            {
                return "Please select a valid tutoring session.";
            }

            if (request.StudentId <= 0)
            {
                return "Please enter a valid student ID.";
            }

            DateTime start = request.SessionDate.Date
                .Add(request.StartTime.TimeOfDay);

            DateTime end = request.SessionDate.Date
                .Add(request.EndTime.TimeOfDay);

            if (start <= DateTime.Now)
            {
                return "The new session must be in the future.";
            }

            if (end <= start)
            {
                return "The end time must be after the start time.";
            }

            if (string.IsNullOrWhiteSpace(request.TutorId))
            {
                return "Please select a tutor.";
            }

            if (string.IsNullOrWhiteSpace(request.ModeOfDelivery))
            {
                return "Please select a mode of delivery.";
            }

            if (request.ModeOfDelivery != "In-person" &&
                request.ModeOfDelivery != "Virtual")
            {
                return "Please select In-person or Virtual.";
            }

            return string.Empty;
        }
    }
}

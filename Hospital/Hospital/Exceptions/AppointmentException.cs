using System;

namespace Hospital.Exceptions
{
    public class AppointmentException : Exception
    {
        public AppointmentException()
        {
            
        }

        public AppointmentException(string message) : base(message)
        {
            
        }
    }
}
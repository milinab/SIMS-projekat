using System;

namespace Hospital.Exceptions
{
    public class VacationException : Exception
    {
        public VacationException()
        {
        }

        public VacationException(string message) : base(message)
        {
        }
    }
}
using System;

namespace Controllers.Exceptions
{
    public class UsetNotLoggedException : Exception
    {
        public UsetNotLoggedException(string message) : base(message) { }
    }
}

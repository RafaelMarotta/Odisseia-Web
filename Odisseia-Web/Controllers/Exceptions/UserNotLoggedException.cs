using System;

namespace Controllers.Exceptions
{
    public class UserNotLoggedException : Exception
    {
        public UserNotLoggedException(string message) : base(message) { }
    }
}

using System;

namespace Controllers.Exceptions
{
    public class UserNotLoggedException : OdisseiaWebTreatedException
    {
        public UserNotLoggedException() : base() { }
        public UserNotLoggedException(string message) : base(message) { }
    }
}

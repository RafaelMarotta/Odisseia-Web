using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers.Exceptions
{
    public class OdisseiaWebTreatedException : Exception
    {
        public OdisseiaWebTreatedException() : base() { }
        public OdisseiaWebTreatedException(string message) : base(message) { }
    }
}

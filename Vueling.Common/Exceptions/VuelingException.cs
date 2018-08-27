using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Vueling.Common.Exceptions
{
    public class VuelingException : Exception
    {
        public VuelingException()
        {
        }

        public VuelingException(string message) : base(message)
        {
        }

        public VuelingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VuelingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

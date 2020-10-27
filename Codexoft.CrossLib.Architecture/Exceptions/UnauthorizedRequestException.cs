using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Exceptions
{
    public class UnauthorizedRequestException : Exception
    {
        public UnauthorizedRequestException()
        {
        }

        public UnauthorizedRequestException(string message) : base(message)
        {
        }

        public UnauthorizedRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

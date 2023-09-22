using System;

namespace Timeportal.Infrastructure.Exceptions
{
    [Serializable]
    public class InvalidApplicationOperationException : InvalidOperationException
    {
        public InvalidApplicationOperationException(string message)
            : base(message)
        {
        }
    }
}

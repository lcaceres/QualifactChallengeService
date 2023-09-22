using System;

namespace Timeportal.Infrastructure.Exceptions
{
    [Serializable]
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(string message) : base(message)
        {
        }
    }
}

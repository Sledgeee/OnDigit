using System;

namespace OnDigit.Core.Exceptions
{
    public class EmptyFieldException : Exception
    {
        public EmptyFieldException(string message) : base(message)
        {
        }
    }
}

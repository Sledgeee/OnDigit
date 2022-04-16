using System;

namespace OnDigit.Core.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string Email { get; set; }

        public UserNotFoundException(string email)
        {
            Email = email;
        }

        public UserNotFoundException(string message, string email) : base(message)
        {
            Email = email;
        }

        public UserNotFoundException(string message, string email, Exception innerException) : base(message, innerException)
        {
            Email = email;
        }
    }
}

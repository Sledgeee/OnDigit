using System;

namespace OnDigit.Core.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public InvalidPasswordException(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public InvalidPasswordException(string message, string email, string password) : base(message)
        {
            Email = email;
            Password = password;
        }

        public InvalidPasswordException(string message, string email, string password, Exception innerException) : base(message, innerException)
        {
            Email = email;
            Password = password;
        }
    }
}

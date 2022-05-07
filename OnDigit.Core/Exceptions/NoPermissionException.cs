using System;

namespace OnDigit.Core.Exceptions
{
    public class NoPermissionException : Exception
    {
        public string BookId { get; set; }

        public NoPermissionException(string bookId)
        {
             BookId = bookId;
        }

        public NoPermissionException(string message, string bookId) : base(message)
        {
            BookId = bookId;
        }
    }
}

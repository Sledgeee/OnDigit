using System;

namespace OnDigit.Core.Exceptions
{
    public class NoPermissionException : Exception
    {
        public string EditionId { get; set; }

        public NoPermissionException(string editionId)
        {
             EditionId = editionId;
        }

        public NoPermissionException(string message, string editionId) : base(message)
        {
            EditionId = editionId;
        }
    }
}

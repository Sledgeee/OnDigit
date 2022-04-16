using System.Collections.Generic;

namespace OnDigit.Core.Extensions.Mails
{
    public class MailingRequest<T>
    {
        public IEnumerable<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

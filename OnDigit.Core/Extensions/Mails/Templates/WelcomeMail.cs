using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnDigit.Core.Extensions.Mails.Templates
{
    public class WelcomeMail
    {
        public string Email { get; set; }
        public readonly string Subject = "Welcome to a VividBooks!";
        private string _name;
        private string _surname;
        public readonly string Body = "";
    }
}

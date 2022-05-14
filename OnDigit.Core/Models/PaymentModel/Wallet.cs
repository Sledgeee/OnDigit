using OnDigit.Core.Models.UserModel;
using System;

namespace OnDigit.Core.Models.PaymentModel
{
    public class Wallet : EntityObject, IDisposable
    {
        public string UserId { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public DateTime DateAdded { get; set; }

        public User User { get; set; }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            base.Dispose();
        }
    }
}

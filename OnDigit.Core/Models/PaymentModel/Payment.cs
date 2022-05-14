using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.UserModel;
using System;

namespace OnDigit.Core.Models.PaymentModel
{
    public sealed class Payment : EntityObject, IDisposable
    {
        public string UserId { get; set; }
        public int OrderNumber { get; set; }
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }
        public DateTime DatePayment { get; set; }

        public User User { get; set; }
        public Order Order { get; set; }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            base.Dispose();
        }
    }
}

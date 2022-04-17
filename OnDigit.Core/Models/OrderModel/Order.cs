using System;
using System.Collections.Generic;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.OrderEditionModel;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Interfaces;

namespace OnDigit.Core.Models.OrderModel
{
    public class Order : EntityObject, IBaseEntity
    {
        public decimal TotalPrice { get; set; }
        public DateTimeOffset DateOrder { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Edition> Editions { get; set; } = new List<Edition>();
        public List<OrderEdition> OrdersEditions { get; set; } = new List<OrderEdition>();

        public override void Dispose()
        {
            GC.Collect();
            base.Dispose();
        }
    }
}

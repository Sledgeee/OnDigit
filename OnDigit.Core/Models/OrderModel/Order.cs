using System;
using System.Collections.Generic;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.OrderEditionModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.OrderModel
{
    public class Order : IDisposable
    {
        public int Number { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateOrder { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Edition> Editions { get; set; } = new List<Edition>();
        public List<OrderEdition> OrdersEditions { get; set; } = new List<OrderEdition>();

        public void Dispose()
        {
            GC.Collect();
        }
    }
}

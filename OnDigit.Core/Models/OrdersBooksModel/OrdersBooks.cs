using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderModel;
using System;

namespace OnDigit.Core.Models.OrderBookModel
{
    public class OrdersBooks : IDisposable
    {
        public int OrderNumber { get; set; }
        public Order Order { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

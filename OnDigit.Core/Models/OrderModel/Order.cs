using System;
using System.Collections.Generic;
using System.Linq;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderBookModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.OrderModel
{
    public enum OrderStatus
    {
        Processing = 0,
        Blocked = 1,
        Completed = 2
    }

    public class Order : IDisposable
    {
        public int Number { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateOrder { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public List<OrdersBooks> OrdersBooks { get; set; } = new List<OrdersBooks>();

        public static string EnumOrderStatusToString(OrderStatus status)
        {
            return typeof(OrderStatus).GetFields().Where(x => x.IsLiteral).Select(x => x.Name).ToArray()[(int)status];
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

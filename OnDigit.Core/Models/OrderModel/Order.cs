using System;
using System.Collections.Generic;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderBookModel;
using OnDigit.Core.Models.PaymentModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.OrderModel
{
    public enum OrderStatus : int
    {
        Payment = 0,
        Delivery = 1,
        Completed = 2,
        Blocked = 3
    }

    public enum PayStatus : int
    {
        Unpaid = 0,
        Paid = 1
    }

    public enum DeliveryCompany : int
    {
        NovaPoshta = 0,
        Ukrposhta = 1,
        Justin = 2
    }

    public sealed class Order : IDisposable
    {
        public Order()
        {
            Books = new List<Book>();
            OrdersBooks = new List<OrdersBooks>();
        }

        public int Number { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public string UserId { get; set; }
        public int TotalBooksQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string DeliveryAddress { get; set; }
        public DeliveryCompany DeliveryCompany { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PayStatus PayStatus { get; set; }
        public DateTime DateOrder { get; set; }

        public User User { get; set; }
        public Payment Payment { get; set; }
        public ICollection<Book> Books { get; set; }
        public List<OrdersBooks> OrdersBooks { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}

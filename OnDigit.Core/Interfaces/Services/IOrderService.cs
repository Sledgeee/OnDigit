using Ardalis.Specification;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.CartModel;
using OnDigit.Core.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(string userId, string userFullname, string userPhone, string userEmail,
                              Dictionary<Book, Tuple<int, decimal>> books, decimal totalAmount, 
                              DeliveryCompany deliveryCompany, string deliveryAddress, string cardToPay);

        Task CompleteOrder(int orderNumber, string userId, decimal totalAmount, string cardToPay, Dictionary<Book, Tuple<int, decimal>> books);
        Task<ICollection<Order>> GetOrdersBySpecAsync(ISpecification<Order> specification);
    }
}

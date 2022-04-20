using Ardalis.Specification;
using OnDigit.Core.Models.CartModel;
using OnDigit.Core.Models.OrderModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(string userId, Cart cart);
        Task<ICollection<Order>> GetOrdersBySpecAsync(ISpecification<Order> specification);
    }
}

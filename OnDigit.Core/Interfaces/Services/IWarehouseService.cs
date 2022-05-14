using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.PaymentModel;
using OnDigit.Core.Models.WarehouseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IWarehouseService
    {
        Task<ICollection<Warehouse>> GetAllWarehousesAsync();
        Task<ICollection<Payment>> GetAllPaymentsAsync();
        Task<Order> ChangeOrderStatus(int orderNumber, OrderStatus status);
    }
}

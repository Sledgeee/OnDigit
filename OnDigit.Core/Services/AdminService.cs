using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.PaymentModel;
using OnDigit.Core.Models.WarehouseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IOrderService _orderService;
        private readonly IWarehouseService _warehouseService;

        public AdminService(IOrderService orderService, IWarehouseService warehouseService)
        {
            _orderService = orderService;
            _warehouseService = warehouseService;
        }

        public async Task<Order> ChangeOrderStatus(int orderNumber, OrderStatus status) =>
            await _warehouseService.ChangeOrderStatus(orderNumber, status);

        public async Task<ICollection<Order>> GetAllOrdersAsync() =>
            await _orderService.GetOrdersBySpecAsync(new Orders.AllOrders());

        public async Task<ICollection<Payment>> GetAllPaymentsAsync() =>
            await _warehouseService.GetAllPaymentsAsync();

        public async Task<ICollection<Warehouse>> GetAllWarehousesAsync() =>
            await _warehouseService.GetAllWarehousesAsync();
    }
}

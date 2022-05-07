using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.StockModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IDataService<Book> _bookService;
        private readonly IOrderService _orderService;
        private readonly IStockService _stockService;

        public AdminService(IDataService<Book> bookService, IOrderService orderService, IStockService stockService)
        {
            _bookService = bookService;
            _orderService = orderService;
            _stockService = stockService;
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync() =>
            await _orderService.GetOrdersBySpecAsync(new Orders.AllOrders());

        public async Task<ICollection<Stock>> GetAllStocksAsync() =>
            await _stockService.GetAllStocksAsync();
    }
}

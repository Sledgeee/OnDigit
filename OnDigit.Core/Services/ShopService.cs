using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Extensions;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderModel;

namespace OnDigit.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IDataService<Book> _bookService;
        private readonly IOrderService _orderService;

        public ShopService(IDataService<Book> bookService, IOrderService orderService)
        {
            _bookService = bookService;
            _orderService = orderService;
        }

        public async Task DeleteBookAsync(string id)
        {
            (await _bookService.GetByIdAsync(id)).BookNullChecking();
            await _bookService.DeleteAsync(id);
        }

        public async Task<ICollection<Book>> GetAllBooksAsync() =>
            await _bookService.GetListBySpecAsync(new Books.AllBooks());

        public async Task<ICollection<Book>> SearchBooksAsync(string searchRow) =>
            await _bookService.GetListBySpecAsync(new Books.BookSearch(searchRow));

        public async Task<ICollection<Order>> GetCurrentUserOrdersAsync(string userId) =>
            await _orderService.GetOrdersBySpecAsync(new Orders.CurrentUserOrders(userId));

    }
}

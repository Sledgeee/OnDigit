using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Extensions;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.CartModel;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.OrderModel;

namespace OnDigit.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IDataService<Edition> _editionService;
        private readonly IReviewService _reviewService;
        private readonly IOrderService _orderService;

        public ShopService(IDataService<Edition> editionService, IReviewService reviewService, IOrderService orderService)
        {
            _editionService = editionService;
            _reviewService = reviewService;
            _orderService = orderService;
        }

        public async Task<ICollection<Edition>> GetAllEditionsAsync() =>
            await _editionService.GetListBySpecAsync(new Editions.EditionLoad());

        public async Task DeleteEditionAsync(string id)
        {
            (await _editionService.GetByIdAsync(id)).EditionNullChecking();
            await _editionService.DeleteAsync(id);
        }

        public async Task<ICollection<Edition>> SearchEditionsAsync(string searchRow) =>
            await _editionService.GetListBySpecAsync(new Editions.EditionSearch(searchRow));

        public async Task<ICollection<Order>> LoadCurrentUserOrdersAsync(string userId) =>
            await _orderService.GetOrdersBySpecAsync(new Orders.CurrentUserOrders(userId));
    }
}

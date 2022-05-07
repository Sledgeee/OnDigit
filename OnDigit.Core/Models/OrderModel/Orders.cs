using Ardalis.Specification;
using System.Linq;

namespace OnDigit.Core.Models.OrderModel
{
    public class Orders
    {
        internal class AllOrders : Specification<Order>
        {
            public AllOrders()
            {
                Query.Include(x => x.OrdersBooks).ThenInclude(x => x.Book).Include(x => x.User).OrderByDescending(x => x.Number);
            }
        }

        internal class CurrentUserOrders : Specification<Order>
        {
            public CurrentUserOrders(string userId)
            {
                Query.Include(x => x.OrdersBooks).ThenInclude(x => x.Book).Where(x => x.UserId == userId).OrderByDescending(x => x.Number);
            }
        }
    }
}

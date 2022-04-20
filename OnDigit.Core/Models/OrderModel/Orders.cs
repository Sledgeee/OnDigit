using Ardalis.Specification;
using System.Linq;

namespace OnDigit.Core.Models.OrderModel
{
    public class Orders
    {
        internal class CurrentUserOrders : Specification<Order>
        {
            public CurrentUserOrders(string userId)
            {
                Query.Include(x => x.OrdersEditions).Where(x => x.UserId == userId);
            }
        }
    }
}

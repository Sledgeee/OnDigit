using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.StockModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IAdminService
    {
        Task<ICollection<Order>> GetAllOrdersAsync();
        Task<ICollection<Stock>> GetAllStocksAsync();
    }
}

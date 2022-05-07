using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderModel;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IShopService
    {
        Task DeleteBookAsync(string id);
        Task<ICollection<Book>> GetAllBooksAsync();
        Task<ICollection<Book>> SearchBooksAsync(string seachRow);
        Task<ICollection<Order>> GetCurrentUserOrdersAsync(string userId);
    }
}

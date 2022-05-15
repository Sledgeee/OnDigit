using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.PaymentModel;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task AddLoginToHistory(string userId);
        Task<ICollection<Wallet>> GetUserWallet(string userId);
        Task<bool> RemoveCard(string userId, string cardId);
        Task<bool> AddNewCard(Wallet wallet);
        Task SetFavoriteBookAsync(string userId, string bookId);
        Task DeleteFavoriteBookAsync(string userId, string bookId);
        Task SetRememberMeStatus(string userId);
        Task<Session> GetSessionInfo(string pcId, string userId);
        Task UpdateSessionInfo(Session session);
    }
}
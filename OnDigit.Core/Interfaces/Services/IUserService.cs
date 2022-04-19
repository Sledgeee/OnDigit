using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task AddLoginToHistory(string userId);
        Task<ICollection<UserFavorite>> GetFavoriteEditionsAsync(string userId);
        Task SetFavoriteEditionAsync(string userId, string editionId);
        Task DeleteFavoriteEditionAsync(string userId, string editionId);
        Task SetRememberMeStatus(string userId);
        Task<Session> GetSessionInfo(string pcId, string userId);
        Task UpdateSessionInfo(Session session);
    }
}
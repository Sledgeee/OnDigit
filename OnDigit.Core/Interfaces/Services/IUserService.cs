using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.UserFavoritesModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task AddLoginToHistory(string userId);
        Task<ICollection<UserFavorites>> GetFavoriteEditionsAsync(string userId);
    }
}
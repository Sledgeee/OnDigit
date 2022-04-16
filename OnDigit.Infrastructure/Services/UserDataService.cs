using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Infrastructure.Data;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.UserFavoritesModel;
using OnDigit.Core.Models.UserLoginHistoryModel;

namespace OnDigit.Infrastructure.Services
{
    public class UserDataService : IUserService
    {
        private readonly OnDigitDbContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;
        private readonly DbSet<User> _dbSet;

        public UserDataService(OnDigitDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
            _dbSet = _contextFactory.CreateDbContext().Set<User>();
        }

        public async Task<User> AddAsync(User entity)
        {
            return await _nonQueryDataService.Add(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<User> GetByIdAsync(string id)
        {
            using (OnDigitDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users.FirstOrDefaultAsync((e) => e.Id == id);
            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            using (OnDigitDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(e => e.Email == email);
            }
        }

        public async Task AddLoginToHistory(string userId)
        {
            using (OnDigitDbContext context = _contextFactory.CreateDbContext())
            {
                await context.UsersLoginHistory.AddAsync(new UserLoginHistory() { UserId = userId });
                await context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            using (OnDigitDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async Task<User> UpdateAsync(string id, User entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        private IQueryable<User> ApplySpecification(ISpecification<User> specification)
        {
            return new SpecificationEvaluator().GetQuery(_dbSet, specification);
        }

        public async Task<ICollection<User>> GetListBySpecAsync(ISpecification<User> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<ICollection<UserFavorites>> GetFavoriteEditionsAsync(string userId)
        {
            using (OnDigitDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.UserFavorites.Where(x => x.UserId == userId).ToListAsync();
            }
        }
    }
}

using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Infrastructure.Data;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.UserLoginHistoryModel;
using OnDigit.Core.Models.SessionModel;
using Microsoft.Win32;
using System;
using OnDigit.Core.Models.PaymentModel;

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

        public async Task<User> AddAsync(User entity) => await _nonQueryDataService.Add(entity);

        public async Task<bool> DeleteAsync(string id) => await _nonQueryDataService.Delete(id);

        public async Task<User> GetByIdAsync(string id)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            return await context.Users.Include(x => x.UserLogins)
                .Include(x => x.Reviews)
                .Include(x => x.Orders).ThenInclude(x => x.Books)
                .Include(x => x.Wallets)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            return await context.Users.Include(x => x.UserLogins)
                .Include(x => x.Reviews)
                .Include(x => x.Orders).ThenInclude(x => x.Books)
                .Include(x => x.Wallets)
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<ICollection<Wallet>> GetUserWallet(string userId)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            return await context.Wallets.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<bool> RemoveCard(string userId, string cardId)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            var entity = await context.Wallets.FirstAsync(x => x.Id == cardId && x.UserId == userId);
            context.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task AddLoginToHistory(string userId)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            await context.UsersLoginHistory.AddAsync(new UserLoginHistory() { UserId = userId });
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            return await context.Users.ToListAsync();
        }

        public async Task<User> UpdateAsync(User entity) => await _nonQueryDataService.Update(entity);

        private IQueryable<User> ApplySpecification(ISpecification<User> specification) => 
            new SpecificationEvaluator().GetQuery(_dbSet, specification);

        public async Task<ICollection<User>> GetListBySpecAsync(ISpecification<User> specification) =>
            await ApplySpecification(specification).ToListAsync();

        public async Task<bool> AddNewCard(Wallet wallet)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            await context.Wallets.AddAsync(wallet);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task SetFavoriteBookAsync(string userId, string bookId)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            await context.UserFavorites.AddAsync(new UserFavorite()
            {
                UserId = userId,
                BookId = bookId
            });
            await context.SaveChangesAsync();
        }

        public async Task DeleteFavoriteBookAsync(string userId, string bookId)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            context.UserFavorites.Remove(new UserFavorite()
            {
                UserId = userId,
                BookId = bookId
            });
            await context.SaveChangesAsync();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public async Task SetRememberMeStatus(string userId)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            var pcId = Guid.NewGuid().ToString();

            using var key = Registry.CurrentUser.CreateSubKey("OnDigitSession");
            key.SetValue("pcId", pcId);
            key.SetValue("userId", userId);
            key.Close();

            await context.Sessions.AddAsync(new Session()
            {
                UserId = userId,
                MACHINE_KEY = pcId,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1),
                IsCanceledInAdvance = false
            });
            await context.SaveChangesAsync();
        }

        public async Task<Session> GetSessionInfo(string pcId, string userId)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            return await context.Sessions.Where(x => x.UserId == userId && x.MACHINE_KEY == pcId).OrderByDescending(x => x.EndDate).FirstOrDefaultAsync();
        }

        public async Task UpdateSessionInfo(Session session)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            session.IsCanceledInAdvance = true;
            context.Sessions.Update(session);
            await context.SaveChangesAsync();
        }
    }
}

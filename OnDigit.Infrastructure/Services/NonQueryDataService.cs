using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using OnDigit.Core.Models;
using OnDigit.Infrastructure.Data;

namespace OnDigit.Infrastructure.Services
{
    public class NonQueryDataService<T> where T : EntityObject
    {
        private readonly OnDigitDbContextFactory _contextFactory;

        public NonQueryDataService(OnDigitDbContextFactory contextFactory) => _contextFactory = contextFactory;

        public async Task<T> Add(T entity)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdResult.Entity;
        }

        public async Task<T> Update(T entity)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(string id)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

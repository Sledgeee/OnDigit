using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnDigit.Core.Models;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Infrastructure.Data;

namespace OnDigit.Infrastructure.Services
{
    public class GenericDataService<T> : IDataService<T> where T : EntityObject
    {
        private readonly OnDigitDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;
        private readonly DbSet<T> _dbSet;

        public GenericDataService(OnDigitDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
            _dbSet = _contextFactory.CreateDbContext().Set<T>();
        }

        public async Task<T> AddAsync(T entity) => await _nonQueryDataService.Add(entity);

        public async Task<bool> DeleteAsync(string id) => await _nonQueryDataService.Delete(id);


        public async Task<T> GetByIdAsync(string id)
        {
            using (OnDigitDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            }
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            using (OnDigitDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public async Task<T> UpdateAsync(string id, T entity) => await _nonQueryDataService.Update(id, entity);

        private IQueryable<T> ApplySpecification(ISpecification<T> specification) => 
            new SpecificationEvaluator().GetQuery(_dbSet, specification);

        public async Task<ICollection<T>> GetListBySpecAsync(ISpecification<T> specification) =>
            await ApplySpecification(specification).ToListAsync();
    }
}

using Ardalis.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IDataService<T>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
        Task<ICollection<T>> GetListBySpecAsync(ISpecification<T> specification);
    }
}

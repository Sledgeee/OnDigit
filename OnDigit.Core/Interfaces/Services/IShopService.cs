using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.EditionModel;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IShopService
    {
        Task<ICollection<Edition>> GetAllEditionsAsync();
        Task DeleteEditionAsync(string id);
        Task<ICollection<Edition>> SearchEditionsAsync(string seachRow);
    }
}

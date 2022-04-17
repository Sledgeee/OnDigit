using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Extensions;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.EditionModel;

namespace OnDigit.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IDataService<Edition> _editionService;

        public ShopService(IDataService<Edition> editionService)
        {
            _editionService = editionService;
        }

        public async Task<ICollection<Edition>> GetAllEditionsAsync()
        {
            return await _editionService.GetAllAsync();
        }

        public async Task DeleteEditionAsync(string id)
        {
            (await _editionService.GetByIdAsync(id)).EditionNullChecking();
            await _editionService.DeleteAsync(id);
        } 

        public async Task<ICollection<Edition>> SearchEditionsAsync(string searchRow)
        {
            return await _editionService.GetListBySpecAsync(new Editions.EditionSearch(searchRow));
        }
    }
}

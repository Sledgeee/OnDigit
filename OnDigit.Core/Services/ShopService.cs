using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Extensions;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.EditionModel;
using System.Linq;
using OnDigit.Core.Models.GenreModel;
using System;

namespace OnDigit.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IDataService<Edition> _editionService;
        private readonly IReviewService _reviewService;

        public ShopService(IDataService<Edition> editionService, IReviewService reviewService)
        {
            _editionService = editionService;
            _reviewService = reviewService;
        }

        public async Task<ICollection<Edition>> GetAllEditionsAsync() => await _editionService.GetAllAsync();
       

        public async Task DeleteEditionAsync(string id)
        {
            (await _editionService.GetByIdAsync(id)).EditionNullChecking();
            await _editionService.DeleteAsync(id);
        } 

        public async Task<ICollection<Edition>> SearchEditionsAsync(string searchRow) =>
            await _editionService.GetListBySpecAsync(new Editions.EditionSearch(searchRow));
    }
}

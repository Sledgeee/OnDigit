using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Extensions;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.EditionModel;

namespace OnDigit.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IDataService<Review> _reviewService;
        private readonly IDataService<Edition> _editionService;

        public ReviewService(IDataService<Review> reviewService, IDataService<Edition> editionService)
        {
            _reviewService = reviewService;
            _editionService = editionService;
        }

        public async Task<ICollection<Review>> GetReviewListsAsync(string editionId) =>
            await _reviewService.GetListBySpecAsync(new Reviews.ReviewEdition(editionId));

        public async Task AddReviewAsync(Review review, Edition edition)
        {
            await _reviewService.AddAsync(review);
            await _editionService.UpdateAsync(edition);
        }

        public async Task DeleteReviewAsync(string id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            review.ReviewNullChecking();
            await _reviewService.DeleteAsync(id);
        }
    }
}

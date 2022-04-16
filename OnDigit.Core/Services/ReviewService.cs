using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Extensions;
using OnDigit.Core.Interfaces.Services;

namespace OnDigit.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IDataService<Review> _reviewService;

        public ReviewService(IDataService<Review> reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<ICollection<Review>> GetReviewListsAsync(string editionId)
        {
            return await _reviewService.GetListBySpecAsync(new Reviews.ReviewEdition(editionId));
        }

        public async Task<Review> AddReviewAsync(string text, int stars, string userId)
        {
            Review review = new()
            {
                Text = text,
                Stars = stars,
                UserId = userId
            };
            return await _reviewService.AddAsync(review);
        }

        public async Task DeleteReviewAsync(string id, string userId)
        {
            var review = await _reviewService.GetByIdAsync(id);
            review.ReviewNullChecking();

            if(review.UserId != userId)
            {
                throw new Exceptions.NoPermissionException(id, "No permission to delete review");
            }

            await _reviewService.DeleteAsync(id);
        }
    }
}

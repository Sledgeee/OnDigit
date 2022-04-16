using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.ReviewModel;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IReviewService
    {
        Task<ICollection<Review>> GetReviewListsAsync(string editionId);
        Task<Review> AddReviewAsync(string text, int stars, string userId);
        Task DeleteReviewAsync(string id, string userId);
    }
}

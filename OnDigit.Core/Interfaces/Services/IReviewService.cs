using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.ReviewModel;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IReviewService
    {
        Task<ICollection<Review>> GetReviewListsAsync(string editionId);
        Task AddReviewAsync(Review review, Edition edition);
        Task DeleteReviewAsync(string id);
    }
}

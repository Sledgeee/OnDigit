using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.ReviewModel;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IReviewService
    {
        Task<ICollection<Review>> GetReviewsListAsync(string bookId);
        Task AddReviewAsync(Review review, Book book);
        Task DeleteReviewAsync(string id);
    }
}

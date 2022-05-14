using System.Collections.Generic;
using System.Threading.Tasks;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Extensions;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.BookModel;

namespace OnDigit.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IDataService<Review> _reviewService;
        private readonly IDataService<Book> _bookService;

        public ReviewService(IDataService<Review> reviewService, IDataService<Book> bookService)
        {
            _reviewService = reviewService;
            _bookService = bookService;
        }

        public async Task<ICollection<Review>> GetReviewsListAsync(string bookId) =>
            await _reviewService.GetListBySpecAsync(new Reviews.SearchReviewForBook(bookId));

        public async Task AddReviewAsync(Review review, Book book)
        {
            await _reviewService.AddAsync(review);
            await _bookService.UpdateAsync(book);
        }

        public async Task DeleteReviewAsync(string id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            review.ReviewNullChecking();
            await _reviewService.DeleteAsync(id);
        }
    }
}

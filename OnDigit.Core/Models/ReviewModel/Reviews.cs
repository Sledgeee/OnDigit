using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnDigit.Core.Models.ReviewModel
{
    public class Reviews
    {
        internal class SearchReviewForBook : Specification<Review>
        {
            public SearchReviewForBook(string bookId)
            {
                Query.Include(u => u.User).Where(e => e.BookId == bookId);
            }
        }
    }
}

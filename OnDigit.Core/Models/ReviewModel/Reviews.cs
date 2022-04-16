using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnDigit.Core.Models.ReviewModel
{
    public class Reviews
    {
        internal class ReviewEdition : Specification<Review>
        {
            public ReviewEdition(string editionId)
            {
                Query.Include(u => u.User).Where(e => e.EditionId == editionId);
            }
        }
    }
}

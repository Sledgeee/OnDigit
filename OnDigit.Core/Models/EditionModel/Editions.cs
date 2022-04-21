using Ardalis.Specification;
using System.Linq;

namespace OnDigit.Core.Models.EditionModel
{
    public class Editions
    {
        internal class EditionSearch : Specification<Edition>
        {
            public EditionSearch(string searchRow)
            {
                Query.Include(x => x.Reviews).Include(x=>x.UserFavorites).Where(x => x.Name.Contains(searchRow)).OrderBy(x => x.GenreId);
            }
        }

        internal class EditionLoad : Specification<Edition>
        {
            public EditionLoad()
            {
                Query.Include(x => x.Reviews).Include(x => x.UserFavorites).OrderBy(x => x.GenreId);
            }
        }
    }
}

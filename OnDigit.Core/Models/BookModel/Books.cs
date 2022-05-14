using Ardalis.Specification;
using System.Linq;

namespace OnDigit.Core.Models.BookModel
{
    public class Books
    {
        internal class BookSearch : Specification<Book>
        {
            public BookSearch(string searchRow)
            {
                Query.Include(x=>x.UserFavorites).Include(x => x.Reviews).Include(x=>x.Genre).Include(x => x.Package).Where(x => x.Name.Contains(searchRow)).OrderBy(x => x.DateCreated);
            }
        }

        internal class AllBooks : Specification<Book>
        {
            public AllBooks()
            {
                Query.Include(x => x.UserFavorites).Include(x => x.Reviews).Include(x => x.Genre).Include(x => x.Package).ThenInclude(x => x.Warehouse).OrderBy(x => x.DateCreated);
            }
        }
    }
}

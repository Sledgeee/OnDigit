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
                Query.Include(x => x.Reviews).ThenInclude(x => x.User).Include(x=>x.UserFavorites).Include(x => x.StockPackage).Where(x => x.Name.Contains(searchRow)).OrderBy(x => x.DateCreated);
            }
        }

        internal class AllBooks : Specification<Book>
        {
            public AllBooks()
            {
                Query.Include(x => x.Reviews).ThenInclude(x => x.User).Include(x => x.UserFavorites).Include(x => x.StockPackage).ThenInclude(x => x.Stock).OrderBy(x => x.DateCreated);
            }
        }
    }
}

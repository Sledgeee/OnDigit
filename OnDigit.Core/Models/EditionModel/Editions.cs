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
                Query.Where(x => x.Name.StartsWith(searchRow));
            }
        }
    }
}

using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnDigit.Core.Filters;

namespace OnDigit.Core.Models.EditionModel
{
    public class Editions
    {
        internal class FilterEdition : Specification<Edition>
        {
            public FilterEdition(Filter filter)
            {
                if (filter.IsGenreFilterEnabled && filter.IsDateFilterEnabled && filter.IsPriceFilterEnabled)
                {
                    Query
                        .Where(e => e.GenreId == filter.GenreId &&
                                    (e.DateCreated >= filter.DateCreatedMin && e.DateCreated <= filter.DateCreatedMax) &&
                                    (e.Price >= filter.PriceFilterMin && e.Price <= filter.PriceFilterMax));
                    return;
                }

                if (filter.IsGenreFilterEnabled && filter.IsDateFilterEnabled)
                {
                    Query
                        .Where(e => e.GenreId == filter.GenreId &&
                                    (e.DateCreated >= filter.DateCreatedMin && e.DateCreated <= filter.DateCreatedMax));
                    return;
                }

                if (filter.IsGenreFilterEnabled && filter.IsPriceFilterEnabled)
                {
                    Query
                       .Where(e => e.GenreId == filter.GenreId &&
                                  (e.Price >= filter.PriceFilterMin && e.Price <= filter.PriceFilterMax));
                    return;
                }

                if (filter.IsDateFilterEnabled && filter.IsPriceFilterEnabled)
                {
                    Query
                      .Where(e => (e.DateCreated >= filter.DateCreatedMin && e.DateCreated <= filter.DateCreatedMax) &&
                                  (e.Price >= filter.PriceFilterMin && e.Price <= filter.PriceFilterMax));
                    return;
                }
                
                if (filter.IsGenreFilterEnabled)
                {
                    Query
                        .Where(e => e.GenreId == filter.GenreId);
                    return;
                }

                if (filter.IsDateFilterEnabled)
                {
                    Query
                        .Where(e => (e.DateCreated >= filter.DateCreatedMin && e.DateCreated <= filter.DateCreatedMax));
                    return;
                }

                if (filter.IsPriceFilterEnabled)
                {
                    Query
                        .Where(e => (e.Price >= filter.PriceFilterMin && e.Price <= filter.PriceFilterMax));
                }
            }
        }
    }
}

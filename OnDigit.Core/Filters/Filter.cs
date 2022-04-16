using System;

namespace OnDigit.Core.Filters
{
    public class Filter
    {
        public bool IsGenreFilterEnabled { get; set; }
        public bool IsPriceFilterEnabled { get; set; }
        public bool IsDateFilterEnabled { get; set; }
        public int GenreId { get; set; }
        public decimal PriceFilterMin { get; set; }
        public decimal PriceFilterMax { get; set; }
        public DateTimeOffset DateCreatedMin { get; set; }
        public DateTimeOffset DateCreatedMax { get; set; }
    }
}

using System.Collections.Generic;

namespace OnDigit.Core.Models.StockModel
{
    public class Stock
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public ICollection<StockPackage> StockPackages { get; set; } = new List<StockPackage>();
    }
}
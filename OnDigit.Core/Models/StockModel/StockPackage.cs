using OnDigit.Core.Models.BookModel;
using System.Collections.Generic;

namespace OnDigit.Core.Models.StockModel
{
    public class StockPackage : EntityObject
    {
        public int Quantity { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
    }
}

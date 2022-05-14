using OnDigit.Core.Models.BookModel;
using System;

namespace OnDigit.Core.Models.SaleModel
{
    public sealed class Sale : EntityObject, IDisposable
    {
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateSaled { get; set; }

        public Book Book { get; set; }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            base.Dispose();
        }
    }
}

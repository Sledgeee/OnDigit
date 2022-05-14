using OnDigit.Core.Models.BookModel;
using System;

namespace OnDigit.Core.Models.WarehouseModel
{
    public sealed class Package : EntityObject, IDisposable
    {
        public int Quantity { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            base.Dispose();
        }
    }
}

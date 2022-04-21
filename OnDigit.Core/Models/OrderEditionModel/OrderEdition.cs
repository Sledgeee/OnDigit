using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.OrderModel;
using System;

namespace OnDigit.Core.Models.OrderEditionModel
{
    public class OrderEdition : IDisposable
    {
        public int OrderNumber { get; set; }
        public Order Order { get; set; }
        public string EditionId { get; set; }
        public Edition Edition { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Interfaces;

namespace OnDigit.Core.Models.OrderEditionModel
{
    public class OrderEdition : IBaseEntity
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string EditionId { get; set; }
        public Edition Edition { get; set; }
    }
}

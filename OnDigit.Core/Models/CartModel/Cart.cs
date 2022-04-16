using System.Collections.Generic;
using OnDigit.Core.Interfaces;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.CartModel
{
    public class Cart : EntityObject, IBaseEntity
    {
        public decimal TotalPrice { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Edition> Editions { get; set; } = new List<Edition>();
    }
}

using OnDigit.Core.Models.EditionModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnDigit.Core.Models.CartModel
{
    public class Cart : IDisposable
    {
        public Cart()
        {
            Editions = new List<Edition>();
        }

        public decimal TotalPrice { get; set; }
        public ICollection<Edition> Editions { get; set; }

        public void AddEdition(Edition edition)
        {
            Editions.Add(edition);
            TotalPrice = Editions.Sum(x => x.Price);
        }

        public void RemoveEdition(Edition edition)
        {
            Editions.Remove(edition);
            TotalPrice = Editions.Sum(x => x.Price);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

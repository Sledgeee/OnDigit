using System;
using System.Collections.Generic;

namespace OnDigit.Core.Models.WarehouseModel
{
    public sealed class Warehouse : IDisposable
    {
        public Warehouse()
        {
            Packages = new List<Package>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public ICollection<Package> Packages { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
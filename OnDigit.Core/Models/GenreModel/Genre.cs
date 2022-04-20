using System.Collections.Generic;
using OnDigit.Core.Models.EditionModel;
using System;

namespace OnDigit.Core.Models.GenreModel
{
    public class Genre : IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Edition> Editions { get; set; } = new List<Edition>();

        public void Dispose()
        {
            GC.Collect();
        }
    }
}

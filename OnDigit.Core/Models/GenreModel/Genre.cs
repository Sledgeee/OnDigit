using System.Collections.Generic;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Interfaces;

namespace OnDigit.Core.Models.GenreModel
{
    public class Genre : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Edition> Editions { get; set; } = new List<Edition>();
    }
}

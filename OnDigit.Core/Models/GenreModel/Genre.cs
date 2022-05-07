using System.Collections.Generic;
using OnDigit.Core.Models.BookModel;
using System;

namespace OnDigit.Core.Models.GenreModel
{
    public class Genre : IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

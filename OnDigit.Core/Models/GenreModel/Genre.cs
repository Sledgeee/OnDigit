using System.Collections.Generic;
using OnDigit.Core.Models.BookModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnDigit.Core.Models.GenreModel
{
    public sealed class Genre : IDisposable
    {
        public Genre()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}

using OnDigit.Core.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnDigit.Core.Models.CartModel
{
    public sealed class Cart : IDisposable
    {
        public Cart()
        {
            Books = new Dictionary<Book, int>();
        }

        public decimal TotalAmount { get; set; }
        public int TotalBooksQuantity { get; set; }
        public Dictionary<Book, int> Books { get; set; }

        public void AddBook(Book book, int quantity)
        {
            Books.Add(book, quantity);
            TotalAmount = Books.Sum(x => x.Key.Price * x.Value);
            TotalBooksQuantity = Books.Sum(x => x.Value);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
            TotalAmount = Books.Sum(x => x.Key.Price * x.Value);
            TotalBooksQuantity = Books.Sum(x => x.Value);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}

using OnDigit.Core.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnDigit.Core.Models.CartModel
{
    public class Cart : IDisposable
    {
        public Cart()
        {
            Books = new Dictionary<Book, int>();
        }

        public decimal TotalPrice { get; set; }
        public Dictionary<Book, int> Books { get; set; }

        public void AddBook(Book book, int quantity)
        {
            Books.Add(book, quantity);
            TotalPrice = Books.Sum(x => x.Key.Price * x.Value);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
            TotalPrice = Books.Sum(x => x.Key.Price * x.Value);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

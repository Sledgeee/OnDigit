using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.ReviewModel;
using System.Collections.Generic;
using OnDigit.Core.Models.OrderBookModel;
using System;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.StockModel;

namespace OnDigit.Core.Models.BookModel
{
    public class Book : EntityObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public decimal Price { get; set; }
        public string ImageUri { get; set; }
        public DateTime DateCreated { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; }
        public string StockPackageId { get; set; }
        public StockPackage StockPackage { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public List<OrdersBooks> OrdersBooks { get; set; } = new List<OrdersBooks>();
        public List<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            base.Dispose();
        }

        public override bool Equals(object obj)
        {
            if ((obj is null) || this.GetType().Equals(obj.GetType()) is false)
            {
                return false;
            }
            else
            {
                Book e = obj as Book;

                return
                    (Name == e.Name) &&
                    (Description == e.Description) &&
                    (Rating == e.Rating) &&
                    (Price == e.Price) &&
                    (DateCreated == e.DateCreated) &&
                    (GenreId == e.GenreId) &&
                    (ImageUri == e.ImageUri);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description, Rating, Price, DateCreated, GenreId, ImageUri);
        }
    }
}

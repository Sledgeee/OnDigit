using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.ReviewModel;
using System.Collections.Generic;
using OnDigit.Core.Models.OrderBookModel;
using System;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.WarehouseModel;
using OnDigit.Core.Models.SaleModel;

namespace OnDigit.Core.Models.BookModel
{
    public sealed class Book : EntityObject
    {
        public Book()
        {
            Orders = new List<Order>();
            Reviews = new List<Review>();
            Sales = new List<Sale>();
            OrdersBooks = new List<OrdersBooks>();
            UserFavorites = new List<UserFavorite>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; } // in %
        public string ImageUri { get; set; }
        public DateTime DateCreated { get; set; }
        public int GenreId { get; set; }
        public bool IsAvailable { get; set; }

        public Genre Genre { get; set; }
        public Package Package { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public List<OrdersBooks> OrdersBooks { get; set; }
        public List<UserFavorite> UserFavorites { get; set; }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
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

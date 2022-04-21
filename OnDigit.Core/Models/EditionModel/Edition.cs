using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.ReviewModel;
using System.Collections.Generic;
using OnDigit.Core.Models.OrderEditionModel;
using System;
using OnDigit.Core.Models.UserFavoriteModel;

namespace OnDigit.Core.Models.EditionModel
{
    public class Edition : EntityObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public int RatingCount { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public string ImageUri { get; set; }
        public DateTime DateCreated { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public List<OrderEdition> OrdersEditions { get; set; } = new List<OrderEdition>();
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
                Edition e = obj as Edition;

                return
                    (Name == e.Name) &&
                    (Description == e.Description) &&
                    (Rating == e.Rating) &&
                    (RatingCount == e.RatingCount) &&
                    (Price == e.Price) &&
                    (DateCreated == e.DateCreated) &&
                    (GenreId == e.GenreId) &&
                    (ImageUri == e.ImageUri);
            }
        }
    }
}

using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.ReviewModel;
using System.Collections.Generic;
using OnDigit.Core.Interfaces;
using OnDigit.Core.Models.BasketModel;
using OnDigit.Core.Models.OrderEditionModel;
using System;
using OnDigit.Core.Models.UserFavoriteModel;

namespace OnDigit.Core.Models.EditionModel
{
    public class Edition : EntityObject, IBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public int RatingCount { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public string ImageUri { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Basket> Baskets { get; set; } = new List<Basket>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public List<OrderEdition> OrdersEditions { get; set; } = new List<OrderEdition>();
        public List<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();

        public override void Dispose()
        {
            GC.Collect();
            base.Dispose();
        }
    }
}

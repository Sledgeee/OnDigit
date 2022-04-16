using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.ReviewModel;
using System.Collections.Generic;
using OnDigit.Core.Interfaces;
using OnDigit.Core.Models.CartModel;
using OnDigit.Core.Models.OrderEditionModel;
using System;
using OnDigit.Core.Models.UserFavoritesModel;

namespace OnDigit.Core.Models.EditionModel
{
    public class Edition : EntityObject, IBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float AverageStars { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public string ImageLink { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Cart> Baskets { get; set; } = new List<Cart>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public List<OrderEdition> OrdersEditions { get; set; } = new List<OrderEdition>();
        public List<UserFavorites> UserFavorites { get; set; } = new List<UserFavorites>();
    }
}

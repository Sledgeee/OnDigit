using System;
using System.Collections.Generic;
using OnDigit.Core.Models.CartModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.ResetTokenModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.UserLoginHistoryModel;
using OnDigit.Core.Interfaces;
using OnDigit.Core.Models.RoleModel;
using OnDigit.Core.Models.UserFavoritesModel;

namespace OnDigit.Core.Models.UserModel
{
    public class User : EntityObject, IBaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public bool SessionCreated { get; set; }
        public int RoleId { get; set; }
        public Session Session { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Role Role { get; set; }
        public ICollection<UserLoginHistory> UserLogins { get; set; } = new List<UserLoginHistory>();
        public ICollection<ResetToken> ResetTokens { get; set; } = new List<ResetToken>();
        public ICollection<Cart> Baskets { get; set; } = new List<Cart>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public List<UserFavorites> UserFavorites { get; set; } = new List<UserFavorites>();
    }
}

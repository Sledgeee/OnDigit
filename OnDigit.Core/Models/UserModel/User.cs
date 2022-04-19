using System;
using System.Collections.Generic;
using OnDigit.Core.Models.BasketModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.ResetTokenModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.UserLoginHistoryModel;
using OnDigit.Core.Interfaces;
using OnDigit.Core.Models.RoleModel;
using OnDigit.Core.Models.UserFavoriteModel;

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
        public int RoleId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Role Role { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
        public ICollection<UserLoginHistory> UserLogins { get; set; } = new List<UserLoginHistory>();
        public ICollection<ResetToken> ResetTokens { get; set; } = new List<ResetToken>();
        public ICollection<Basket> Baskets { get; set; } = new List<Basket>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public List<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();

        public override void Dispose()
        {
            GC.Collect();
            base.Dispose();
        }
    }
}

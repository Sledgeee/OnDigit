using System;
using System.Collections.Generic;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.ResetTokenModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.UserLoginHistoryModel;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.PaymentModel;

namespace OnDigit.Core.Models.UserModel
{
    public sealed class User : EntityObject
    {
        public User()
        {
            Orders = new List<Order>();
            Reviews  = new List<Review>();
            Payments = new List<Payment>();
            UserFavorites = new List<UserFavorite>();
            UserLogins = new List<UserLoginHistory>();
            Sessions = new List<Session>();
        }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreated { get; set; }
        public ResetToken ResetToken { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<UserLoginHistory> UserLogins { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public List<UserFavorite> UserFavorites { get; set; }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            base.Dispose();
        }
    }
}

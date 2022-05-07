using System;
using System.Collections.Generic;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.ResetTokenModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.UserLoginHistoryModel;
using OnDigit.Core.Models.UserFavoriteModel;

namespace OnDigit.Core.Models.UserModel
{
    public class User : EntityObject
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreated { get; set; }
        public ResetToken ResetToken { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
        public ICollection<UserLoginHistory> UserLogins { get; set; } = new List<UserLoginHistory>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public List<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}

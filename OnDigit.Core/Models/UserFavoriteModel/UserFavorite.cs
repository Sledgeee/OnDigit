using OnDigit.Core.Interfaces;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.UserModel;
using System;

namespace OnDigit.Core.Models.UserFavoriteModel
{
    public class UserFavorite : IDisposable
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string EditionId { get; set; }
        public Edition Edition { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override bool Equals(object obj)
        {
            if ((obj is null) || this.GetType().Equals(obj.GetType()) is false)
            {
                return false;
            }
            else {
                UserFavorite uf = obj as UserFavorite;
                return (UserId == uf.UserId) && (User == uf.User) && (EditionId == uf.EditionId) && (Edition == uf.Edition);
            }
        }
    }
}

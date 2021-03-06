using OnDigit.Core.Interfaces;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.UserModel;
using System;

namespace OnDigit.Core.Models.UserFavoriteModel
{
    public sealed class UserFavorite : IDisposable
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        public override bool Equals(object obj)
        {
            if ((obj is null) || this.GetType().Equals(obj.GetType()) is false)
            {
                return false;
            }
            else {
                UserFavorite uf = obj as UserFavorite;
                return (UserId == uf.UserId) && (BookId == uf.BookId);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId, BookId);
        }
    }
}

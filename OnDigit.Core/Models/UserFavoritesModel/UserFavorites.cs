using OnDigit.Core.Interfaces;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.UserModel;
using System;

namespace OnDigit.Core.Models.UserFavoritesModel
{
    public class UserFavorites : IBaseEntity, IDisposable
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string EditionId { get; set; }
        public Edition Edition { get; set; }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}

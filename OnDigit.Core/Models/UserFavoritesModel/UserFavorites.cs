using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.UserFavoritesModel
{
    public class UserFavorites
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string EditionId { get; set; }
        public Edition Edition { get; set; }
    }
}

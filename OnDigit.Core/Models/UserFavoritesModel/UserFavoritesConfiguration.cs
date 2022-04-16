using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.UserFavoritesModel
{
    public class UserFavoritesConfiguration : IEntityTypeConfiguration<UserFavorites>
    {
        public void Configure(EntityTypeBuilder<UserFavorites> builder)
        {
            builder.HasKey(x => new { x.UserId, x.EditionId });

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.EditionId).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.UserFavorites).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Edition).WithMany(x => x.UserFavorites).HasForeignKey(x => x.EditionId);
        }
    }
}

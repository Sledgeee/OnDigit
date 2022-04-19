using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.UserFavoriteModel
{
    public class UserFavoriteConfiguration : IEntityTypeConfiguration<UserFavorite>
    {
        public void Configure(EntityTypeBuilder<UserFavorite> builder)
        {
            builder.HasKey(x => new { x.UserId, x.EditionId });

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.EditionId).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.UserFavorites).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Edition).WithMany(x => x.UserFavorites).HasForeignKey(x => x.EditionId);
        }
    }
}

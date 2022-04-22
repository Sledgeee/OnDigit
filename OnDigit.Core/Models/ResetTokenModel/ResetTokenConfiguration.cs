using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.ResetTokenModel
{
    public class ResetTokenConfiguration : IEntityTypeConfiguration<ResetToken>
    {
        public void Configure(EntityTypeBuilder<ResetToken> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.UserId)
                .IsRequired();

            builder
                .Property(t => t.Token)
                .IsRequired();

            builder
                .HasOne(u => u.User)
                .WithOne(t => t.ResetToken)
                .HasForeignKey<ResetToken>(t => t.UserId);
        }
    }
}

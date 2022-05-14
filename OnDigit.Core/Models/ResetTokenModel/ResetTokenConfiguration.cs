using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.ResetTokenModel
{
    public class ResetTokenConfiguration : IEntityTypeConfiguration<ResetToken>
    {
        public void Configure(EntityTypeBuilder<ResetToken> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.UserId)
                .HasMaxLength(450)
                .IsRequired();

            builder
                .Property(t => t.Token)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(u => u.User)
                .WithOne(t => t.ResetToken)
                .HasForeignKey<ResetToken>(t => t.UserId);
        }
    }
}

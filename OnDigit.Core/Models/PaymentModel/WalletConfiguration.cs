using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.PaymentModel
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DateAdded).HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.CardNumber).HasMaxLength(20);

            builder.Property(x => x.UserId).HasMaxLength(450);

            builder.Property(x => x.CVV).HasMaxLength(5);

            builder.Property(x => x.ExpiryDate).HasMaxLength(10);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.BasketModel
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(b => b.UserId)
                .IsRequired();

            builder
                .HasMany(e => e.Editions)
                .WithMany(b => b.Baskets);
        }
    }
}

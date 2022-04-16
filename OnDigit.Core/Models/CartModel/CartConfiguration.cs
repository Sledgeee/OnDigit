using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.CartModel
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
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

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.OrderBookModel
{
    public class OrderBookConfiguration : IEntityTypeConfiguration<OrdersBooks>
    {
        public void Configure(EntityTypeBuilder<OrdersBooks> builder)
        {
            builder.HasKey(k => new { k.OrderNumber, k.BookId });

            builder.Property(x => x.Quantity).HasDefaultValue(1);

            builder.Property(x => x.BookId).HasMaxLength(450);

            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
        }
    }
}

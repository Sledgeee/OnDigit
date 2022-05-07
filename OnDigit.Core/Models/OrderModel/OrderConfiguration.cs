using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDigit.Core.Models.OrderBookModel;
using System;
using System.Linq;

namespace OnDigit.Core.Models.OrderModel
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Number);

            builder
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .ValueGeneratedOnAddOrUpdate();

            builder
                .Property(o => o.Status)
                .HasDefaultValue(Order.EnumOrderStatusToString(OrderStatus.Processing));

            builder
                .Property(o => o.DateOrder)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder
                .HasMany(e => e.Books)
                .WithMany(o => o.Orders)
                .UsingEntity<OrdersBooks>(
                j => j
                    .HasOne(oe => oe.Book)
                    .WithMany(e => e.OrdersBooks)
                    .HasForeignKey(oe => oe.BookId),
                j => j
                    .HasOne(oe => oe.Order)
                    .WithMany(o => o.OrdersBooks)
                    .HasForeignKey(oe => oe.OrderNumber));
        }
    }
}

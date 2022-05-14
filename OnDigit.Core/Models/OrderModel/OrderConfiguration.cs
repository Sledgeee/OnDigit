using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDigit.Core.Models.OrderBookModel;
using OnDigit.Core.Models.PaymentModel;
using System;
using System.Linq;

namespace OnDigit.Core.Models.OrderModel
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Number);

            builder.Property(x => x.ContactPhone).HasMaxLength(250);

            builder.Property(x => x.Fullname).HasMaxLength(150);

            builder.Property(x => x.Email).HasMaxLength(250);

            builder.Property(x => x.DeliveryAddress).HasMaxLength(500);

            builder.Property(x => x.UserId).HasMaxLength(450);

            builder
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(o => o.OrderStatus)
                .HasDefaultValue(OrderStatus.Payment);

            builder
                .Property(o => o.DateOrder)
                .HasColumnType("TIMESTAMP")
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

            builder
                .HasOne(p => p.Payment)
                .WithOne(o => o.Order)
                .HasForeignKey<Payment>(p => p.OrderNumber);
        }
    }
}

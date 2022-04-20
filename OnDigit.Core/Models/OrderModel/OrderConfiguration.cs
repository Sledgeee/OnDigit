using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDigit.Core.Models.OrderEditionModel;
using System;

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
                .IsRequired();

            builder
                .Property(o => o.DateOrder)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .HasMany(e => e.Editions)
                .WithMany(o => o.Orders)
                .UsingEntity<OrderEdition>(
                j => j
                    .HasOne(oe => oe.Edition)
                    .WithMany(e => e.OrdersEditions)
                    .HasForeignKey(oe => oe.EditionId)
                    .OnDelete(DeleteBehavior.ClientCascade),
                j => j
                    .HasOne(oe => oe.Order)
                    .WithMany(o => o.OrdersEditions)
                    .HasForeignKey(oe => oe.OrderNumber)
                    .OnDelete(DeleteBehavior.ClientCascade));
        }
    }
}

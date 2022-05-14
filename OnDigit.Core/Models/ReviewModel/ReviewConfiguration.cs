using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace OnDigit.Core.Models.ReviewModel
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .Property(r => r.Text)
                .HasMaxLength(8000)
                .IsRequired();

            builder
                .Property(r => r.Stars)
                .IsRequired();

            builder
                .Property(r => r.DateCreated)
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder
                .Property(r => r.UserId)
                .HasMaxLength(450)
                .IsRequired();

            builder
                .Property(r => r.BookId)
                .HasMaxLength(450)
                .IsRequired();
        }
    }
}

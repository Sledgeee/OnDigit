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
                .IsRequired();

            builder
                .Property(r => r.Stars)
                .IsRequired();

            builder
                .Property(r => r.DateCreated)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder
                .Property(r => r.UserId)
                .IsRequired();

            builder
                .Property(r => r.EditionId)
                .IsRequired();
        }
    }
}

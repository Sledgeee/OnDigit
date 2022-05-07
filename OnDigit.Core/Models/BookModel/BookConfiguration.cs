using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace OnDigit.Core.Models.BookModel
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder
                .Property(e => e.Description)
                .IsRequired();

            builder
                .Property(e => e.Rating)
                .HasDefaultValue(0f)
                .IsRequired();

            builder
                .Property(e => e.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(e => e.IsAvailable)
                .HasDefaultValue(false);

            builder
                .Property(e => e.GenreId)
                .IsRequired();

            builder
                .Property(e => e.DateCreated)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder
                .HasMany(r => r.Reviews)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

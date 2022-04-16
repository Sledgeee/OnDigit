using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.EditionModel
{
    public class EditionConfiguration : IEntityTypeConfiguration<Edition>
    {
        public void Configure(EntityTypeBuilder<Edition> builder)
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
                .Property(e => e.AverageStars)
                .HasDefaultValue(0f)
                .IsRequired();

            builder
                .Property(e => e.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(e => e.GenreId)
                .IsRequired();

            builder
                .Property(e => e.DateCreated)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder
                .HasMany(r => r.Reviews)
                .WithOne(e => e.Edition)
                .HasForeignKey(e => e.EditionId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

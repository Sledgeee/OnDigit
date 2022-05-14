using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.GenreModel
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(x => x.Name).HasMaxLength(500);

            builder
                .HasMany(e => e.Books)
                .WithOne(g => g.Genre)
                .HasForeignKey(e => e.GenreId);
        }
    }
}

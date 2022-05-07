using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.StockModel
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.City).IsRequired();

            builder.Property(x => x.Street).IsRequired();

            builder.HasMany(x => x.StockPackages).WithOne(x => x.Stock).HasForeignKey(x => x.StockId);
        }
    }
}

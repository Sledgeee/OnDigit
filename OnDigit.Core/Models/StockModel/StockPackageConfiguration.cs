using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnDigit.Core.Models.BookModel;

namespace OnDigit.Core.Models.StockModel
{
    public class StockPackageConfiguration : IEntityTypeConfiguration<StockPackage>
    {
        public void Configure(EntityTypeBuilder<StockPackage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StockId).IsRequired();

            builder.Property(x => x.BookId).IsRequired();

            builder.Property(x => x.Quantity).HasDefaultValue(0);

            builder.HasOne(x => x.Book).WithOne(x => x.StockPackage).HasForeignKey<StockPackage>(x => x.BookId);
        }
    }
}

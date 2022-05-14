using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.WarehouseModel
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.WarehouseId).IsRequired();

            builder.Property(x => x.BookId).HasMaxLength(450).IsRequired();

            builder.Property(x => x.Quantity).HasDefaultValue(0);

            builder.HasOne(x => x.Book).WithOne(x => x.Package).HasForeignKey<Package>(x => x.BookId);
        }
    }
}

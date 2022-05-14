using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.WarehouseModel
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.City).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Street).HasMaxLength(200).IsRequired();

            builder.HasMany(x => x.Packages).WithOne(x => x.Warehouse).HasForeignKey(x => x.WarehouseId);
        }
    }
}

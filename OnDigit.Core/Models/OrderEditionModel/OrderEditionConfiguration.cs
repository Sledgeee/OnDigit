using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.OrderEditionModel
{
    public class OrderEditionConfiguration : IEntityTypeConfiguration<OrderEdition>
    {
        public void Configure(EntityTypeBuilder<OrderEdition> builder)
        {
            builder.HasKey(k => new { k.OrderNumber, k.EditionId });
        }
    }
}

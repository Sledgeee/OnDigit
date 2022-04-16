using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.SessionModel
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .Property(s => s.MACHINE_KEY)
                .IsRequired();

            builder
                .Property(s => s.StartDate)
                .IsRequired();

            builder
                .Property(s => s.EndDate)
                .IsRequired();
        }
    }
}

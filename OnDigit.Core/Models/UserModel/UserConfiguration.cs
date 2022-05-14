using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnDigit.Core.Models.UserModel
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email).HasMaxLength(256).IsRequired();

            builder.Property(upd => upd.Name).IsRequired().HasMaxLength(100);

            builder.Property(upd => upd.Surname).IsRequired().HasMaxLength(100);

            builder.Property(upd => upd.Gender).HasMaxLength(10).IsRequired();

            builder.Property(u => u.PasswordHash).HasMaxLength(450).IsRequired();

            builder.Property(u => u.DateCreated).HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder
                .HasMany(o => o.Orders)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            builder
                .HasMany(r => r.Reviews)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            builder
                .HasMany(ulh => ulh.UserLogins)
                .WithOne(u => u.User)
                .HasForeignKey(ulh => ulh.UserId);

            builder
                .HasMany(s => s.Sessions)
                .WithOne(u => u.User)
                .HasForeignKey(s => s.UserId);

            builder
                .HasMany(p => p.Payments)
                .WithOne(u => u.User)
                .HasForeignKey(p => p.UserId);

            builder
                .HasMany(p => p.Wallets)
                .WithOne(u => u.User)
                .HasForeignKey(p => p.UserId);
        }
    }
}

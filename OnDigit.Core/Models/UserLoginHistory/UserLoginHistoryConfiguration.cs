using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace OnDigit.Core.Models.UserLoginHistoryModel
{
    public class UserLoginHistoryConfiguration : IEntityTypeConfiguration<UserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
        {
            builder.HasKey(ulh => ulh.Id);

            builder
                .Property(ulh => ulh.UserId)
                .HasMaxLength(450)
                .IsRequired();

            builder
                .Property(ulh => ulh.DateLogined)
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();
        }
    }
}

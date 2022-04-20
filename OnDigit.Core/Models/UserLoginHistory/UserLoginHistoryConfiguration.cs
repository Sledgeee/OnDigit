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
                .IsRequired();

            builder
                .Property(ulh => ulh.DateLogined)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();
        }
    }
}

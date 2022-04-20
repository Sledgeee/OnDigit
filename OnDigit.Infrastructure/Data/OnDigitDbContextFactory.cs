using Microsoft.EntityFrameworkCore;
using System;

namespace OnDigit.Infrastructure.Data
{
    public class OnDigitDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public OnDigitDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public OnDigitDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<OnDigitDbContext> options = new();

            _configureDbContext(options);

            return new OnDigitDbContext(options.Options);
        }
    }
}

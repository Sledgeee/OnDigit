using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.OrderBookModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Models.UserLoginHistoryModel;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.StockModel;

namespace OnDigit.Infrastructure.Data
{
    public class OnDigitDbContext : DbContext
    {
        public OnDigitDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderBookConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new UserFavoriteConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new StockPackageConfiguration());
            modelBuilder.Seed();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersBooks> OrdersBooks { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockPackage> StockPackages { get; set; }
        public DbSet<UserLoginHistory> UsersLoginHistory { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
    }
}

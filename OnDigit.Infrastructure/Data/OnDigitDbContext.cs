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
using OnDigit.Core.Models.WarehouseModel;
using OnDigit.Core.Models.PaymentModel;
using OnDigit.Core.Models.ResetTokenModel;
using OnDigit.Core.Models.SaleModel;

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
            modelBuilder.ApplyConfiguration(new ResetTokenConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderBookConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new UserFavoriteConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new WalletConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.Seed();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersBooks> OrdersBooks { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ResetToken> ResetTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserLoginHistory> UsersLoginHistory { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Models.CartModel;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.OrderEditionModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Models.UserLoginHistoryModel;
using OnDigit.Core.Models.RoleModel;
using OnDigit.Core.Models.UserFavoriteModel;

namespace OnDigit.Infrastructure.Data
{
    public class OnDigitDbContext : DbContext
    {
        public OnDigitDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new EditionConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEditionConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new UserFavoriteConfiguration());
            modelBuilder.Seed();
        }

        public DbSet<Cart> Baskets { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderEdition> OrderEditions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<UserLoginHistory> UsersLoginHistory { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
    }
}

using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Services;
using OnDigit.Infrastructure.Data;
using OnDigit.Infrastructure.Services;
using System.Windows;

namespace OnDigit.AdminPanel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App() => _host = CreateHostBuilder().Build();

        public static IHostBuilder CreateHostBuilder(string[]? args = null) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                    c.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                string connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                void configureDbContext(DbContextOptionsBuilder o) => o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                    services.AddDbContext<OnDigitDbContext>(configureDbContext);
                    services.AddSingleton(new OnDigitDbContextFactory(configureDbContext));
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<IPasswordHasher, PasswordHasher>();
                    services.AddSingleton<IAuthenticationService, AuthenticationService>();
                    services.AddSingleton<IReviewService, ReviewService>();
                    services.AddSingleton<IDataService<User>, UserDataService>();
                    services.AddSingleton<IUserService, UserDataService>();
                    services.AddSingleton<IShopService, ShopService>();
                    services.AddSingleton<IOrderService, OrderDataService>();
                    services.AddSingleton<IDashboardService, AdminDataService>();
                    services.AddSingleton<IWarehouseService, AdminDataService>();
                    services.AddSingleton<IAdminService, AdminService>();
                    services.AddSingleton(typeof(IDataService<>), typeof(GenericDataService<>));
                });

        protected override void OnStartup(StartupEventArgs e)
        {
            OnDigitDbContextFactory contextFactory = _host.Services.GetRequiredService<OnDigitDbContextFactory>();
            using (OnDigitDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }

            MainWindow window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}

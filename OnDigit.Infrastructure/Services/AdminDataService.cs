using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Infrastructure.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.WarehouseModel;
using OnDigit.Core.Models.PaymentModel;
using OnDigit.Core.Models.OrderBookModel;
using OnDigit.Core.Models.SaleModel;

namespace OnDigit.Infrastructure.Services
{
    public class AdminDataService : IDashboardService, IWarehouseService
    {
        private readonly OnDigitDbContextFactory _contextFactory;

        public AdminDataService(OnDigitDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<List<Sale>> GetTop5Books(DateTime startDate, DateTime endDate)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();

            return Task.FromResult(context.Sales
                .Where(x => x.DateSaled >= startDate && x.DateSaled <= endDate)
                .OrderByDescending(x => x.Quantity)
                .Include(x => x.Book)
                .Take(5)
                .ToList()); 
        }

        public Task<int[]> GetTotalCounters()
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();

            int[] counters = new int[4];

            counters[0] = context.Users.Count();
            counters[1] = context.Books.Count();
            counters[2] = context.Orders.Count();
            counters[3] = context.Reviews.Count();

            return Task.FromResult(counters);
        }

        public Task<List<KeyValuePair<DateTime, decimal>>> GetRevenueAnalys(DateTime startDate, DateTime endDate)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();

            var result = context.Orders.Where(x => x.DateOrder >= startDate && x.DateOrder <= endDate && x.OrderStatus == OrderStatus.Completed)
                                       .GroupBy(x => x.DateOrder)
                                       .Select(g => new
                                       {
                                           Date = g.Key,
                                           TotalAmount = g.Sum(x => x.TotalAmount),
                                       })
                                       .OrderBy(x => x.Date);

            var resultTable = new List<KeyValuePair<DateTime, decimal>>();

            decimal revenue = 0;

            foreach (var kvp in result)
            {
                revenue += kvp.TotalAmount;
                resultTable.Add(new KeyValuePair<DateTime, decimal>(kvp.Date, revenue));
            }

            return Task.FromResult(resultTable);
        }

        public Task<List<Order>> GetRecentOrders(DateTime startDate, DateTime endDate)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();

            return Task.FromResult(context.Orders
                .Where(x => x.DateOrder >= startDate && x.DateOrder <= endDate)
                .Include(x => x.User)
                .OrderByDescending(x => x.Number)
                .ToList());
        }

        public async Task<ICollection<Warehouse>> GetAllWarehousesAsync()
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            return await context.Warehouses.Include(x => x.Packages).ThenInclude(x => x.Book).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<ICollection<Payment>> GetAllPaymentsAsync()
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            return await context.Payments.Include(x => x.User).ToListAsync();
        }

        public async Task<Order> ChangeOrderStatus(int orderNumber, OrderStatus status)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();
            Order order = context.Orders.First(x => x.Number == orderNumber);
            order.OrderStatus = status;
            context.Update(order);
            await context.SaveChangesAsync();
            return order;
        }
    }
}

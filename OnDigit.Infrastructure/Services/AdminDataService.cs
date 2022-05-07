using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Infrastructure.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.StockModel;

namespace OnDigit.Infrastructure.Services
{
    public class AdminDataService : IDashboardService, IStockService
    {
        private readonly OnDigitDbContextFactory _contextFactory;

        public AdminDataService(OnDigitDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<List<KeyValuePair<string, int>>> GetTop5Books(DateTime startDate, DateTime endDate)
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();

            var query = context.OrdersBooks.CreateDbCommand();

            query.Connection = context.Database.GetDbConnection();

            query.Connection.Open();

            query.CommandText = @"SELECT TOP 5 E.Name, SUM(1) as Q
                              FROM OrdersBooks
                              INNER JOIN Books E ON E.Id = OrdersBooks.BookId
                              INNER JOIN Orders O ON O.Number = OrdersBooks.OrderNumber
                              WHERE O.DateOrder BETWEEN @fromDate AND @toDate
                              GROUP BY E.Name
                              ORDER BY Q DESC";

            query.Parameters.Add(new SqlParameter("@fromDate", System.Data.SqlDbType.DateTime) { Value = startDate });
            query.Parameters.Add(new SqlParameter("@toDate", System.Data.SqlDbType.DateTime) { Value = endDate });

            var reader = query.ExecuteReader();

            var pairs = new List<KeyValuePair<string, int>>();

            while (reader.Read())
            {
                pairs.Add(new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
            }

            reader.Close();

            return Task.FromResult(pairs);
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

            var result = context.Orders.Where(x => x.DateOrder >= startDate && x.DateOrder <= endDate && x.Status == "Completed")
                                              .GroupBy(x => x.DateOrder)
                                              .Select(g => new
                                              {
                                                  Date = g.Key,
                                                  TotalAmount = g.Sum(x => x.TotalPrice),
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

            // FOR LABORATORY SHOW JOIN PRINCIPE WORKING
            var orders = (from o in context.Orders
                         join u in context.Users on o.UserId equals u.Id
                         where o.DateOrder >= startDate && o.DateOrder <= endDate
                         orderby o.Number descending
                         select new Order
                         {
                             Number = o.Number,
                             User = new Core.Models.UserModel.User()
                             {
                                 Name = u.Name,
                                 Surname = u.Surname
                             },
                             TotalPrice = o.TotalPrice,
                             DateOrder = o.DateOrder,
                             Status = o.Status
                         }).ToList();

            return Task.FromResult(orders);
            //return Task.FromResult(context.Orders.Where(x => x.DateOrder >= startDate && x.DateOrder <= endDate).Include(x => x.User).OrderByDescending(x => x.Number).ToList());
        }

        public async Task<ICollection<Stock>> GetAllStocksAsync()
        {
            using OnDigitDbContext context = _contextFactory.CreateDbContext();

            return await context.Stocks.Include(x => x.StockPackages).ThenInclude(x => x.Book).OrderByDescending(x => x.Id).ToListAsync();
        }
    }
}

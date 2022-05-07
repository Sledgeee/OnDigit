using OnDigit.Core.Models.OrderBookModel;
using OnDigit.Core.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IDashboardService
    {
        Task<List<KeyValuePair<string, int>>> GetTop5Books(DateTime startDate, DateTime endDate);
        Task<int[]> GetTotalCounters();
        Task<List<KeyValuePair<DateTime, decimal>>> GetRevenueAnalys(DateTime startDate, DateTime endDate);
        Task<List<Order>> GetRecentOrders(DateTime startDate, DateTime endDate);
    }
}

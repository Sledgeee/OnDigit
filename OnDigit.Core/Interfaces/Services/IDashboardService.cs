using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.SaleModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnDigit.Core.Interfaces.Services
{
    public interface IDashboardService
    {
        Task<List<Sale>> GetTop5Books(DateTime startDate, DateTime endDate);
        Task<int[]> GetTotalCounters();
        Task<List<KeyValuePair<DateTime, decimal>>> GetRevenueAnalys(DateTime startDate, DateTime endDate);
        Task<List<Order>> GetRecentOrders(DateTime startDate, DateTime endDate);
    }
}

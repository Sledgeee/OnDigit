using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.SaleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace OnDigit.AdminPanel.Dashboard
{
    public struct RevenueByDate
    {
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class Dashboard
    {
        private IDashboardService _dashboardService;
        private DateTime _startDate;
        private DateTime _endDate;

        public Dashboard(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public int NumUsers { get; private set; }
        public int NumBooks { get; private set; }
        public int NumOrders { get; private set; }
        public int NumReviews { get; private set; }
        public List<Sale> TopBooksList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public List<Order> RecentOrdersList { get; private set; }

        public Task LoadData(DateTime startDate, DateTime endDate)
        {
            this._startDate = startDate;
            this._endDate = endDate;

            TopBooksList = _dashboardService.GetTop5Books(_startDate, _endDate).Result;

            var counters = _dashboardService.GetTotalCounters().Result;
            NumUsers = counters[0];
            NumBooks = counters[1];
            NumOrders = counters[2];
            NumReviews = counters[3];

            GrossRevenueList = new List<RevenueByDate>();

            var resultTable = _dashboardService.GetRevenueAnalys(_startDate, _endDate).Result;

            GrossRevenueList = (from orderList in resultTable
                                group orderList by orderList.Key
                                into order
                                select new RevenueByDate
                                {
                                    Date = order.Key,
                                    TotalAmount = order.Sum(amount => amount.Value)
                                }).ToList();

            RecentOrdersList = _dashboardService.GetRecentOrders(_startDate, _endDate).Result;

            return Task.CompletedTask;
        }
    }
}

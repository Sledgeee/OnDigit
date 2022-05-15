using HandyControl.Controls;
using OnDigit.Core.Interfaces.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Windows.Media;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using OnDigit.Core.Models.OrderModel;
using System.Collections.Generic;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Models.PaymentModel;
using OnDigit.Core.Models.WarehouseModel;

#nullable disable

namespace OnDigit.AdminPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        private readonly IAdminService _adminService;
        private readonly IShopService _shopService;
        private readonly IUserService _userService;
        private readonly IDashboardService _dashboardService;
        private Func<double, string> _yFormatter;
        private Func<double, string> _xFormatter;
        private readonly Dashboard.Dashboard _dashboard;
        private int _refreshingTimerStartValue = 30;
        private readonly DispatcherTimer _refreshingTimer;
        private ICollection<Order> _orders;
        private ICollection<Book> _books;
        private ICollection<User> _users;
        private ICollection<Payment> _payments;
        private ICollection<Warehouse> _warehouses;

        public MainWindow(IAdminService adminService, IShopService shopService, IUserService userService, IDashboardService dashboardService)
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            _adminService = adminService;
            _shopService = shopService;
            _userService = userService;
            _dashboardService = dashboardService;
            _dashboard = new Dashboard.Dashboard(_dashboardService);
            _orders = new List<Order>();
            _books = new List<Book>();
            _users = new List<User>();
            _payments = new List<Payment>();
            _warehouses = new List<Warehouse>();

            YFormatter = val => val.ToString("N") + "$";
            XFormatter = val => new DateTime((long)val).ToString("dd.MM.yy HH:mm");

            _refreshingTimer = new DispatcherTimer();

            DashboardMenuItem.IsSelected = true;

            StartTimer(_refreshingTimer);

            DataContext = this;
        }

        public enum TimerStatus
        {
            Off = 0,
            On = 1
        }

        private async void StartTimer(DispatcherTimer timer)
        {
            await TimerSetStatus(timer, RefreshingTimer_Tick, TimerStatus.On);

            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today.AddDays(1);
            await LoadData();
        }

        private static Task TimerSetStatus(DispatcherTimer timer, EventHandler eventHandler, TimerStatus status)
        {
            switch (status)
            {
                case TimerStatus.Off:
                    timer.Tick -= eventHandler;
                    timer.Stop();
                    break;
                case TimerStatus.On:
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += eventHandler;
                    timer.Start();
                    break;
            }

            return Task.CompletedTask;
        }

        private async void RefreshingTimer_Tick(object sender, EventArgs e)
        {
            this.Title = "Admin-Panel | Dashboard refreshing on " + _refreshingTimerStartValue--;
            if (_refreshingTimerStartValue == 0)
            {
                await LoadData();
                _refreshingTimerStartValue = 30;
            }
        }

        public Func<double, string> XFormatter
        {
            get { return _xFormatter; }
            set
            {
                _xFormatter = value;
                OnPropertyChanged();
            }
        }

        public Func<double, string> YFormatter
        {
            get { return _yFormatter; }
            set
            {
                _yFormatter = value;
                OnPropertyChanged();
            }
        }

        private async void SideMenuItem_Selected(object sender, RoutedEventArgs e)
        {
            LeftSideMenu.IsEnabled = false;
            DataGridUsers.Visibility = Visibility.Collapsed;
            DataGridBooks.Visibility = Visibility.Collapsed;
            DataGridOrders.Visibility = Visibility.Collapsed;
            DataGridWarehouses.Visibility = Visibility.Collapsed;
            DataGridPayments.Visibility = Visibility.Collapsed;
            Dashboard.Visibility = Visibility.Collapsed;

            DataGridUsers.ItemsSource = null;
            DataGridOrders.ItemsSource = null;
            DataGridBooks.ItemsSource = null;
            DataGridWarehouses.ItemsSource = null;
            DataGridPayments.ItemsSource = null;

            switch ((sender as SideMenuItem)?.Header)
            {
                case "Dashboard":
                    Dashboard.Visibility = Visibility.Visible;
                    break;
                case "Users":
                    LoadingAnimation.IsPlaying = true;
                    LoadingAnimation.Visibility = Visibility.Visible;

                    DataGridUsers.Visibility = Visibility.Visible;

                    _users = await _userService.GetAllAsync();
                    LoadingAnimation.IsPlaying = false;
                    LoadingAnimation.Visibility = Visibility.Collapsed;
                    DataGridUsers.ItemsSource = _users;
                    break;
                case "Orders":
                    LoadingAnimation.IsPlaying = true;
                    LoadingAnimation.Visibility = Visibility.Visible;

                    DataGridOrders.Visibility = Visibility.Visible;

                    _orders = await _adminService.GetAllOrdersAsync();
                    LoadingAnimation.IsPlaying = false;
                    LoadingAnimation.Visibility = Visibility.Collapsed;
                    DataGridOrders.ItemsSource = _orders;
                    break;
                case "Books":

                    LoadingAnimation.IsPlaying = true;
                    LoadingAnimation.Visibility = Visibility.Visible;

                    DataGridBooks.Visibility = Visibility.Visible;

                    _books = await _shopService.GetAllBooksAsync();
                    LoadingAnimation.IsPlaying = false;
                    LoadingAnimation.Visibility = Visibility.Collapsed;
                    DataGridBooks.ItemsSource = _books;
                    break;
                case "Warehouses":
                    LoadingAnimation.IsPlaying = true;
                    LoadingAnimation.Visibility = Visibility.Visible;

                    DataGridWarehouses.Visibility = Visibility.Visible;

                    _warehouses = await _adminService.GetAllWarehousesAsync();
                    LoadingAnimation.IsPlaying = false;
                    LoadingAnimation.Visibility = Visibility.Collapsed;
                    DataGridWarehouses.ItemsSource = _warehouses;
                    break;
                case "Payments":
                    LoadingAnimation.IsPlaying = true;
                    LoadingAnimation.Visibility = Visibility.Visible;

                    DataGridPayments.Visibility = Visibility.Visible;

                    _payments = await _adminService.GetAllPaymentsAsync();
                    LoadingAnimation.IsPlaying = false;
                    LoadingAnimation.Visibility = Visibility.Collapsed;
                    DataGridPayments.ItemsSource = _payments;
                    break;
            }
            LeftSideMenu.IsEnabled = true;
        }

        private void DataGridOrders_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }

        private void DataGridOrders_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task LoadData()
        {
            await _dashboard.LoadData(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value);

            NumUsers.Text = _dashboard.NumUsers.ToString();
            NumOrders.Text = _dashboard.NumOrders.ToString();
            NumBooks.Text = _dashboard.NumBooks.ToString();
            NumReviews.Text = _dashboard.NumReviews.ToString();

            ChartGrossRevenue.Series.Clear();

            if (_dashboard.GrossRevenueList.Count > 1)
            {
                ChartValues<DateTimePoint> values = new();

                foreach (var item in _dashboard.GrossRevenueList)
                {
                    values.Add(new DateTimePoint(item.Date, decimal.ToDouble(item.TotalAmount)));
                }

                ChartGrossRevenue.Series.Add(new LineSeries()
                {
                    Title = "Revenue gross",
                    Values = values,
                    LineSmoothness = 0,
                });

                RevenueGrossPeakLabel.Text = "Сurrent revenue gross peak $" + _dashboard.GrossRevenueList[^1].TotalAmount;
            }
            else
            {
                RevenueGrossPeakLabel.Text = "Current revenue gross peak $" + (_dashboard.GrossRevenueList.Count == 1 ? _dashboard.GrossRevenueList[^1].TotalAmount : 0);
            }

            ChartBestSellingBooks.Series.Clear();
            if (_dashboard.TopBooksList.Count > 0)
                foreach (var item in _dashboard.TopBooksList)
                {
                    ChartBestSellingBooks.Series.Add(new PieSeries()
                    {
                        Title = item.Book.Name,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(item.Quantity) },
                        DataLabels = true
                    });
                }
            else
                ChartBestSellingBooks.Series.Add(new PieSeries()
                {
                    Title = "No data",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(100) },
                    DataLabels = true,
                    Fill = Brushes.Transparent
                });

            DataGridRecentOrders.ItemsSource = _dashboard.RecentOrdersList;
        }

        private async void Ok_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void Custom_Click(object sender, RoutedEventArgs e)
        {
            StartDate.IsEnabled = true;
            EndDate.IsEnabled = true;
            btnOk.Visibility = Visibility.Visible;
        }

        private void DisableCustom()
        {
            StartDate.IsEnabled = false;
            EndDate.IsEnabled = false;
            btnOk.Visibility = Visibility.Hidden;
        }

        private async void Today_Click(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            await LoadData();
            DisableCustom();
        }

        private async void Last7Days_Click(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = DateTime.Today.AddDays(-7);
            EndDate.SelectedDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            await LoadData();
            DisableCustom();
        }

        private async void Last30Days_Click(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = DateTime.Today.AddDays(-30);
            EndDate.SelectedDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            await LoadData();
            DisableCustom();
        }

        private async void ThisMonth_Click(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            EndDate.SelectedDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            await LoadData();
            DisableCustom();
        }

        private void ShowFAQ_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.MessageBox.Show("Revenue is calculated only with 'Completed' orders! Orders with other statutes are not taken into account", "FAQ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void BlockOrder_Click(object sender, RoutedEventArgs e)
        {
            int number = ((Order)DataGridOrders.SelectedItem).Number;

            foreach (var order in _orders)
            {
                if (order.Number == number)
                {
                    order.OrderStatus = OrderStatus.Blocked;
                    break;
                }
            }

            DataGridOrders.Items.Refresh();

            await _adminService.ChangeOrderStatus(number, OrderStatus.Blocked);
        }
    }
}
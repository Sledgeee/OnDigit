using HandyControl.Controls;
using JetBrains.Annotations;
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
        private Dashboard.Dashboard _dashboard;
        private int _refreshingTimerStartValue = 15;
        private DispatcherTimer _refreshingTimer;

        public MainWindow(IAdminService adminService, IShopService shopService, IUserService userService, IDashboardService dashboardService)
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            _adminService = adminService;
            _shopService = shopService;
            _userService = userService;
            _dashboardService = dashboardService;
            _dashboard = new Dashboard.Dashboard(_dashboardService);

            YFormatter = val => val.ToString("N") + "$";
            XFormatter = val => new DateTime((long)val).ToString("dd.MM.yy HH:mm");

            _refreshingTimer = new DispatcherTimer();

            DashboardMenuItem.IsSelected = true;
          
            StartTimer(_refreshingTimer);

            DataContext = this;
        }

        private enum TimerStatus
        {
            Off = 0,
            On = 1
        }

        private Task StartTimer(DispatcherTimer timer)
        {
            TimerSetStatus(timer, refreshingTimer_Tick, TimerStatus.On);

            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today.AddDays(1);
            LoadData();

            return Task.CompletedTask;
        }

        private Task TimerSetStatus(DispatcherTimer timer, EventHandler eventHandler, TimerStatus status)
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

        private void refreshingTimer_Tick(object sender, EventArgs e)
        {
            this.Title = "Admin-Panel | Refreshing on " + _refreshingTimerStartValue--;
            if (_refreshingTimerStartValue == 0)
            {
                LoadData();
                _refreshingTimerStartValue = 15;
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
            switch ((sender as SideMenuItem)?.Header)
            {
                case "Dashboard":
                    DataGridUsers.Visibility = Visibility.Collapsed;
                    DataGridBooks.Visibility = Visibility.Collapsed;
                    DataGridOrders.Visibility = Visibility.Collapsed;
                    DataGridStocks.Visibility = Visibility.Collapsed;
                    SearchBar.Visibility = Visibility.Collapsed;
                    Dashboard.Visibility = Visibility.Visible;
                    break;
                case "Users":
                    Dashboard.Visibility = Visibility.Collapsed;
                    DataGridOrders.Visibility = Visibility.Collapsed;
                    DataGridBooks.Visibility = Visibility.Collapsed;
                    DataGridStocks.Visibility = Visibility.Collapsed;
                    LoadingAnimation.Visibility = Visibility.Visible;

                    await Task.Delay(1000);
                    DataGridUsers.Visibility = Visibility.Visible;
                    SearchBar.Visibility = Visibility.Visible;
                    DataGridUsers.ItemsSource = await _userService.GetAllAsync();

                    LoadingAnimation.Visibility = Visibility.Collapsed;
                    break;
                case "Orders":
                    Dashboard.Visibility = Visibility.Collapsed;
                    DataGridUsers.Visibility = Visibility.Collapsed;
                    DataGridBooks.Visibility = Visibility.Collapsed;
                    DataGridStocks.Visibility = Visibility.Collapsed;
                    LoadingAnimation.Visibility = Visibility.Visible;

                    await Task.Delay(1000);
                    DataGridOrders.Visibility = Visibility.Visible;
                    SearchBar.Visibility = Visibility.Visible;
                    DataGridOrders.ItemsSource = await _adminService.GetAllOrdersAsync();

                    LoadingAnimation.Visibility = Visibility.Collapsed;
                    break;
                case "Books":
                    Dashboard.Visibility = Visibility.Collapsed;
                    DataGridUsers.Visibility = Visibility.Collapsed;
                    DataGridOrders.Visibility = Visibility.Collapsed;
                    DataGridStocks.Visibility = Visibility.Collapsed;
                    LoadingAnimation.Visibility = Visibility.Visible;

                    await Task.Delay(1000);
                    SearchBar.Visibility = Visibility.Visible;
                    DataGridBooks.Visibility = Visibility.Visible;

                    var books = await _shopService.GetAllBooksAsync();

                    foreach (var book in books)
                    {
                        book.IsAvailable = book.StockPackage.Quantity > 0 ? true : false;
                    }

                    DataGridBooks.ItemsSource = books;

                    LoadingAnimation.Visibility = Visibility.Collapsed;
                    break;
                case "Stocks":
                    Dashboard.Visibility = Visibility.Collapsed;
                    DataGridUsers.Visibility = Visibility.Collapsed;
                    DataGridOrders.Visibility = Visibility.Collapsed;
                    DataGridBooks.Visibility = Visibility.Collapsed;
                    LoadingAnimation.Visibility = Visibility.Visible;

                    await Task.Delay(1000);
                    SearchBar.Visibility = Visibility.Visible;
                    DataGridStocks.Visibility = Visibility.Visible;
                    DataGridStocks.ItemsSource = await _adminService.GetAllStocksAsync();

                    LoadingAnimation.Visibility = Visibility.Collapsed;
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

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler is not null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private Task LoadData()
        {
            _dashboard.LoadData(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value);

            NumUsers.Text = _dashboard.NumUsers.ToString();
            NumOrders.Text = _dashboard.NumOrders.ToString();
            NumBooks.Text = _dashboard.NumBooks.ToString();
            NumReviews.Text = _dashboard.NumReviews.ToString();

            ChartGrossRevenue.Series.Clear();

            if (_dashboard.GrossRevenueList.Count > 0)
            {
                ChartValues<DateTimePoint> values = new ChartValues<DateTimePoint>();

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
                RevenueGrossPeakLabel.Text = "Current revenue gross peak $0";
            }

            ChartBestSellingBooks.Series.Clear();
            if (_dashboard.TopBooksList.Count > 0)
                foreach (var item in _dashboard.TopBooksList)
                {
                    ChartBestSellingBooks.Series.Add(new PieSeries()
                    {
                        Title = item.Key,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(item.Value) },
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

            return Task.CompletedTask;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
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

        private void Today_Click(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            LoadData();
            DisableCustom();
        }

        private void Last7Days_Click(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = DateTime.Today.AddDays(-7);
            EndDate.SelectedDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            LoadData();
            DisableCustom();
        }

        private void Last30Days_Click(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = DateTime.Today.AddDays(-30);
            EndDate.SelectedDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            LoadData();
            DisableCustom();
        }

        private void ThisMonth_Click(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            EndDate.SelectedDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            LoadData();
            DisableCustom();
        }

        private void ShowFAQ_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.MessageBox.Show("Revenue is calculated only with 'COMPLETED' orders! 'Processing' and 'Blocked' orders are not taken into account", "FAQ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SearchBar_SearchStarted(object sender, HandyControl.Data.FunctionEventArgs<string> e)
        {
            if (DataGridBooks.Visibility == Visibility.Visible)
            {
                //for (int i = 0; i < DataGridBooks.Items.Count; i++)
                //{
                //    DataGridRow row = DataGridBooks.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                    
                //    var content = DataGridBooks.Columns[3].GetCellContent(row) as TextBlock;

                //    if (content != null && content.Text.Equals(SearchBar.Text))
                //    {
                //        object item = DataGridBooks.Items[i];
                //        DataGridBooks.SelectedIndex = i;
                //        DataGridBooks.ScrollIntoView(item);
                //        row.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
                //        return;
                //    }
                    
                //}
            }
            else if (DataGridUsers.Visibility == Visibility.Visible)
            {

            }
            else if (DataGridOrders.Visibility == Visibility.Visible)
            {

            }
            else
            {

            }
        }
    }
}
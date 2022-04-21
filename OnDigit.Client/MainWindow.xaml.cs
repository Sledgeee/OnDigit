using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using OnDigit.Client.Windows.Auth;
using OnDigit.Client.Windows.Shop.Controls;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.UserModel;
using Microsoft.Win32;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.EditionModel;
using System.Windows.Media;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using OnDigit.Core.Models.CartModel;

namespace OnDigit.Client
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IShopService _shopService;
        private readonly IUserService _userService; 
        private readonly IOrderService _orderService;
        private readonly IReviewService _reviewService;
        private Session _currentSession;
        public Cart UserCart { get; set; } = new Cart();

        public MainWindow(IAuthenticationService authenticationService,
                          IShopService shopService, 
                          IUserService userService, 
                          IOrderService orderService,
                          IReviewService reviewService)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            _authenticationService = authenticationService;
            _shopService = shopService;
            _userService = userService;
            _orderService = orderService;
            _reviewService = reviewService;
            Initialize();

        }

        private async void Initialize()
        {
            _currentUser = null;
            if (await CheckOnSession() is false)
            {
                SignInDialog();
            }
            ItemShop.IsSelected = true;
        }

        private void SpinnersPropsChange(string spinner, bool spin, Visibility visibility)
        {
            switch(spinner)
            {
                case "SpinnerBooks":
                    SpinnerBooks_1.Spin = spin;
                    SpinnerBooks_2.Spin = spin;
                    SpinnerBooks_1.Visibility = visibility;
                    SpinnerBooks_2.Visibility = visibility;
                    break;
                case "SpinnerSession":
                    SpinnerSession_1.Spin = spin;
                    SpinnerSession_2.Spin = spin;
                    SpinnerSession_1.Visibility = visibility;
                    SpinnerSession_2.Visibility = visibility;
                    break;
            }
        }

        private async Task<bool> CheckOnSession()
        {
            await Task.Delay(1000);
            var key = Registry.CurrentUser.OpenSubKey("OnDigitSession");
            if (key is null)
            {
                SpinnersPropsChange("SpinnerSession", false, Visibility.Collapsed);
                return false;
            }

            var pcId = key?.GetValue("pcId")?.ToString();
            var userId = key?.GetValue("userId")?.ToString();

            if (string.IsNullOrEmpty(pcId) is false)
            {
                _currentSession = await _userService.GetSessionInfo(pcId, userId);
                if (_currentSession is not null)
                {
                    if (DateTime.UtcNow <= _currentSession.EndDate && _currentSession.IsCanceledInAdvance is false)
                    {
                        _currentUser = await _userService.GetByIdAsync(userId);
                        if (_currentUser is not null)
                        {
                            UserFullname.Text = _currentUser.Name + " " + _currentUser.Surname;
                            UserBalance.Text = _currentUser.Balance + "$";
                            LoginedState.Visibility = Visibility.Visible;

                            foreach (var order in _currentUser.Orders)
                                Orders.Children.Add(new OrderCard(order));

                            SpinnersPropsChange("SpinnerSession", false, Visibility.Collapsed);
                            return true;
                        }
                    }
                }
            }

            SpinnersPropsChange("SpinnerSession", false, Visibility.Collapsed);
            return false;
        }

        private async void UpdateOrders()
        {
            Orders.Children.Clear();

            _currentUser.Orders = await _shopService.LoadCurrentUserOrdersAsync(_currentUser.Id);

            foreach (var order in _currentUser.Orders)
                Orders.Children.Add(new OrderCard(order));
        }

        private async void LoadBooks(ICollection<Edition> editionList)
        {
            SpinnersPropsChange("SpinnerBooks", true, Visibility.Visible);

            this.Shop.Effect = new BlurEffect();

            GridMenu.IsEnabled = false;

            await Task.Delay(1000);

            foreach (var edition in editionList)
            {
                Shop.Children.Add(new ShopEditionCard(this, edition, _currentUser.Id, _reviewService, _userService));

                if (((ShopEditionCard)Shop.Children[^1]).icon_favorites.Kind == PackIconKind.Heart)
                    Favorites.Children.Add(new ShopEditionCard(this, edition, _currentUser.Id, _reviewService, _userService));
            }

            editionList.Clear();
            GridMenu.IsEnabled = true;
            this.Shop.Effect = null;
            SpinnersPropsChange("SpinnerBooks", false, Visibility.Collapsed);
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private async void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemShop":
                    SearchBox.Text = string.Empty;
                    SwitchToOtherTab(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Brushes.Orange, Brushes.White, Brushes.White, Brushes.White);
                    LoadBooks(await _shopService.GetAllEditionsAsync());
                    break;
                case "ItemFavorites":
                    SwitchToOtherTab(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Brushes.White, Brushes.Orange, Brushes.White, Brushes.White);
                    LoadBooks(await _shopService.GetAllEditionsAsync());
                    break;
                case "ItemOrders":
                    SwitchToOtherTab(Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Brushes.White, Brushes.White, Brushes.Orange, Brushes.White);
                    break;
                case "ItemCart":
                    SwitchToOtherTab(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Brushes.White, Brushes.White, Brushes.White, Brushes.Orange);
                    UpdateCartSelection();
                    break;
            }
        }

        public void UpdateCartSelection()
        {
            CartWrap.Children.Clear();
            foreach (var edition in UserCart.Editions)
                CartWrap.Children.Add(new CartEditionCard(this, UserCart, edition));
            CartTotalPrice.Text = UserCart.TotalPrice + "$";
            CartEditionsCount.Text = UserCart.Editions.Count.ToString();
            SuccessOrder.Visibility = Visibility.Collapsed;
        }

        private void SwitchToOtherTab(Visibility shopVisibility, Visibility favoritesVisibility, Visibility ordersVisibility, Visibility cartVisibility,
                                      Brush brushShop, Brush brushFavorites, Brush brushOrders, Brush brushCart)
        {
            Shop.Children.Clear();
            Favorites.Children.Clear();
            if (shopVisibility == Visibility.Visible)
                SearchBar.Visibility = Visibility.Visible;
            else
                SearchBar.Visibility = Visibility.Collapsed;
            Shop.Visibility = shopVisibility;
            Favorites.Visibility = favoritesVisibility;
            Orders.Visibility = ordersVisibility;
            Cart.Visibility = cartVisibility;
            ItemShopIcon.Foreground = brushShop;
            ItemShopText.Foreground = brushShop;
            ItemFavoritesIcon.Foreground = brushFavorites;
            ItemFavoritesText.Foreground = brushFavorites;
            ItemOrdersIcon.Foreground = brushOrders;
            ItemOrdersText.Foreground = brushOrders;
            ItemCartIcon.Foreground = brushCart;
            ItemCartText.Foreground = brushCart;
        }

        private async void Logout_Click(object sender, RoutedEventArgs e)
        {
            _currentSession.IsCanceledInAdvance = true;
            await _userService.UpdateSessionInfo(_currentSession);
            Registry.CurrentUser.DeleteSubKey("OnDigitSession");
            LoginedState.Visibility = Visibility.Collapsed;
            UserFullname.Text = string.Empty;
            UserBalance.Text = string.Empty;
            Shop.Children.Clear();
            SignInDialog();
        }

        private async void SignInDialog()
        {
            this.Effect = new BlurEffect();
            new SignIn(this, _authenticationService)
            {
                Topmost = true
            }.ShowDialog();
            this.Effect = null;

            if (_currentUser is not null)
            {
                UserFullname.Text = _currentUser.Name + " " + _currentUser.Surname;
                UserBalance.Text = _currentUser.Balance + "$";
                LoginedState.Visibility = Visibility.Visible;
                LoadBooks(await _shopService.GetAllEditionsAsync());
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void ShutdownApp_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState is WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                MaximizeBtnIcon.Kind = PackIconKind.WindowRestore;
                Shop.Margin = new Thickness(115, 90, 0, 50);
                Favorites.Margin = new Thickness(115, 90, 0, 50);
                Orders.Margin = new Thickness(115, 90, 0, 50);
                SelectedBooks.Height = new GridLength(750);
                SelectedBooksBorder.Height = 725;
            }
            else
            {
                
                this.WindowState = WindowState.Normal;
                MaximizeBtnIcon.Kind = PackIconKind.WindowMaximize;
                Shop.Margin = new Thickness(83, 72, 0, 10);
                Favorites.Margin = new Thickness(83, 72, 0, 10);
                Orders.Margin = new Thickness(83, 72, 0, 10);
                SelectedBooks.Height = new GridLength(615);
                SelectedBooksBorder.Height = 600;
            }
        }

        private async void ActivateSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text) is true)
                return;

            ICollection<Edition> searchedEditions = await _shopService.SearchEditionsAsync(SearchBox.Text);

            Shop.Children.Clear();

            if (searchedEditions is not null)
                LoadBooks(searchedEditions);

            ItemSearch.IsSelected = true;
            ItemShopIcon.Foreground = Brushes.White;
            ItemShopText.Foreground = Brushes.White;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private async void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (CartWrap.Children.Count > 0)
            {
                ScrollViewerCart.Effect = new BlurEffect();
                BorderCart.Effect = new BlurEffect();
                SpinnersPropsChange("SpinnerBooks", true, Visibility.Visible);
                await Task.Delay(1000);
                await _orderService.CreateOrderAsync(_currentUser.Id, UserCart);
                CartWrap.Children.Clear();
                CartTotalPrice.Text = "0$";
                CartEditionsCount.Text = "0";
                UserCart = new();
                SuccessOrder.Visibility = Visibility.Visible;
                UpdateOrders();
                SpinnersPropsChange("SpinnerBooks", false, Visibility.Collapsed);
                ScrollViewerCart.Effect = null;
                BorderCart.Effect = null;
            }
        }


        private User? _currentUser;
        public User? CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler is not null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}

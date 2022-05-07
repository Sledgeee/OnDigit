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
using OnDigit.Core.Models.BookModel;
using System.Windows.Media;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using OnDigit.Core.Models.CartModel;
using System.Linq;

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
        private Session _currentSession = new();
        internal Cart UserCart = new();

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
            UpdateOrders();
        }

        private async Task<bool> CheckOnSession()
        {
            await Task.Delay(500);
            var key = Registry.CurrentUser.OpenSubKey("OnDigitSession");
            if (key is null)
            {
                ProfileLoadingAnimation.IsPlaying = false;
                ProfileLoadingAnimation.Visibility = Visibility.Collapsed;
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
                            LoginedState.Visibility = Visibility.Visible;

                            foreach (var order in _currentUser.Orders)
                                Orders.Children.Add(new OrderCard(order));

                            ProfileLoadingAnimation.IsPlaying = false;
                            ProfileLoadingAnimation.Visibility = Visibility.Collapsed;
                            return true;
                        }
                    }
                }
            }

            ProfileLoadingAnimation.IsPlaying = false;
            ProfileLoadingAnimation.Visibility = Visibility.Collapsed;
            return false;
        }

        private async void UpdateOrders()
        {
            Orders.Children.Clear();

            _currentUser.Orders = await _shopService.GetCurrentUserOrdersAsync(_currentUser.Id);

            foreach (var order in _currentUser.Orders)
                Orders.Children.Add(new OrderCard(order) { Name = "OrderCard" + order.Number });
        }

        private async void LoadBooks(ICollection<Book> bookList)
        {
            ShopLoadingAnimation.IsPlaying = true;
            ShopLoadingAnimation.Visibility = Visibility.Visible;

            this.Shop.Effect = new BlurEffect();

            GridMenu.IsEnabled = false;

            await Task.Delay(1000);

            foreach (var book in bookList)
            {
                Shop.Children.Add(new ShopBookCard(this, book, _currentUser, _reviewService, _userService));

                if (((ShopBookCard)Shop.Children[^1]).icon_favorites.Kind == PackIconKind.Heart)
                    Favorites.Children.Add(new ShopBookCard(this, book, _currentUser, _reviewService, _userService));
            }

            GridMenu.IsEnabled = true;
            this.Shop.Effect = null;
            ShopLoadingAnimation.IsPlaying = false;
            ShopLoadingAnimation.Visibility = Visibility.Collapsed;
        }

        private async void LoadSearchResult(ICollection<Book> bookList)
        {
            ShopLoadingAnimation.IsPlaying = true;
            ShopLoadingAnimation.Visibility = Visibility.Visible;

            this.Shop.Effect = new BlurEffect();

            GridMenu.IsEnabled = false;

            await Task.Delay(1000);

            foreach (var book in bookList)
            {
                Search.Children.Add(new ShopBookCard(this, book, _currentUser, _reviewService, _userService));
            }

            GridMenu.IsEnabled = true;
            this.Shop.Effect = null;
            ShopLoadingAnimation.IsPlaying = false;
            ShopLoadingAnimation.Visibility = Visibility.Collapsed;
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
                    SwitchToOtherTab(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Brushes.Orange, Brushes.White, Brushes.White, Brushes.White, Brushes.White);
                    LoadBooks(await _shopService.GetAllBooksAsync());
                    break;
                case "ItemSearch":
                    SwitchToOtherTab(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Brushes.White, Brushes.Orange, Brushes.White, Brushes.White, Brushes.White);
                    break;
                case "ItemFavorites":
                    SwitchToOtherTab(Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Brushes.White, Brushes.White, Brushes.Orange, Brushes.White, Brushes.White);
                    LoadBooks(await _shopService.GetAllBooksAsync());
                    break;
                case "ItemOrders":
                    SwitchToOtherTab(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Brushes.White, Brushes.White, Brushes.White, Brushes.Orange, Brushes.White);
                    break;
                case "ItemCart":
                    SwitchToOtherTab(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Orange);
                    UpdateCartSelection();
                    break;
            }
        }

        public void UpdateCartSelection()
        {
            int i = 1;
            CartWrap.Children.Clear();
            foreach (var book in UserCart.Books)
                CartWrap.Children.Add(new CartBookCard(this, book.Key, book.Value) { Name = "CartItem" +  i++});
            CartTotalPrice.Text = "$" + UserCart.TotalPrice;
            CartBooksCount.Text = UserCart.Books.Sum(x => x.Value).ToString();
            SuccessOrder.Visibility = Visibility.Collapsed;
        }

        private void SwitchToOtherTab(Visibility shopVisibility, Visibility searchVisibility, Visibility favoritesVisibility, Visibility ordersVisibility, Visibility cartVisibility,
                                      Brush brushShop, Brush brushSearch, Brush brushFavorites, Brush brushOrders, Brush brushCart)
        {
            Shop.Children.Clear();
            Favorites.Children.Clear();

            if (searchVisibility == Visibility.Visible)
                SearchBar.Visibility = Visibility.Visible;
            else
                SearchBar.Visibility = Visibility.Collapsed;

            Shop.Visibility = shopVisibility;
            Search.Visibility = searchVisibility;
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
            ItemSearchIcon.Foreground = brushSearch;
            ItemSearchText.Foreground = brushSearch;
        }

        private async void Logout_Click(object sender, RoutedEventArgs e)
        {
            _currentSession.IsCanceledInAdvance = true;
            await _userService.UpdateSessionInfo(_currentSession);
            Registry.CurrentUser.DeleteSubKey("OnDigitSession");
            LoginedState.Visibility = Visibility.Collapsed;
            UserFullname.Text = string.Empty;
            Shop.Children.Clear();
            SignInDialog();
            if (!string.IsNullOrEmpty(UserFullname.Text) && ItemShop.IsSelected)
            {
                LoadBooks(await _shopService.GetAllBooksAsync());
            }
        }

        private void SignInDialog()
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
                LoginedState.Visibility = Visibility.Visible;
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
                ShopScrollViewer.Margin = new Thickness(0, 60, 0, 10);
                Shop.Margin = new Thickness(115, 30, 0, 50);
                Favorites.Margin = new Thickness(115, 30, 0, 50);
                Orders.Margin = new Thickness(115, 30, 0, 50);
                SelectedBooks.Height = new GridLength(750);
                SelectedBooksBorder.Height = 725;
            }
            else
            {
                
                this.WindowState = WindowState.Normal;
                MaximizeBtnIcon.Kind = PackIconKind.WindowMaximize;
                ShopScrollViewer.Margin = new Thickness(0, 60, 0, 0);
                Shop.Margin = new Thickness(83, 12, 0, 10);
                Favorites.Margin = new Thickness(83, 12, 0, 10);
                Orders.Margin = new Thickness(83, 12, 0, 10);
                SelectedBooks.Height = new GridLength(615);
                SelectedBooksBorder.Height = 600;
            }
        }

        private async void ActivateSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text) is true)
                return;

            ICollection<Book> searchedBooks = await _shopService.SearchBooksAsync(SearchBox.Text);

            Search.Children.Clear();

            if (searchedBooks is not null)
                LoadSearchResult(searchedBooks);

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
                ShopLoadingAnimation.IsPlaying = true;
                ShopLoadingAnimation.Visibility = Visibility.Visible;
                await Task.Delay(1000);
                await _orderService.CreateOrderAsync(_currentUser.Id, UserCart);
                CartWrap.Children.Clear();
                CartTotalPrice.Text = "$0";
                CartBooksCount.Text = "0";
                UserCart = new();
                SuccessOrder.Visibility = Visibility.Visible;
                UpdateOrders();
                ShopLoadingAnimation.IsPlaying = false;
                ShopLoadingAnimation.Visibility = Visibility.Collapsed;
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

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
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

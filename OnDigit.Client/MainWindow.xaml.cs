using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using OnDigit.Client.UI.Auth;
using OnDigit.Client.UI.Shop.Controls;
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
using OnDigit.Core.Models.PaymentModel;

#nullable disable

namespace OnDigit.Client
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IShopService _shopService;
        private readonly IUserService _userService; 
        private readonly IOrderService _orderService;
        private readonly IReviewService _reviewService;
        private Session _currentSession = new();
        internal Cart UserCart = new();

        public MainWindow(User user,
                          Session session,
                          IShopService shopService, 
                          IUserService userService, 
                          IOrderService orderService,
                          IReviewService reviewService)
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            _currentSession = session;
            CurrentUser = user;
            _shopService = shopService;
            _userService = userService;
            _orderService = orderService;
            _reviewService = reviewService;
            UserFullname.Text = _currentUser.Name + " " + _currentUser.Surname;
            ThisUserCards.ItemsSource = _currentUser.Wallets;
            ItemShop.IsSelected = true;
            DataContext = this;
        }

        private async void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (_currentSession != null)
            {
                await _userService.UpdateSessionInfo(_currentSession);
                Registry.CurrentUser.DeleteSubKey("OnDigitSession");
            }
            this.Close();
        }

        private async void UpdateOrders()
        {
            Orders.Children.Clear();

            _currentUser.Orders = await _shopService.GetCurrentUserOrdersAsync(_currentUser.Id);

            foreach (var order in _currentUser.Orders)
                Orders.Children.Add(new UserOrderCard(this, order, _orderService, _userService));
        }

        private void LoadBooks(ICollection<Book> bookList)
        {
            ShopLoadingAnimation.IsPlaying = true;
            ShopLoadingAnimation.Visibility = Visibility.Visible;

            this.Shop.Effect = new BlurEffect();

            GridMenu.IsEnabled = false;

            foreach (var book in bookList)
            {
                Shop.Children.Add(new ShopBookCard(this, book, _currentUser, _reviewService, _userService));

                if (((ShopBookCard)Shop.Children[^1]).icon_favorites.Kind == PackIconKind.Heart)
                    Favorites.Children.Add(new ShopBookCard(this, book, _currentUser, _reviewService, _userService));
            }

            if (Favorites.Children.Count == 0 && Favorites.Visibility == Visibility.Visible)
            {
                EmptyText.Text = "So far you don't have favorite books";
            }

            GridMenu.IsEnabled = true;
            this.Shop.Effect = null;
            ShopLoadingAnimation.IsPlaying = false;
            ShopLoadingAnimation.Visibility = Visibility.Collapsed;
        }

        private void LoadSearchResult(ICollection<Book> bookList)
        {
            ShopLoadingAnimation.IsPlaying = true;
            ShopLoadingAnimation.Visibility = Visibility.Visible;

            this.Shop.Effect = new BlurEffect();

            GridMenu.IsEnabled = false;

            foreach (var book in bookList)
            {
                Search.Children.Add(new ShopBookCard(this, book, _currentUser, _reviewService, _userService));
            }

            if (Search.Children.Count == 0)
                EmptyText.Text = "No results";

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
            ListViewItem item = ListViewMenu.SelectedItems.Count > 0 ? (ListViewItem)ListViewMenu.SelectedItem : null;
            if (item is null)
                return;

            if (_currentUser is null)
                return;

            switch (item.Name)
            {
                case "ItemShop":
                    SwitchToOtherTab(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Brushes.Orange, Brushes.White, Brushes.White);
                    LoadBooks(await _shopService.GetAllBooksAsync());
                    SecondStepCart.Visibility = Visibility.Collapsed;
                    break;
                case "ItemSearch":
                    SwitchToOtherTab(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Brushes.White, Brushes.Orange, Brushes.White);
                    break;
                case "ItemCart":
                    SwitchToOtherTab(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Brushes.White, Brushes.White, Brushes.Orange);
                    FirstStepCart.Visibility = Visibility.Visible;
                    UpdateCartSelection();
                    break;
                default:
                    break;
            }
        }

        public void UpdateCartSelection()
        {
            CartWrap.Children.Clear();
            foreach (var book in UserCart.Books)
                CartWrap.Children.Add(new CartBookCard(this, book.Key, book.Value));
            CartTotalPrice.Text = "$" + UserCart.TotalAmount;
            CartBooksCount.Text = UserCart.Books.Sum(x => x.Value).ToString();
            SuccessOrder.Visibility = Visibility.Collapsed;
        }

        private void SwitchToOtherTab(Visibility shopVisibility, Visibility searchVisibility, Visibility favoritesVisibility, Visibility ordersVisibility, 
            Visibility cartVisibility, Visibility walletVisibility, Brush brushShop, Brush brushSearch, Brush brushCart)
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
            Wallets.Visibility = walletVisibility;
            ItemShopIcon.Foreground = brushShop;
            ItemShopText.Foreground = brushShop;
            ItemCartIcon.Foreground = brushCart;
            ItemCartText.Foreground = brushCart;
            ItemSearchIcon.Foreground = brushSearch;
            ItemSearchText.Foreground = brushSearch;
            EmptyText.Text = string.Empty;
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

            EmptyText.Text = string.Empty;
            Search.Children.Clear();

            if (searchedBooks is not null)
                LoadSearchResult(searchedBooks);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            try
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
            }
            catch (Exception)
            {

            }
        }

        private void CreateCheckout_Click(object sender, RoutedEventArgs e)
        {
            if (CartWrap.Children.Count > 0)
            {
                ScrollViewerCart.Effect = new BlurEffect();
                BorderCart.Effect = new BlurEffect();
                ShopLoadingAnimation.IsPlaying = true;
                ShopLoadingAnimation.Visibility = Visibility.Visible;

                FirstStepCart.Visibility = Visibility.Collapsed;
                ShopLoadingAnimation.IsPlaying = false;
                ShopLoadingAnimation.Visibility = Visibility.Collapsed;
                ScrollViewerCart.Effect = null;
                BorderCart.Effect = null;
                ContactEmail.Text = _currentUser.Email;
                ContactName.Text = _currentUser.Name;
                ContactSurname.Text = _currentUser.Surname;
                SecondStepCart.Visibility = Visibility.Visible;
            }
        }

        private void SecondStepCart_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            WrapOrders.Children.Clear();
            if (SecondStepCart.Visibility == Visibility.Visible)
            {
                Dictionary<Book, Tuple<int, decimal>> books = new();

                var kvps = UserCart.Books.OrderBy(x => x.Key.Package.WarehouseId);
                int currentWarehouseId = kvps.First().Key.Package.WarehouseId;
                int orderNum = 1;

                foreach (var kvp in kvps)
                {
                    if (currentWarehouseId == kvp.Key.Package.WarehouseId)
                    {
                        books.Add(kvp.Key, new Tuple<int, decimal>(kvp.Value, kvp.Value * kvp.Key.Price));
                    }
                    else
                    {
                        WrapOrders.Children.Add(new CartOrderPanel(orderNum++, books, this, _userService));
                        currentWarehouseId = kvp.Key.Package.WarehouseId;
                        books = new();
                        books.Add(kvp.Key, new Tuple<int, decimal>(kvp.Value, kvp.Value * kvp.Key.Price));
                    }
                }
                if (WrapOrders.Children.Count > 0)
                    WrapOrders.Children.Add(new CartOrderPanel(orderNum, books, this, _userService));
                else
                    WrapOrders.Children.Add(new CartOrderPanel(books, this, _userService));

                CountBooks.Text = UserCart.TotalBooksQuantity + " books worth";
                TotalAmountForAllOrders.Text = "$" + UserCart.TotalAmount;
                ToPay.Text = "$" + (UserCart.TotalAmount + 3.50m);

                books.Clear();
            }
        }

        private async void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            SecondStepCart.Effect = new BlurEffect();
            BorderCart.Effect = new BlurEffect();
            ShopLoadingAnimation.IsPlaying = true;
            ShopLoadingAnimation.Visibility = Visibility.Visible;

            foreach (var item in WrapOrders.Children)
            {
                var cartOrderPanel = item as CartOrderPanel;

                var books = new Dictionary<Book, Tuple<int, decimal>>();

                foreach (var book in cartOrderPanel.ThisOrderBooks.Items)
                {
                    var kvp = (KeyValuePair<Book, Tuple<int, decimal>>)book;
                    books.Add(kvp.Key, kvp.Value);
                }

                await _orderService.CreateOrderAsync(
                    _currentUser.Id,
                    ContactName.Text + " " + ContactSurname.Text,
                    ContactPhone.Text,
                    ContactEmail.Text,
                    books,
                    cartOrderPanel.TotalAmount,
                    cartOrderPanel.DeliveryCompany, 
                    cartOrderPanel.DeliveryAddress,
                    cartOrderPanel.CardToPay);
            }

            CartWrap.Children.Clear();
            CartTotalPrice.Text = "$0";
            CartBooksCount.Text = "0";
            UserCart = new();
            UpdateOrders();
            SecondStepCart.Effect = null;
            BorderCart.Effect = null;
            SecondStepCart.Visibility = Visibility.Collapsed;
            FirstStepCart.Visibility = Visibility.Visible;
            SuccessOrder.Visibility = Visibility.Visible;
            ShopLoadingAnimation.IsPlaying = false;
            ShopLoadingAnimation.Visibility = Visibility.Collapsed;
        }

        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ShowActivatePromo_Click(object sender, RoutedEventArgs e)
        {
            AddPromo.Visibility = Visibility.Collapsed;
            ActivatePromo.Visibility = Visibility.Visible;
        }

        private void HideActivationPromo_Click(object sender, RoutedEventArgs e)
        {
            AddPromo.Visibility = Visibility.Visible;
            ActivatePromo.Visibility = Visibility.Collapsed;
        }

        private void ActivatePromo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            SecondStepCart.Effect = new BlurEffect();
            BorderCart.Effect = new BlurEffect();
            ShopLoadingAnimation.IsPlaying = true;
            ShopLoadingAnimation.Visibility = Visibility.Visible;

            SecondStepCart.Visibility = Visibility.Collapsed;
            ShopLoadingAnimation.IsPlaying = false;
            ShopLoadingAnimation.Visibility = Visibility.Collapsed;
            SecondStepCart.Effect = null;
            BorderCart.Effect = null;
            FirstStepCart.Visibility = Visibility.Visible;
        }

        private void ShowOrders_Click(object sender, RoutedEventArgs e)
        {
            ListViewMenu.UnselectAll();
            UpdateOrders();
            SwitchToOtherTab(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Brushes.White, Brushes.White, Brushes.White);
            if (_currentUser.Orders.Count == 0)
            {
                EmptyText.Text = "So far you don't have orders";
            }
            else
            {
                EmptyText.Text = string.Empty;
            }
        }

        private async void ShowFavorites_Click(object sender, RoutedEventArgs e)
        {
            ListViewMenu.UnselectAll();
            SwitchToOtherTab(Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Brushes.White, Brushes.White, Brushes.White);
            LoadBooks(await _shopService.GetAllBooksAsync());
        }

        private void ShowWallet_Click(object sender, RoutedEventArgs e)
        {
            ListViewMenu.UnselectAll();
            SwitchToOtherTab(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Brushes.White, Brushes.White, Brushes.White);
        }

        private void CancelAddingCard_Click(object sender, RoutedEventArgs e)
        {
            NewCardBorder.Visibility = Visibility.Collapsed;
            NewCardNumber.Text = string.Empty;
            NewCardExpiryMonth.Text = string.Empty;
            NewCardExpiryYear.Text = string.Empty;
            NewCardCVV.Password = string.Empty;
        }

        private async void SaveCard_Click(object sender, RoutedEventArgs e)
        {
            await _userService.AddNewCard(new()
            {
                UserId = _currentUser.Id,
                CardNumber = NewCardNumber.Text,
                ExpiryDate = NewCardExpiryMonth.Text + "/" + NewCardExpiryYear.Text,
                CVV = NewCardCVV.Password
            });
            _currentUser.Wallets = await _userService.GetUserWallet(_currentUser.Id);
            ThisUserCards.ItemsSource = null;
            ThisUserCards.ItemsSource = _currentUser.Wallets;
            NewCardBorder.Visibility = Visibility.Collapsed;
            NewCardNumber.Text = string.Empty;
            NewCardExpiryMonth.Text = string.Empty;
            NewCardExpiryYear.Text = string.Empty;
            NewCardCVV.Password = string.Empty;
        }

        private void ShowNewCardBorder_Click(object sender, RoutedEventArgs e)
        {
            NewCardBorder.Visibility = Visibility.Visible;
        }

        private void NewCardExpiryMonth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewCardExpiryMonth.Text.Length == NewCardExpiryMonth.MaxLength)
                NewCardExpiryYear.Focus();
        }

        private void NewCardExpiryYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewCardExpiryYear.Text.Length == NewCardExpiryYear.MaxLength)
                NewCardCVV.Focus();
        }

        private void NewCardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewCardNumber.Text.Length == NewCardNumber.MaxLength)
                NewCardExpiryMonth.Focus();
        }

        private async void RemoveCard_Click(object sender, RoutedEventArgs e)
        {
            if (HandyControl.Controls.MessageBox.Show("Are you sure you want to delete this card?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var selectedCard = (Wallet)ThisUserCards.SelectedItem;
                await _userService.RemoveCard(_currentUser.Id, selectedCard.Id);
                _currentUser.Wallets = await _userService.GetUserWallet(_currentUser.Id);
                ThisUserCards.ItemsSource = null;
                ThisUserCards.ItemsSource = _currentUser.Wallets;
            }
        }
    }
}

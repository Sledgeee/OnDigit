using MaterialDesignThemes.Wpf;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.OrderModel;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

#nullable disable

namespace OnDigit.Client.UI.Shop.Controls
{
    /// <summary>
    /// Interaction logic for UserOrderCard.xaml
    /// </summary>
    public partial class UserOrderCard : UserControl
    {
        private IOrderService _orderService;
        private IUserService _userService;
        private readonly string _userId;
        private readonly MainWindow _mainWindow;
        Dictionary<Book, Tuple<int, decimal>> _books;

        public UserOrderCard(MainWindow mainWindow, Order order, IOrderService orderService, IUserService userSerive)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _orderService = orderService;
            _userService = userSerive;
            _userId = order.UserId;
            OrderNumber = order.Number;
            OrderPrice = order.TotalAmount + 3.50m;
            OrderDate = order.DateOrder.ToString("dd/MM/yyyy HH:mm:ss");

            foreach (var item in order.OrdersBooks)
            {
                OrderedBooks.Children.Add(new Image()
                {
                    Source = new BitmapImage(new Uri(item.Book.ImageUri)),
                    Margin = new Thickness(3),
                });
            }

            if (order.OrderStatus != OrderStatus.Blocked)
            {
                PStatus = order.PayStatus.ToString();
                OrderStatusBorder.Background = order.PayStatus == PayStatus.Paid ? Brushes.Green : Brushes.Gray;
                OrderStatusBorder.BorderBrush = order.PayStatus == PayStatus.Paid ? Brushes.Green : Brushes.Gray;
                PayButton.Visibility = order.PayStatus == PayStatus.Unpaid ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                PStatus = "Blocked";
                OrderStatusBorder.Background = Brushes.Red;
                OrderStatusBorder.BorderBrush = Brushes.Red;
            }

            _books = new Dictionary<Book, Tuple<int, decimal>>();
            foreach (var item in order.OrdersBooks)
            {
                _books.Add(item.Book, new Tuple<int, decimal>(item.Quantity, item.Quantity * item.UnitPrice));
            }

            ThisOrderBooks.ItemsSource = _books;
            UserFName = order.Fullname;
            DeliveryAddressText = order.DeliveryAddress;
            DeliveryCompanyText = order.DeliveryCompany.ToString();
            UserPhone = order.ContactPhone;

            if (order.PayStatus == PayStatus.Unpaid)
            {
                AddRadioButtons();
            }

            DataContext = this;
        }

        private int _orderNumber;
        public int OrderNumber
        {
            get { return _orderNumber; }
            set 
            { 
                _orderNumber = value;
                OnPropertyChanged(nameof(OrderNumber));
            }
        }

        private string _userFName;
        public string UserFName
        {
            get { return _userFName; }
            set
            {
                _userFName = value;
                OnPropertyChanged(nameof(UserFName));
            }
        }

        private string _deliveryAddressText;
        public string DeliveryAddressText
        {
            get { return _deliveryAddressText; }
            set
            {
                _deliveryAddressText = value;
                OnPropertyChanged(nameof(DeliveryAddressText));
            }
        }

        private string _deliveryCompanyText;
        public string DeliveryCompanyText
        {
            get { return _deliveryCompanyText; }
            set
            {
                _deliveryCompanyText = value;
                OnPropertyChanged(nameof(DeliveryCompanyText));
            }
        }

        private string _userPhone;
        public string UserPhone
        {
            get { return _userPhone; }
            set
            {
                _userPhone = value;
                OnPropertyChanged(nameof(UserPhone));
            }
        }

        private string _userEmail;
        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

        private decimal _orderPrice;
        public decimal OrderPrice
        {
            get { return _orderPrice; }
            set 
            { 
                _orderPrice = value;
                OnPropertyChanged(nameof(OrderPrice));
            }
        }

        private string _orderDate;
        public string OrderDate
        {
            get { return _orderDate; }
            set 
            { 
                _orderDate = value; 
                OnPropertyChanged(nameof(OrderDate));
            }
        }

        private string _pStatus;
        public string PStatus
        {
            get { return _pStatus; }
            set
            {
                _pStatus = value;
                OnPropertyChanged(nameof(PStatus));
            }
        }

        private string _payMethod;
        public string PayMethod
        {
            get { return _payMethod; }
            set
            {
                _payMethod = value;
                OnPropertyChanged(nameof(PayMethod));
            }
        }

        private string _cardToPay;
        public string CardToPay
        {
            get { return _cardToPay; }
            set
            {
                _cardToPay = value;
                OnPropertyChanged(nameof(CardToPay));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            GridDetails.Visibility = GridDetails.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            GridOrderPriceNoDetails.Visibility = GridOrderPriceNoDetails.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            WrapPanelOrderedBooks.Visibility = WrapPanelOrderedBooks.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            DetailsButtonIcon.Kind = DetailsButtonIcon.Kind == PackIconKind.ArrowDropDown ? PackIconKind.ArrowDropUp : PackIconKind.ArrowDropDown;
            PayBorder.Visibility = Visibility.Collapsed;
            PayButton.Visibility = PStatus == "Unpaid" ? Visibility.Visible : Visibility.Collapsed;
        }

        private void CardSwitched_Checked(object sender, RoutedEventArgs e)
        {
            CardToPay = null;
            if ((string)((RadioButton)sender).Content == "Add new card")
            {
                CardInfo.Visibility = Visibility.Visible;
                PayCancelPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                PayCancelPanel.Visibility = Visibility.Visible;
                CardInfo.Visibility = Visibility.Collapsed;
                CardToPay = (string)((RadioButton)sender).Content;
            }
        }

        private void AddRadioButtons()
        {
            Cards.Children.Clear();
            foreach (var card in _mainWindow.CurrentUser.Wallets)
            {
                var rb = new RadioButton()
                {
                    Content = card.CardNumber,
                    FontSize = 16,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10)
                };
                rb.Checked += new RoutedEventHandler(CardSwitched_Checked);

                Cards.Children.Add(rb);
            }
            var radioButton = new RadioButton()
            {
                Content = "Add new card",
                FontSize = 16,
                Foreground = Brushes.White,
                Margin = new Thickness(10),
            };

            radioButton.Checked += new RoutedEventHandler(CardSwitched_Checked);

            Cards.Children.Add(radioButton);

            ((RadioButton)Cards.Children[0]).IsChecked = true;
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            PayButton.Visibility = Visibility.Collapsed;
            PayBorder.Visibility = Visibility.Visible;
        }

        private void CardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CardNumber.Text.Length == CardNumber.MaxLength)
                ExpiryMonth.Focus();
        }

        private void ExpiryMonth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ExpiryMonth.Text.Length == ExpiryMonth.MaxLength)
                ExpiryYear.Focus();
        }

        private void ExpiryYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ExpiryYear.Text.Length == ExpiryYear.MaxLength)
                CVV.Focus();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            LoadingLine.IsRunning = true;
            LoadingLine.Visibility = Visibility.Visible;

            await _userService.AddNewCard(new()
            {
                UserId = _userId,
                CardNumber = CardNumber.Text,
                ExpiryDate = ExpiryMonth.Text + "/" + ExpiryYear.Text,
                CVV = CVV.Password
            });

            _mainWindow.CurrentUser.Wallets = await _userService.GetUserWallet(_mainWindow.CurrentUser.Id);
            _mainWindow.ThisUserCards.ItemsSource = null;
            _mainWindow.ThisUserCards.ItemsSource = _mainWindow.CurrentUser.Wallets;

            CardInfo.Visibility = Visibility.Collapsed;
            CardNumber.Text = string.Empty;
            ExpiryMonth.Text = string.Empty;
            ExpiryYear.Text = string.Empty;
            CVV.Password = string.Empty;

            foreach (UserOrderCard item in _mainWindow.Orders.Children)
            {
                item.AddRadioButtons();
            }

            LoadingLine.IsRunning = false;
            LoadingLine.Visibility = Visibility.Collapsed;
        }

        private async void Pay_Click(object sender, RoutedEventArgs e)
        {
            LoadingLine.IsRunning = true;
            LoadingLine.Visibility = Visibility.Visible;

            await _orderService.CompleteOrder(
                OrderNumber,
                _userId,
                OrderPrice,
                CardToPay,
                _books
                );

            OrderStatusBorder.Background = Brushes.Green;
            OrderStatusBorder.BorderBrush = Brushes.Green;
            _mainWindow.CurrentUser.Orders.First(x => x.Number == OrderNumber).PayStatus = PayStatus.Paid;
            PStatus = "Paid";
            Paystatus.Text = "Paid";
            PayBorder.Visibility = Visibility.Collapsed;

            LoadingLine.IsRunning = false;
            LoadingLine.Visibility = Visibility.Collapsed;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CardInfo.Visibility = Visibility.Collapsed;
            CardNumber.Text = string.Empty;
            ExpiryMonth.Text = string.Empty;
            ExpiryYear.Text = string.Empty;
            CVV.Password = string.Empty;
            PayBorder.Visibility = Visibility.Collapsed;
            PayButton.Visibility = Visibility.Visible;
        }
    }
}

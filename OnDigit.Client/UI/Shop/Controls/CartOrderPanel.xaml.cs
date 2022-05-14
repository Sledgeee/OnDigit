using OnDigit.Core.Models.BookModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows;
using OnDigit.Core.Models.OrderModel;
using System.Windows.Media;
using OnDigit.Core.Interfaces.Services;

#nullable disable

namespace OnDigit.Client.UI.Shop.Controls
{
    /// <summary>
    /// Interaction logic for CartOrderPanel.xaml
    /// </summary>
    ///
    public partial class CartOrderPanel : UserControl
    {
        private MainWindow _mainWindow;
        private int _orderNumber;
        private decimal _totalAmount;
        private string _cardToPay;
        private readonly IUserService _userService;

        public CartOrderPanel(int orderNumber, Dictionary<Book, Tuple<int, decimal>> items, MainWindow mainWindow, IUserService userService)
        {
            InitializeComponent();
            DataContext = this;

            _mainWindow = mainWindow;
            _userService = userService;
            OrderNumber = orderNumber;
            ThisOrderBooks.ItemsSource = items;
            TotalAmount = items.Values.Sum(x => x.Item2);
            AddRadioButtons();
        }

        public CartOrderPanel(Dictionary<Book, Tuple<int, decimal>> items, MainWindow mainWindow, IUserService userService) : this(1, items, mainWindow, userService)
        {
            CopyToOther.Visibility = Visibility.Collapsed;
        }

        public DeliveryCompany DeliveryCompany { get; set; }
        public string DeliveryAddress { get; set; }

        public int OrderNumber
        {
            get { return _orderNumber; }
            set 
            {
                _orderNumber = value;
                OnPropertyChanged(nameof(OrderNumber));
            }
        }

        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

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
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddRadioButtons()
        {
            Cards.Children.Clear();
            foreach (var wallet in _mainWindow.CurrentUser.Wallets)
            {
                var rb = new RadioButton()
                {
                    Content = wallet.CardNumber,
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

        private void CardSwitched_Checked(object sender, RoutedEventArgs e)
        {
            CardToPay = null;
            if ((string)((RadioButton)sender).Content == "Add new card")
            {
                CardInfo.Visibility = Visibility.Visible;
            }
            else
            {
                CardInfo.Visibility = Visibility.Collapsed;
                CardToPay = (string)((RadioButton)sender).Content;
            }
        }

        private void PaymentVariant_Checked(object sender, RoutedEventArgs e)
        {
            if ((string)((RadioButton)sender).Content == "Pay right now")
                PayRightNowGrid.Visibility = Visibility.Visible;
            else
                PayRightNowGrid.Visibility = Visibility.Collapsed;
        }

        private async void AddCard_Click(object sender, RoutedEventArgs e)
        {
            await _userService.AddNewCard(new()
            {
                UserId = _mainWindow.CurrentUser.Id,
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
            
            foreach(CartOrderPanel item in _mainWindow.WrapOrders.Children)
            {
                item.AddRadioButtons();
            }
        }

        private void CopyToOther_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _mainWindow.WrapOrders.Children)
            {
                var cartOrderPanel = item as CartOrderPanel;

                if (cartOrderPanel == this)
                    continue;

                cartOrderPanel.DeliveryAddressTextBox.Text = this.DeliveryAddressTextBox.Text;
                cartOrderPanel.DeliveryCompanyComboBox.SelectedIndex = this.DeliveryCompanyComboBox.SelectedIndex;
                cartOrderPanel.DeliveryCompanyComboBox.HorizontalContentAlignment = HorizontalAlignment.Left;
                cartOrderPanel.CardNumber.Text = this.CardNumber.Text;
                cartOrderPanel.ExpiryMonth.Text = this.ExpiryMonth.Text;
                cartOrderPanel.ExpiryYear.Text = this.ExpiryYear.Text;
                cartOrderPanel.CVV.Password = this.CVV.Password;
                cartOrderPanel.PayRightNowGrid.Visibility = this.PayRightNowGrid.Visibility;
                cartOrderPanel.PayLaterRB.IsChecked = this.PayLaterRB.IsChecked;
                cartOrderPanel.PayRightNowRB.IsChecked = this.PayRightNowRB.IsChecked;
                for (int i = 0; i < this.Cards.Children.Count; i++)
                {
                    ((RadioButton)cartOrderPanel.Cards.Children[i]).IsChecked = ((RadioButton)this.Cards.Children[i]).IsChecked;
                }
            }
        }

        private void DeliveryCompanyComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            switch (this.DeliveryCompanyComboBox.SelectedIndex)
            {
                case 0:
                    DeliveryCompany = DeliveryCompany.NovaPoshta;
                    break;
                case 1:
                    DeliveryCompany = DeliveryCompany.Ukrposhta;
                    break;
                case 2:
                    DeliveryCompany = DeliveryCompany.Justin;
                    break;
            }
        }

        private void DeliveryAddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DeliveryAddress = DeliveryAddressTextBox.Text;
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
    }
}

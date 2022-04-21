using JetBrains.Annotations;
using OnDigit.Core.Models.OrderModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OnDigit.Client.Windows.Shop.Controls
{
    /// <summary>
    /// Interaction logic for OrderCard.xaml
    /// </summary>
    public partial class OrderCard : UserControl
    {
        public OrderCard(Order order)
        {
            InitializeComponent();
            this.DataContext = this;
            _orderNumber = order.Number;
            _orderPrice = order.TotalPrice + "$";
            _orderDate = order.DateOrder.ToString("dd/MM/yyyy HH:mm:ss");

            foreach (var item in order.OrdersEditions)
            {
                OrderedEditions.Children.Add(new Image()
                {
                    Source = new BitmapImage(new Uri(item.Edition.ImageUri)),
                    Margin = new Thickness(7)
                });
            }
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

        private string _orderPrice;
        public string OrderPrice
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


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler is not null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using OnDigit.Core.Models.BookModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text.RegularExpressions;

#nullable disable

namespace OnDigit.Client.UI.Shop.Controls
{
    /// <summary>
    /// Interaction logic for CartBookCard.xaml
    /// </summary>
    public partial class CartBookCard : UserControl
    {
        private readonly Book _book;
        private readonly MainWindow _mainWindow;
        private readonly int _maxQuantity;

        public CartBookCard(MainWindow mainWindow, Book book, int quantity)
        {
            InitializeComponent();
            this.DataContext = this;
            _mainWindow = mainWindow;
            _maxQuantity = book.Package.Quantity;
            _book = book;
            BookName = book.Name;
            Price = "$" + book.Price;
            TotalSum = book.Price;
            ImageUri = book.ImageUri;
            BookQuantity.Text = quantity.ToString();
        }

        public decimal TotalSum { get; set; }

        private string _bookName;
        public string BookName
        {
            get { return _bookName; }
            set
            {
                _bookName = value;
                OnPropertyChanged(nameof(BookName));
            }
        }

        private string _price;
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }


        private string _imageUri;
        public string ImageUri
        {
            get { return _imageUri; }
            set
            {
                _imageUri = value;
                OnPropertyChanged(nameof(ImageUri));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = HandyControl.Controls.MessageBox.Show("Confirm removing chosen book from cart", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (dialogResult == MessageBoxResult.OK)
            {
                _mainWindow.UserCart.RemoveBook(_book);
                _mainWindow.UpdateCartSelection();
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            var val = int.Parse(BookQuantity.Text);

            if (val == _maxQuantity)
                return;

            _mainWindow.UserCart.TotalAmount -= _book.Price * val;
            val++;
            BookQuantity.Text = val.ToString();
            _mainWindow.UserCart.Books[_book] = val;
            _mainWindow.UserCart.TotalAmount += _book.Price * val;
            _mainWindow.CartTotalPrice.Text = "$" + _mainWindow.UserCart.TotalAmount;
            _mainWindow.CartBooksCount.Text = _mainWindow.UserCart.Books.Sum(x => x.Value).ToString();
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            var val = int.Parse(BookQuantity.Text);

            if (val == 1)
                return;

            _mainWindow.UserCart.TotalAmount -= _book.Price * val;
            val--;
            BookQuantity.Text = val.ToString();
            _mainWindow.UserCart.Books[_book] = val;
            _mainWindow.UserCart.TotalAmount += _book.Price * val;
            _mainWindow.CartTotalPrice.Text = "$" + _mainWindow.UserCart.TotalAmount;
            _mainWindow.CartBooksCount.Text = _mainWindow.UserCart.Books.Sum(x => x.Value).ToString();
        }

        private void BookQuantity_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BookQuantity_GotFocus(object sender, RoutedEventArgs e)
        {
            BookQuantity.CaretIndex = BookQuantity.Text.Length;
        }

        private void BookQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BookQuantity.Text.StartsWith('0') || BookQuantity.Text.Length == 0)
            {
                BookQuantity.Text = "1";
                BookQuantity.CaretIndex = BookQuantity.Text.Length;
            }

            else if (int.Parse(BookQuantity.Text) > _maxQuantity)
            {
                BookQuantity.Text = _maxQuantity.ToString();
                BookQuantity.CaretIndex = BookQuantity.Text.Length;
            }

            else if (int.Parse(BookQuantity.Text) < 1)
            {
                BookQuantity.Text = "1";
                BookQuantity.CaretIndex = BookQuantity.Text.Length;
            }
        }
    }
}

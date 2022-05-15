using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using OnDigit.Core.Models.BookModel;
using MaterialDesignThemes.Wpf;
using OnDigit.Core.Interfaces.Services;
using System.Windows.Media.Effects;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.UserModel;
using System.Windows.Media;
using System.Windows;

#nullable disable

namespace OnDigit.Client.UI.Shop.Controls
{
    /// <summary>
    /// Interaction logic for ShopBookCard.xaml
    /// </summary>
    public partial class ShopBookCard : UserControl
    {
        private readonly Book _book;
        private readonly MainWindow _mainWindow;
        private readonly User _currentUser;
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        private bool _isFavorite;

        public ShopBookCard(MainWindow mainWindow, 
            Book book, 
            User currentUser, 
            IReviewService reviewService,  
            IUserService userService,
            bool isShopTab)
        {
            InitializeComponent();
            this.DataContext = this;

            _mainWindow = mainWindow;
            _currentUser = currentUser;
            _reviewService = reviewService;
            _userService = userService;
            _book = book;
            BookName = book.Name;
            BookPrice = book.Price;

            if (book.Discount > 0)
            {
                BookPriceDiscounted = Math.Round(BookPrice - (BookPrice * book.Discount / 100m), 2);
                BPrice.FontSize = 14;
                BPrice.TextDecorations = TextDecorations.Strikethrough;
                BPrice.Foreground = Brushes.Gray;
            }
            else
            {
                BPriceDiscounted.Visibility = Visibility.Collapsed;
            }

            RatingCount = book.Reviews.Count;
            ImageUri = book.ImageUri;

            string trailer = "_" + _book.Id.Replace("-", "");
            icon_favorites.Name += trailer;

            if (_book.UserFavorites.Contains(new()
            {
                Book = _book,
                BookId = _book.Id,
                User = _currentUser,
                UserId = _currentUser.Id
            }))
            {
                _isFavorite = true;
                icon_favorites.Kind = PackIconKind.Heart;
                if (isShopTab)
                    _mainWindow.CurrentUser.UserFavorites.Add(new()
                    {
                        Book = book,
                        BookId = book.Id,
                        User = _currentUser,
                        UserId = _currentUser.Id
                    });
            }

            if (_mainWindow.UserCart.Books.ContainsKey(book))
            {
                icon_cart.Kind = PackIconKind.Cart;
            }

            button_favorites.Name += trailer;
            button_favorites.Click += AddToFavorites_Click;
            SetStars(book.Rating);
            SetWarehouseStatus();
        }

        public void SetWarehouseStatus()
        {
            if (_book.Package.Quantity > 200)
            {
                WarehouseStatus.Text = "Available";
                WarehouseStatusIcon.Kind = PackIconKind.TruckFast;
                WarehouseStatus.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF00A912");
                WarehouseStatusIcon.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF00A912");
            }
            else if (_book.Package.Quantity > 0)
            {
                WarehouseStatus.Text = "Ends";
                WarehouseStatusIcon.Kind = PackIconKind.TruckFast;
                WarehouseStatus.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFC50101");
                WarehouseStatusIcon.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFC50101");
            }
            else
            {
                WarehouseStatus.Text = "Not available";
                WarehouseStatus.Foreground = Brushes.Gray;
                WarehouseStatusIcon.Kind = PackIconKind.None;
                AddToCartButton.Visibility = Visibility.Collapsed;
            }
        }

        public void SetStars(float rating)
        {
            if (rating == 0)
                return;

            else if (rating > 0 && rating < 1)
                star_1.Kind = PackIconKind.StarHalfFull;

            else if (rating == 1)
                star_1.Kind = PackIconKind.Star;

            else if (rating > 1 && rating < 2)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.StarHalfFull;
            }

            else if (rating == 2)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
            }

            else if (rating > 2 && rating < 3)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.StarHalfFull;
            }

            else if (rating == 3)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;

            }

            else if (rating > 3 && rating < 4)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.StarHalfFull;
            }

            else if (rating == 4)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
            }

            else if (rating == 5)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
                star_5.Kind = PackIconKind.Star;
            }

            else if (rating > 4 && rating < 5)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
                star_5.Kind = PackIconKind.StarHalfFull;
            }
        }

        public void UpdateRating(int ratingCount)
        {
            _ratingCount = ratingCount;
            tbRatingCount.Text = ratingCount.ToString();
        }

        public void UpdateCartIcon(PackIconKind kind)
        {
            icon_cart.Kind = kind;
        }

        public void UpdateFavoriteStatus(PackIconKind kind)
        {
            icon_favorites.Kind = kind;

            if (kind == PackIconKind.Heart)
                _isFavorite = true;
            else
                _isFavorite = false;
        }

        private void ShowBookInfoWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.Effect = new BlurEffect();
            new BookInfoWindow(_book, _currentUser, _reviewService, _userService, _mainWindow, this, _isFavorite).ShowDialog();
            _mainWindow.Effect = null;
        }

        private async void AddToFavorites_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button is not null)
                if (icon_favorites.Kind == PackIconKind.HeartOutline)
                {
                    icon_favorites.Kind = PackIconKind.Heart;
                    _isFavorite = true;
                    _book.UserFavorites.Add(new() { Book = _book, BookId = _book.Id, UserId = _currentUser.Id, User = _currentUser });
                    await _userService.SetFavoriteBookAsync(_currentUser.Id, _book.Id);
                }
                else
                {
                    icon_favorites.Kind = PackIconKind.HeartOutline;
                    _isFavorite = false;
                    _book.UserFavorites.Remove(new() { Book = _book, BookId = _book.Id, UserId = _currentUser.Id, User = _currentUser });
                    await _userService.DeleteFavoriteBookAsync(_currentUser.Id, _book.Id);
                }
        }

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

        private decimal _bookPrice;
        public decimal BookPrice
        {
            get { return _bookPrice; }
            set
            {
                _bookPrice = value;
                OnPropertyChanged(nameof(BookPrice));
            }
        }

        private decimal _bookPriceDiscounted;
        public decimal BookPriceDiscounted
        {
            get { return _bookPriceDiscounted; }
            set
            {
                _bookPriceDiscounted = value;
                OnPropertyChanged(nameof(BookPriceDiscounted));
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

        private int _ratingCount;
        public int RatingCount
        {
            get { return _ratingCount; }
            set 
            {
                _ratingCount = value; 
                OnPropertyChanged(nameof(RatingCount));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddToCart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (button is not null)
                if (icon_cart.Kind == PackIconKind.CartOutline)
                {
                    icon_cart.Kind = PackIconKind.Cart;
                    _mainWindow.UserCart.AddBook(_book, 1);
                }
                else
                {
                    icon_cart.Kind = PackIconKind.CartOutline;
                    _mainWindow.UserCart.RemoveBook(_book);
                }
        }
    }
}

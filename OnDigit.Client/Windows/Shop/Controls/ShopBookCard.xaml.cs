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

namespace OnDigit.Client.Windows.Shop.Controls
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

        public ShopBookCard(MainWindow mainWindow, 
            Book book, 
            User currentUser, 
            IReviewService reviewService,  
            IUserService userService)
        {
            InitializeComponent();
            this.DataContext = this;

            _mainWindow = mainWindow;
            _currentUser = currentUser;
            _reviewService = reviewService;
            _userService = userService;
            _book = book;
            _bookName = book.Name;
            _bookPrice = "$" + book.Price;
            _ratingCount = book.Reviews.Count;
            _imageUri = book.ImageUri;

            string trailer = "_" + _book.Id.Replace("-", "");
            icon_favorites.Name += trailer;

            if (_book.UserFavorites.Contains(new UserFavorite()
            {
                Book = _book,
                BookId = _book.Id,
                UserId = _currentUser.Id,
                User = null
            }))
            {
                icon_favorites.Kind = PackIconKind.Heart;
            }

            if (_mainWindow.UserCart.Books.ContainsKey(book))
            {
                icon_cart.Kind = PackIconKind.Cart;
            }

            button_favorites.Name += trailer;
            button_favorites.Click += ButtonOnClick;
            SetStars(book.Rating);
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

        private void ShowBookInfoWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.Effect = new BlurEffect();
            new BookInfoWindow(_book, _currentUser, _reviewService, _mainWindow, this).ShowDialog();
            _mainWindow.Effect = null;
        }

        private async void ButtonOnClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button is not null)
                if (icon_favorites.Kind == PackIconKind.HeartOutline)
                {
                    await _userService.SetFavoriteBookAsync(_currentUser.Id, _book.Id);
                    _book.UserFavorites.Add(new UserFavorite() { Book = _book, BookId = _book.Id, UserId = _currentUser.Id, User = null });
                    icon_favorites.Kind = PackIconKind.Heart;
                }
                else
                {
                    await _userService.DeleteFavoriteBookAsync(_currentUser.Id, _book.Id);
                    _book.UserFavorites.Remove(new UserFavorite() { Book = _book, BookId = _book.Id, UserId = _currentUser.Id, User = null });
                    icon_favorites.Kind = PackIconKind.HeartOutline;
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

        private string _bookPrice;
        public string BookPrice
        {
            get { return _bookPrice; }
            set
            {
                _bookPrice = value;
                OnPropertyChanged(nameof(BookPrice));
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler is not null)
                handler(this, new PropertyChangedEventArgs(propertyName));
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

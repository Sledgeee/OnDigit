using MaterialDesignThemes.Wpf;
using OnDigit.Client.UI.Shop.Controls;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.UserModel;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

#nullable disable

namespace OnDigit.Client.UI.Shop
{
    /// <summary>
    /// Interaction logic for BookInfoWindow.xaml
    /// </summary>
    public partial class BookInfoWindow : Window
    {
        private readonly Book _book;
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        private readonly User _currentUser;
        private readonly MainWindow _mainWindow;
        private readonly ShopBookCard _shopBookCard;
        private string _bookName;
        private string _price;
        private string _description;
        private string _genre;
        private string _imageUri;
        private int _ratingCount;

        public BookInfoWindow(Book book,
                              User currentUser,
                              IReviewService reviewService,
                              IUserService userService,
                              MainWindow mainWindow,
                              ShopBookCard shopBookCard,
                              bool isFavorite)
        {
            InitializeComponent();
            this.DataContext = this;
            _book = book;
            _reviewService = reviewService;
            _userService = userService;
            _currentUser = currentUser;
            _mainWindow = mainWindow;
            _shopBookCard = shopBookCard;
            if (isFavorite)
            {
                icon_favorites.Kind = PackIconKind.Heart;
            }
            Initialize();
        }

        private async void Initialize()
        {
            BookName = _book.Name;
            Description = _book.Description;
            Price = "$" + _book.Price;
            ImageUri = _book.ImageUri;
            Genre = _book.Genre.Name;

            if (_mainWindow.UserCart.Books.ContainsKey(_book))
            {
                AddToCartCheck.Visibility = Visibility.Visible;
                AddToCart.Content = "Remove from cart";
            }

            SetStars(_book.Rating);

            SetWarehouseStatus();

            RatingCount = _book.Reviews.Count;

            _book.Reviews = await _reviewService.GetReviewsListAsync(_book.Id);

            foreach(var item in _book.Reviews.OrderByDescending(x => x.DateCreated))
                ReviewsPanel.Children.Add(new BookReviewCard(item.User.Name + " " + item.User.Surname, item.Text, item.Stars));
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
                AddToCart.Visibility = Visibility.Collapsed;
            }
        }

        public void UpdateBookInfo(Book book, Review review, User user)
        {
            review.User = user;
            SetStars(book.Rating);
            _book.Reviews.Add(review);
            RatingCount = _book.Reviews.Count;
            tbRatingCount.Text = _ratingCount.ToString();
            tbReviewCount.Text = _ratingCount.ToString();
            _shopBookCard.SetStars(book.Rating);
            _shopBookCard.UpdateRating(book.Reviews.Count);

            ReviewsPanel.Children.Clear();

            var collection = _book.Reviews.OrderByDescending(x => x.DateCreated);

            foreach (var item in collection)
                ReviewsPanel.Children.Add(new BookReviewCard(item.User.Name + " " + item.User.Surname, item.Text, item.Stars));
        }

        private void SetStars(float rating)
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

        public string BookName
        {
            get { return _bookName; }
            set 
            {
                _bookName = value; 
                OnPropertyChanged(nameof(BookName));
            }
        }

        public string Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        public int RatingCount
        {
            get { return _ratingCount; }
            set
            {
                _ratingCount = value;
                OnPropertyChanged(nameof(RatingCount));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

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
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateReview_Click(object sender, RoutedEventArgs e)
        {
            this.Effect = new BlurEffect();
            new CreateReviewWindow(this, _reviewService, _currentUser, _book).ShowDialog();
            this.Effect = null;
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            if (AddToCart.Content is "Add to cart")
            {
                AddToCart.Content = "Remove from cart";
                AddToCartCheck.Visibility = Visibility.Visible;
                _shopBookCard.UpdateCartIcon(PackIconKind.Cart);
                _mainWindow.UserCart.AddBook(_book, 1);
            }
            else
            {
                AddToCart.Content = "Add to cart";
                AddToCartCheck.Visibility = Visibility.Collapsed;
                _shopBookCard.UpdateCartIcon(PackIconKind.CartOutline);
                _mainWindow.UserCart.RemoveBook(_book);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private async void AddToFavorites_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (button is not null)
                if (icon_favorites.Kind == PackIconKind.HeartOutline)
                {
                    await _userService.SetFavoriteBookAsync(_currentUser.Id, _book.Id);
                    _book.UserFavorites.Add(new UserFavorite() { Book = _book, BookId = _book.Id, UserId = _currentUser.Id, User = null });
                    icon_favorites.Kind = PackIconKind.Heart;
                    _shopBookCard.UpdateFavoriteStatus(PackIconKind.Heart);
                }
                else
                {
                    await _userService.DeleteFavoriteBookAsync(_currentUser.Id, _book.Id);
                    _book.UserFavorites.Remove(new UserFavorite() { Book = _book, BookId = _book.Id, UserId = _currentUser.Id, User = null });
                    icon_favorites.Kind = PackIconKind.HeartOutline;
                    _shopBookCard.UpdateFavoriteStatus(PackIconKind.HeartOutline);
                }
        }
    }
}

using JetBrains.Annotations;
using MaterialDesignThemes.Wpf;
using OnDigit.Client.Windows.Shop.Controls;
using OnDigit.Core.Genres;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.UserModel;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Effects;

namespace OnDigit.Client.Windows.Shop
{
    /// <summary>
    /// Interaction logic for BookInfoWindow.xaml
    /// </summary>
    public partial class BookInfoWindow : Window
    {
        private readonly Edition _edition;
        private readonly IReviewService _reviewService;
        private readonly User _currentUser;
        private readonly MainWindow _mainWindow;
        private readonly ShopEditionCard _shopEditionCard;

        public BookInfoWindow(Edition edition,
                              User currentUser,
                              IReviewService reviewService,
                              MainWindow mainWindow,
                              ShopEditionCard shopEditionCard)
        {
            InitializeComponent();
            this.DataContext = this;
            _edition = edition;
            _reviewService = reviewService;
            _currentUser = currentUser;
            _mainWindow = mainWindow;
            _shopEditionCard = shopEditionCard;
            Initialize();
        }

        private void Initialize()
        {
            _bookName = _edition.Name;
            _description = _edition.Description;
            _price = _edition.Price + "$";
            _imageUri = _edition.ImageUri;
            _genre = typeof(Genres).GetFields().Where(x => x.IsLiteral).Select(x => x.Name).ToArray()[_edition.GenreId - 1].Replace("_", " ");

            if (_mainWindow.UserCart.Editions.Contains(_edition))
            {
                AddToCartCheck.Visibility = Visibility.Visible;
                AddToCart.Content = "Remove from cart";
            }

            SetStars(_edition.Rating);

            _ratingCount = _edition.Reviews.Count;

            var collection = _edition.Reviews.OrderByDescending(x => x.DateCreated);

            foreach(var item in collection)
                ReviewsPanel.Children.Add(new BookReviewCard(item.User.Name + " " + item.User.Surname, item.Text, item.Stars));
        }

        public void UpdateBookInfo(Edition edition, Review review, User user)
        {
            review.User = user;
            SetStars(edition.Rating);
            _edition.Reviews.Add(review);
            _ratingCount = _edition.Reviews.Count;
            tbRatingCount.Text = _ratingCount.ToString();
            tbReviewCount.Text = _ratingCount.ToString();
            _shopEditionCard.SetStars(edition.Rating);
            _shopEditionCard.UpdateRating(edition.Reviews.Count);

            ReviewsPanel.Children.Clear();

            var collection = _edition.Reviews.OrderByDescending(x => x.DateCreated);

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

        private string _genre;

        public string Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
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

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler is not null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateReview_Click(object sender, RoutedEventArgs e)
        {
            this.Effect = new BlurEffect();
            new CreateReviewWindow(this, _reviewService, _currentUser, _edition).ShowDialog();
            this.Effect = null;
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            if (AddToCart.Content is "Add to cart")
            {
                AddToCart.Content = "Remove from cart";
                AddToCartCheck.Visibility = Visibility.Visible;
                _mainWindow.UserCart.AddEdition(_edition);
            }
            else
            {
                AddToCart.Content = "Add to cart";
                AddToCartCheck.Visibility = Visibility.Collapsed;
                _mainWindow.UserCart.RemoveEdition(_edition);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}

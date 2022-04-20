using JetBrains.Annotations;
using OnDigit.Client.Windows.Shop.Controls;
using OnDigit.Core.Genres;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.EditionModel;
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
        private readonly string _userId;
        private readonly MainWindow _mainWindow;

        public BookInfoWindow(Edition edition, string userId, IReviewService reviewService, MainWindow mainWindow)
        {
            InitializeComponent();
            this.DataContext = this;
            _edition = edition;
            _reviewService = reviewService;
            _userId = userId;
            _mainWindow = mainWindow;
            Initialize();
        }

        private void Initialize()
        {
            _bookName = _edition.Name;
            _description = _edition.Description;
            _price = _edition.Price + "$";
            _imageUri = _edition.ImageUri;
            _ratingCount = _edition.RatingCount;
            _genre = typeof(Genres).GetFields().Where(x => x.IsLiteral).Select(x => x.Name).ToArray()[_edition.GenreId - 1].Replace("_", " ");

            if (_mainWindow.UserCart.Editions.Contains(_edition))
            {
                AddToCartCheck.Visibility = Visibility.Visible;
                AddToCart.Content = "Remove from cart";
            }

            ReviewsPanel.Children.Add(new BookReviewCard());
            ReviewsPanel.Children.Add(new BookReviewCard());
            ReviewsPanel.Children.Add(new BookReviewCard());
            ReviewsPanel.Children.Add(new BookReviewCard());
            ReviewsPanel.Children.Add(new BookReviewCard());
            ReviewsPanel.Children.Add(new BookReviewCard());
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
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
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
            new CreateReviewWindow(_reviewService, _userId).ShowDialog();
            this.Effect = null;
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            if (AddToCart.Content is "Add to cart")
            {
                _mainWindow.UserCart.AddEdition(_edition);
                _mainWindow.CartWrap.Children.Add(new CartEditionCard(_mainWindow.UserCart, _edition));
                AddToCartCheck.Visibility = Visibility.Visible;
                AddToCart.Content = "Remove from cart";
            }
            else
            {
                AddToCart.Content = "Add to cart";
                AddToCartCheck.Visibility = Visibility.Collapsed;
                _mainWindow.CartWrap.Children.Remove(new CartEditionCard(_mainWindow.UserCart, _edition));
            }
        }
    }
}

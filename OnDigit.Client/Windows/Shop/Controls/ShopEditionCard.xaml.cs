using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using OnDigit.Core.Models.EditionModel;
using MaterialDesignThemes.Wpf;
using OnDigit.Core.Interfaces.Services;
using System.Windows.Media.Effects;

namespace OnDigit.Client.Windows.Shop.Controls
{
    /// <summary>
    /// Interaction logic for ShopEditionCard.xaml
    /// </summary>
    public partial class ShopEditionCard : UserControl
    {
        private readonly Edition _edition;
        private readonly MainWindow _mainWindow;
        private readonly string _userId;
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;

        public ShopEditionCard(MainWindow reference, Edition edition, bool isFavorite, string userId, IReviewService reviewService, IUserService userService)
        {
            InitializeComponent();
            this.DataContext = this;
            _mainWindow = reference;
            _userId = userId;
            _reviewService = reviewService;
            _userService = userService;
            _edition = edition;
            _editionName = edition.Name;
            _editionPrice = edition.Price.ToString() + "$";
            _ratingCount = edition.RatingCount;
            _imageUri = edition.ImageUri;

            string trailer = "_" + _edition.Id.Replace("-", "");
            icon_favorites.Name += trailer;
            if (isFavorite is true)
                icon_favorites.Kind = PackIconKind.Heart;

            button_favorites.Name += trailer;
            button_favorites.Click += ButtonOnClick;
            SetStars();
        }

        private void SetStars()
        {
            if (_edition.Rating == 0)
                return;

            else if (_edition.Rating == 1)
                star_1.Kind = PackIconKind.Star;

            else if (_edition.Rating == 2)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
            }

            else if (_edition.Rating == 3)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;

            }

            else if (_edition.Rating == 4)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
            }

            else if (_edition.Rating == 5)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
                star_5.Kind = PackIconKind.Star;
            }

            else if (_edition.Rating > 0 && _edition.Rating < 1)
                star_1.Kind = PackIconKind.StarHalfFull;

            else if (_edition.Rating > 1 && _edition.Rating < 2)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.StarHalfFull;
            }

            else if (_edition.Rating > 2 && _edition.Rating < 3)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.StarHalfFull;
            }

            else if (_edition.Rating > 3 && _edition.Rating < 4)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.StarHalfFull;
            }

            else if (_edition.Rating > 4 && _edition.Rating < 5)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
                star_5.Kind = PackIconKind.StarHalfFull;
            }
        }

        private async void ButtonOnClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button is not null)
                if (icon_favorites.Kind == PackIconKind.HeartOutline)
                {
                    await _userService.SetFavoriteEditionAsync(_userId, _edition.Id);
                    icon_favorites.Kind = PackIconKind.Heart;
                }
                else
                {
                    await _userService.DeleteFavoriteEditionAsync(_userId, _edition.Id);
                    icon_favorites.Kind = PackIconKind.HeartOutline;
                }
        }

        private string _editionName;
        public string EditionName
        {
            get { return _editionName; }
            set
            {
                _editionName = value;
                OnPropertyChanged(nameof(EditionName));
            }
        }

        private string _editionPrice;
        public string EditionPrice
        {
            get { return _editionPrice; }
            set
            {
                _editionPrice = value;
                OnPropertyChanged(nameof(EditionPrice));
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

        private void ShowBookInfoWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.Effect = new BlurEffect();
            new BookInfoWindow(_edition, _userId, _reviewService).ShowDialog();
            _mainWindow.Effect = null;
        }
    }
}

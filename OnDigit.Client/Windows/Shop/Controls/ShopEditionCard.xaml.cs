﻿using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using OnDigit.Core.Models.EditionModel;
using MaterialDesignThemes.Wpf;
using OnDigit.Core.Interfaces.Services;
using System.Windows.Media.Effects;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Client.Windows.Shop.Controls
{
    /// <summary>
    /// Interaction logic for ShopEditionCard.xaml
    /// </summary>
    public partial class ShopEditionCard : UserControl
    {
        private readonly Edition _edition;
        private readonly MainWindow _mainWindow;
        private readonly User _currentUser;
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;

        public ShopEditionCard(MainWindow mainWindow, 
            Edition edition, 
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
            _edition = edition;
            _editionName = edition.Name;
            _editionPrice = edition.Price.ToString() + "$";
            _ratingCount = edition.Reviews.Count;
            _imageUri = edition.ImageUri;

            string trailer = "_" + _edition.Id.Replace("-", "");
            icon_favorites.Name += trailer;

            if (_edition.UserFavorites.Contains(new UserFavorite()
            {
                Edition = _edition,
                EditionId = _edition.Id,
                UserId = _currentUser.Id,
                User = null
            }))
            {
                icon_favorites.Kind = PackIconKind.Heart;
            }

            button_favorites.Name += trailer;
            button_favorites.Click += ButtonOnClick;
            SetStars(edition.Rating);
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

        private void ShowBookInfoWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.Effect = new BlurEffect();
            new BookInfoWindow(_edition, _currentUser, _reviewService, _mainWindow, this).ShowDialog();
            _mainWindow.Effect = null;
        }

        private async void ButtonOnClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button is not null)
                if (icon_favorites.Kind == PackIconKind.HeartOutline)
                {
                    await _userService.SetFavoriteEditionAsync(_currentUser.Id, _edition.Id);
                    _edition.UserFavorites.Add(new UserFavorite() { Edition = _edition, EditionId = _edition.Id, UserId = _currentUser.Id, User = null });
                    icon_favorites.Kind = PackIconKind.Heart;
                }
                else
                {
                    await _userService.DeleteFavoriteEditionAsync(_currentUser.Id, _edition.Id);
                    _edition.UserFavorites.Remove(new UserFavorite() { Edition = _edition, EditionId = _edition.Id, UserId = _currentUser.Id, User = null });
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
    }
}

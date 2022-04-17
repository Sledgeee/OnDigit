using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using OnDigit.Core.Models.EditionModel;
using MaterialDesignThemes.Wpf;

namespace OnDigit.Client.Windows.Shop.Controls
{
    /// <summary>
    /// Interaction logic for ShopEditionCard.xaml
    /// </summary>
    public partial class ShopEditionCard : UserControl
    {
        private readonly Edition _edition;

        public ShopEditionCard(Edition edition, bool IsFavorite)
        {
            InitializeComponent();
            this.DataContext = this;
            _edition = edition;
            _editionName = edition.Name;
            _editionPrice = edition.Price.ToString() + "$";

            // controls setings
            string trailer = "_" + edition.Id.Replace("-", "");
            icon_favorites.Name += trailer;
            
            if (IsFavorite is true)
                icon_favorites.Kind = PackIconKind.Heart;

            button_favorites.Name += trailer;
            button_favorites.Click += ButtonOnClick;

            SetStars();
        }        

        private void ButtonOnClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button is not null)
                if (icon_favorites.Kind == PackIconKind.HeartOutline)
                    icon_favorites.Kind = PackIconKind.Heart;
 
                else
                    icon_favorites.Kind = PackIconKind.HeartOutline;
        }

        private string _editionName;
        public string EditionName
        {
            get { return _editionName; }
            set
            {
                _editionName = value;
                OnPropertyChanged("EditionName");
            }
        }

        private string _editionPrice;
        public string EditionPrice
        {
            get { return _editionPrice; }
            set
            {
                _editionPrice = value;
                OnPropertyChanged("EditionPrice");
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

        private void SetStars()
        {
            if (_edition.AverageStars == 0)
                return;

            else if (_edition.AverageStars == 1)
                star_1.Kind = PackIconKind.Star;

            else if (_edition.AverageStars == 2)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
            }

            else if (_edition.AverageStars == 3)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;

            }

            else if (_edition.AverageStars == 4)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
            }

            else if (_edition.AverageStars == 5)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
                star_5.Kind = PackIconKind.Star;
            }

            else if (_edition.AverageStars > 0 && _edition.AverageStars < 1)
                star_1.Kind = PackIconKind.StarHalfFull;

            else if (_edition.AverageStars > 1 && _edition.AverageStars < 2)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.StarHalfFull;
            }

            else if (_edition.AverageStars > 2 && _edition.AverageStars < 3)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.StarHalfFull;
            }

            else if (_edition.AverageStars > 3 && _edition.AverageStars < 4)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.StarHalfFull;
            }

            else if (_edition.AverageStars > 4 && _edition.AverageStars < 5)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
                star_5.Kind = PackIconKind.StarHalfFull;
            }
        }
    }
}

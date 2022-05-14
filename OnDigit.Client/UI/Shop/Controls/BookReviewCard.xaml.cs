using JetBrains.Annotations;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace OnDigit.Client.UI.Shop.Controls
{
    /// <summary>
    /// Interaction logic for BookReviewCard.xaml
    /// </summary>
    public partial class BookReviewCard : UserControl
    {
        public BookReviewCard(string userFullname, string reviewText, int stars)
        {
            InitializeComponent();
            this.DataContext = this;
            _userFullname = userFullname;
            _reviewText = reviewText;
            SetStars(stars);
        }

        private void SetStars(int stars)
        {
            if (stars == 0)
                return;

            else if (stars > 0 && stars < 1)
                star_1.Kind = PackIconKind.StarHalfFull;

            else if (stars == 1)
                star_1.Kind = PackIconKind.Star;

            else if (stars > 1 && stars < 2)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.StarHalfFull;
            }

            else if (stars == 2)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
            }

            else if (stars > 2 && stars < 3)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.StarHalfFull;
            }

            else if (stars == 3)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;

            }

            else if (stars > 3 && stars < 4)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.StarHalfFull;
            }

            else if (stars == 4)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
            }

            else if (stars == 5)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
                star_5.Kind = PackIconKind.Star;
            }

            else if (stars > 4 && stars < 5)
            {
                star_1.Kind = PackIconKind.Star;
                star_2.Kind = PackIconKind.Star;
                star_3.Kind = PackIconKind.Star;
                star_4.Kind = PackIconKind.Star;
                star_5.Kind = PackIconKind.StarHalfFull;
            }
        }

        private string _userFullname;
        public string UserFullname
        {
            get { return _userFullname; }
            set
            {
                _userFullname = value;
                OnPropertyChanged(nameof(UserFullname));
            }
        }

        private string _reviewText;
        public string ReviewText
        {
            get { return _reviewText; }
            set
            {
                _reviewText = value;
                OnPropertyChanged(nameof(ReviewText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

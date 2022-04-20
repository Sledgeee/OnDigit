using JetBrains.Annotations;
using OnDigit.Core.Models.CartModel;
using OnDigit.Core.Models.EditionModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace OnDigit.Client.Windows.Shop.Controls
{
    /// <summary>
    /// Interaction logic for CartEditionCard.xaml
    /// </summary>
    public partial class CartEditionCard : UserControl
    {
        private readonly Cart _cart;
        private readonly Edition _edition;
        public CartEditionCard(Cart cart, Edition edition)
        {
            InitializeComponent();
            this.DataContext = this;
            _cart = cart;
            _edition = edition;
            _editionName = edition.Name;
            _price = edition.Price + "$";
            _imageUri = edition.ImageUri;
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

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            _cart.Editions.Remove(_edition);
        }
    }
}

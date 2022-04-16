using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using OnDigit.Client.Windows.Auth;
using OnDigit.Client.Windows.Shop.Controls;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.UserFavoritesModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Client
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IShopService _shopService;
        private readonly IUserService _userService;

        public MainWindow(IAuthenticationService authenticationService, IShopService shopService, IUserService userService)
        {
            InitializeComponent();
            _currentUser = null;
            UserFullname.Text = string.Empty;
            _authenticationService = authenticationService;
            _shopService = shopService;
            _userService = userService;
            Initialize();
        }

        private async void Initialize()
        {
            Spinner.IsLoading = true;
            await Task.Delay(1500);
            var editionList = await _shopService.GetAllEditionsAsync();
            ICollection<UserFavorites> userFavorites = null;
            if (_currentUser != null)
                userFavorites = await _userService.GetFavoriteEditionsAsync(_currentUser.Id);

            bool isFavorite = false;
            foreach (var edition in editionList)
            {
                if (userFavorites != null)
                    if (userFavorites.Contains(new UserFavorites() { UserId = _currentUser?.Id, EditionId = edition.Id }))
                        isFavorite = true;

                ShopMain.Children.Add(new ShopEditionCard(edition, isFavorite));
                isFavorite = false;
            }
            editionList.Clear();
            Spinner.IsLoading = false;
        }

        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            set 
            { 
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        //    UserControl usc = null;
        //    GridMain.Children.Clear();

        //    switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
        //    {
        //        case "ItemFilterBooks":
        //            usc = new UserControlHome();
        //            GridMain.Children.Add(usc);
        //            break;
        //        case "ItemMyOrders":
        //            usc = new UserControlCreate();
        //            GridMain.Children.Add(usc);
        //            break;
        //        default:
        //            break;
        //    }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginedState.Visibility = Visibility.Collapsed;
            UnloginedState.Visibility = Visibility.Visible;
            UserFullname.Text = string.Empty;
        }

        private void SignInDialog_Click(object sender, RoutedEventArgs e)
        {
            this.Effect = new BlurEffect();
            new SignIn(this, _authenticationService)
            {
                Topmost = true
            }.ShowDialog();
            this.Effect = null;

            if (_currentUser != null)
            {
                UserFullname.Text = _currentUser.Name + " " + _currentUser.Surname;
                UnloginedState.Visibility = Visibility.Collapsed;
                LoginedState.Visibility = Visibility.Visible;
            }
        }

        private void SignUpDialog_Click(object sender, RoutedEventArgs e)
        {
            this.Effect = new BlurEffect();
            new SignUp(this, _authenticationService).ShowDialog();
            this.Effect = null;
            if (_currentUser != null)
            {
                UserFullname.Text = _currentUser.Name + " " + _currentUser.Surname;
                UnloginedState.Visibility = Visibility.Collapsed;
                LoginedState.Visibility = Visibility.Visible;
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ShutdownApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

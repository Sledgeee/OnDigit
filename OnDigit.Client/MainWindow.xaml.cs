using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;
using OnDigit.Client.Windows.Auth;
using OnDigit.Client.Windows.Shop.Controls;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.UserFavoriteModel;
using OnDigit.Core.Models.UserModel;
using Microsoft.Win32;
using OnDigit.Core.Models.SessionModel;
using OnDigit.Core.Models.EditionModel;

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
        private readonly IReviewService _reviewService;
        private Session _currentSession;

        public MainWindow(IAuthenticationService authenticationService, IShopService shopService, IUserService userService, IReviewService reviewService)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
            _shopService = shopService;
            _userService = userService;
            _reviewService = reviewService;
            Initialize();
        }

        private async void Initialize()
        {
            _currentUser = null;
            UserFullname.Text = string.Empty;
            if (await CheckOnSession())
                LoadBooks(await _shopService.GetAllEditionsAsync());
            else
            {
                SignInDialog();
            }
        }

        private void SpinnersPropsChange(string spinner, bool spin, Visibility visibility)
        {
            switch(spinner)
            {
                case "SpinnerBooks":
                    SpinnerBooks_1.Spin = spin;
                    SpinnerBooks_2.Spin = spin;
                    SpinnerBooks_1.Visibility = visibility;
                    SpinnerBooks_2.Visibility = visibility;
                    break;
                case "SpinnerSession":
                    SpinnerSession_1.Spin = spin;
                    SpinnerSession_2.Spin = spin;
                    SpinnerSession_1.Visibility = visibility;
                    SpinnerSession_2.Visibility = visibility;
                    break;
            }
        }

        private async Task<bool> CheckOnSession()
        {
            await Task.Delay(1000);
            var key = Registry.CurrentUser.OpenSubKey("OnDigitSession");
            if (key is null)
            {
                SpinnersPropsChange("SpinnerSession", false, Visibility.Collapsed);
                return false;
            }

            var pcId = key.GetValue("pcId").ToString();
            var userId = key.GetValue("userId").ToString();

            if (string.IsNullOrEmpty(pcId) is false)
            {
                _currentSession = await _userService.GetSessionInfo(pcId, userId);

                if (DateTime.UtcNow <= _currentSession.EndDate && _currentSession.IsCanceledInAdvance is false)
                {
                    _currentUser = await _userService.GetByIdAsync(userId);
                    if (_currentUser is not null)
                    {
                        UserFullname.Text = _currentUser.Name + " " + _currentUser.Surname;
                        LoginedState.Visibility = Visibility.Visible; 
                        SpinnersPropsChange("SpinnerSession", false, Visibility.Collapsed);
                        return true;
                    }
                }
            }

            SpinnersPropsChange("SpinnerSession", false, Visibility.Collapsed);
            return false;
        }

        private async void LoadBooks(ICollection<Edition> editionList)
        {
            SpinnersPropsChange("SpinnerBooks", true, Visibility.Visible);

            this.ShopMain.Effect = new BlurEffect(); 

            await Task.Delay(1000);

            ShopMain.Children.Clear();

            List<string> favoriteEditionsId = new List<string>();

            if (_currentUser is not null)
            {
                var userFavorites = await _userService.GetFavoriteEditionsAsync(_currentUser.Id); 
                foreach (UserFavorite edition in userFavorites)
                {
                    favoriteEditionsId.Add(edition.EditionId);
                }
            }

            foreach (var edition in editionList)
            {
                edition.ImageLink = "/Images/willbook.jpg";
                ShopMain.Children.Add(new ShopEditionCard(this, edition, favoriteEditionsId.Contains(edition.Id), _currentUser.Id, _reviewService, _userService));
            }

            editionList.Clear();
            this.ShopMain.Effect = null;
            SpinnersPropsChange("SpinnerBooks", false, Visibility.Collapsed);
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
            if(handler is not null)
                handler(this, new PropertyChangedEventArgs(propertyName));
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

        private async void Logout_Click(object sender, RoutedEventArgs e)
        {
            _currentSession.IsCanceledInAdvance = true;
            await _userService.UpdateSessionInfo(_currentSession);
            Registry.CurrentUser.DeleteSubKey("OnDigitSession");
            LoginedState.Visibility = Visibility.Collapsed;
            UserFullname.Text = string.Empty;
            ShopMain.Children.Clear();
            SignInDialog();
        }

        private async void SignInDialog()
        {
            this.Effect = new BlurEffect();
            new SignIn(this, _authenticationService)
            {
                Topmost = true
            }.ShowDialog();
            this.Effect = null;

            if (_currentUser is not null)
            {
                UserFullname.Text = _currentUser.Name + " " + _currentUser.Surname;
                LoginedState.Visibility = Visibility.Visible;
                LoadBooks(await _shopService.GetAllEditionsAsync());
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void ShutdownApp_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private async void ActivateSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text) is true)
                return;

            ICollection<Edition> searchedEditions = await _shopService.SearchEditionsAsync(SearchBox.Text);

            if (searchedEditions is not null)
                LoadBooks(searchedEditions);

        }
    }
}

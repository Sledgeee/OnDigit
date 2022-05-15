using System.Windows;
using OnDigit.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Input;

namespace OnDigit.Client.UI.Auth
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IShopService _shopService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IReviewService _reviewService;

        public SignIn(IAuthenticationService authenticationService,
                      IShopService shopService,
                      IUserService userService,
                      IOrderService orderService,
                      IReviewService reviewService)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
            _shopService = shopService;
            _userService = userService;
            _orderService = orderService;
            _reviewService = reviewService;
            new Action(async () => await CheckOnSession())();
        }

        private async Task CheckOnSession()
        {
            var key = Registry.CurrentUser.OpenSubKey("OnDigitSession");
            if (key is null)
            {
                return;
            }

            var pcId = key?.GetValue("pcId")?.ToString();
            var userId = key?.GetValue("userId")?.ToString();

            if (string.IsNullOrEmpty(pcId) is false)
            {
                var session = await _userService.GetSessionInfo(pcId, userId);
                if (session is not null)
                {
                    var user = await _userService.GetByIdAsync(userId);
                    if (DateTime.UtcNow <= session.EndDate && session.IsCanceledInAdvance is false)
                    {
                        if (user is not null)
                        {
                            this.Hide();
                            new MainWindow(user, session, _shopService, _userService, _orderService, _reviewService).ShowDialog();
                            this.Show();
                        }
                    }
                }
            }
        }

        private void exitDialog_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        
        public Task SetError(string message)
        {
            ExceptionsPanel.Children.Add(new TextBlock()
            {
                Margin = new Thickness(0, 10, 0, 0),
                FontSize = 18d,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = Brushes.DarkRed,
                Text = message,
                TextWrapping = TextWrapping.Wrap
            });
            return Task.CompletedTask;
        }

        public async void Login()
        {
            ExceptionsPanel.Children.Clear();
            try
            {
                var user = await _authenticationService.Login(txtEmail.Text, txtPassword.Password, RememberMeCheck.IsChecked);
                this.Hide();
                new MainWindow(user, null, _shopService, _userService, _orderService, _reviewService).ShowDialog();
                this.Show();
            }
            catch (AggregateException ex)
            {
                foreach (Exception innerException in ex.InnerExceptions)
                {
                    await SetError(innerException.Message);
                }
            }
            catch (Exception ex)
            {
                await SetError(ex.Message);
            }
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e) => Login();

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                new SignUp(_authenticationService).ShowDialog();
                this.Show();
            }
            catch (Exception) { }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            try
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
            }
            catch (Exception)
            {

            }
        }
    }
}

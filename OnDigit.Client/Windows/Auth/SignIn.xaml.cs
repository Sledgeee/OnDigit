using System.Windows;
using OnDigit.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace OnDigit.Client.Windows.Auth
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly MainWindow _mainWindow;
        public SignIn(MainWindow reference, IAuthenticationService authenticationService)
        {
            InitializeComponent();
            _mainWindow = reference;
            _authenticationService = authenticationService;
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
                _mainWindow.CurrentUser = user;
                this.Close();
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
            this.Close();
            new SignUp(_mainWindow, _authenticationService).ShowDialog();
        }
    }
}

using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using OnDigit.Client.Windows.Auth;
using OnDigit.Core.Interfaces.Services;

namespace OnDigit.Client.Windows.Reset.Steps
{
    /// <summary>
    /// Interaction logic for VerifyCode.xaml
    /// </summary>
    public partial class VerifyCode : Page
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly MainWindow _mainWindow;
        public VerifyCode(MainWindow reference, IAuthenticationService authenticationService)
        {
            InitializeComponent();
            _mainWindow = reference;
            _authenticationService = authenticationService;
        }

        private void verifyBtn_Click(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new SetPassword(_mainWindow, _authenticationService));

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetWindow.GetWindow(this).Close();
            new SignIn(_mainWindow, _authenticationService).ShowDialog();
        }
    }
}

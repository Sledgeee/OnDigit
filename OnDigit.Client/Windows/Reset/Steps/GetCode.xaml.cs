using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using OnDigit.Client.Windows.Auth;
using OnDigit.Core.Interfaces.Services;

namespace OnDigit.Client.Windows.Reset.Steps
{
    /// <summary>
    /// Interaction logic for GetCode.xaml
    /// </summary>
    public partial class GetCode : Page
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly MainWindow _mainWindow;
        public GetCode(MainWindow reference, IAuthenticationService authenticationService)
        {
            InitializeComponent();
            _mainWindow = reference;
            _authenticationService = authenticationService;
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e) => 
            NavigationService.Navigate(new VerifyCode(_mainWindow, _authenticationService));

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetWindow.GetWindow(this).Close();
            new SignIn(_mainWindow, _authenticationService).ShowDialog();
        }
    }
}

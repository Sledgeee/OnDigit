using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using OnDigit.Client.Windows.Auth;
using OnDigit.Core.Interfaces.Services;

namespace OnDigit.Client.Windows.Reset.Steps
{
    /// <summary>
    /// Interaction logic for SetPassword.xaml
    /// </summary>
    public partial class SetPassword : Page
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly MainWindow _mainWindow;

        public SetPassword(MainWindow reference, IAuthenticationService authenticationService)
        {
            InitializeComponent();
            _mainWindow = reference;
            _authenticationService = authenticationService;
        }

        private void setPasswordBtn_Click(object sender, RoutedEventArgs e) =>
            cancelBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetWindow.GetWindow(this).Close();
            new SignIn(_mainWindow, _authenticationService).ShowDialog();
        }
    }
}

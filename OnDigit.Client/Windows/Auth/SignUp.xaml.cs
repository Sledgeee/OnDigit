using System;
using System.Windows;
using OnDigit.Core.Interfaces.Services;

namespace OnDigit.Client.Windows.Auth
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly MainWindow _mainWindow;
        public SignUp(MainWindow reference, IAuthenticationService authenticationService)
        {
            InitializeComponent();
            _mainWindow = reference;
            _authenticationService = authenticationService;
        }  

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public async void Register()
        {
            ErrorDisplay.Text = string.Empty;
            try
            {
                RegistrationResult registrationResult = await _authenticationService.Register(
                       txtEmail.Text, txtPassword.Password, txtRepeatPassword.Password, 
                       txtName.Text, txtSurname.Text, lbGender.Text);

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        this.Close();
                        new SignIn(_mainWindow, _authenticationService).ShowDialog();
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        ErrorDisplay.Text = "Password does not match confirm password";
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        ErrorDisplay.Text = "An account for this email already exists";
                        break;
                    case RegistrationResult.EmptyFields:
                        ErrorDisplay.Text = "Not all fields are filled";
                        break;
                    default:
                        ErrorDisplay.Text = "Registration failed";
                        break;
                }
            }
            catch (Exception)
            {
                ErrorDisplay.Text = "Registration failed";
            }
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Register();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new SignIn(_mainWindow, _authenticationService).ShowDialog();
        }

        private void exitDialog_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

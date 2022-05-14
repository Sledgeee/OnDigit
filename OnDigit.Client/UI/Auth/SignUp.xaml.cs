using System;
using System.Windows;
using System.Windows.Input;
using OnDigit.Core.Interfaces.Services;

namespace OnDigit.Client.UI.Auth
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private readonly IAuthenticationService _authenticationService;

        public SignUp(IAuthenticationService authenticationService)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
        }

        private void ExitApp(object sender, RoutedEventArgs e) => this.Close();

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

        private void SignUpBtn_Click(object sender, RoutedEventArgs e) => Register();

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void exitDialog_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();


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

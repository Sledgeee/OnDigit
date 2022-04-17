using System.Threading.Tasks;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Interfaces.Services
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        EmptyFields,
        InvalidEmail
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string password, string confirmPassword, string name, string surname, string gender);
        Task<User> Login(string email, string password, bool? rememberMe);
    }
}

using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Exceptions;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Services;

namespace OnDigit.Core.Tests.Services
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private Mock<IUserService> _mockUserService;
        private AuthenticationService _authenticationService;

        [SetUp]
        public void SetUp()
        {
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _mockUserService = new Mock<IUserService>();
            _authenticationService = new AuthenticationService(_mockUserService.Object, _mockPasswordHasher.Object);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingEmail_ReturnsUserForCorrectEmail()
        {
            string expectedEmail = "test@gmail.com";
            string password = "testpassword";
            _mockUserService.Setup(s => s
                .GetByEmailAsync(expectedEmail))
                .ReturnsAsync(new User() { Email = expectedEmail });

            _mockPasswordHasher.Setup(s => s
                .VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Success);

            User user = await _authenticationService.Login(expectedEmail, password);

            string actualEmail = user.Email;
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [Test]
        public void Login_WithIncorrectPasswordForExistingEmail_ThrowsInvalidPasswordExceptionForEmail()
        {
            string expectedEmail = "test@gmail.com";
            string password = "testpassword";
            _mockUserService.Setup(s => s
                .GetByEmailAsync(expectedEmail))
                .ReturnsAsync(new User() { Email = expectedEmail });

            _mockPasswordHasher.Setup(s => s
                .VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Failed);

            InvalidPasswordException exception = Assert.ThrowsAsync<InvalidPasswordException>(
                () => _authenticationService.Login(expectedEmail, password));

            string actualEmail = exception.Email;
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [Test]
        public void Login_WithNonExistingEmail_ThrowsInvalidPasswordExceptionForEmail()
        {
            string expectedEmail = "test@gmail.com";
            string password = "testpassword";
            _mockPasswordHasher.Setup(s => s
                .VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Failed);

            UserNotFoundException exception = Assert.ThrowsAsync<UserNotFoundException>(
                () => _authenticationService.Login(expectedEmail, password));

            string actualEmail = exception.Email;
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [Test]
        public async Task Register_WithPasswordsNotMatching_ReturnPasswordsDoNotMatch()
        {
            string password = "testpassword";
            string confirmPassword = "confirmtestpassword";
            RegistrationResult expected = RegistrationResult.PasswordsDoNotMatch;

            RegistrationResult actual = await _authenticationService
                .Register(It.IsAny<string>(), password, confirmPassword, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {
            string email = "test@gmail.com";
            _mockUserService.Setup(s => s.GetByEmailAsync(email)).ReturnsAsync(new User());
            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            RegistrationResult actual = await _authenticationService
                .Register(email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithNonExistingUserAndMatchingPasswords_ReturnsSuccess()
        {
            RegistrationResult expected = RegistrationResult.Success;

            string email = "test@gmail.com";
            string password = "testpassword";
            string confirPassword = "testpassword";
            string name = "testname";
            string surname = "testsurname";
            string gender = "testgender";

            RegistrationResult actual = await _authenticationService
                .Register(email, password, confirPassword, name, surname, gender);

            Assert.AreEqual(expected, actual);
        }
    }
}
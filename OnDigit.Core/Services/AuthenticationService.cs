using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Interfaces.Services;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using OnDigit.Core.Exceptions;
using OnDigit.Core.Models.RoleModel;
using System.Collections.Generic;
using System;
using System.Collections;

namespace OnDigit.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string email, string password, bool? rememberMe)
        {
            List<Exception> exceptions = new List<Exception>();
            if (string.IsNullOrEmpty(email) is true)
                exceptions.Add(new EmptyFieldException("Email field is empty"));

            if (string.IsNullOrEmpty(password) is true)
                exceptions.Add(new EmptyFieldException("Password field is empty"));

            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);

            User storedUser = await _userService.GetByEmailAsync(email);
            
            if (storedUser is null)
                throw new UserNotFoundException("Email not found", email);

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedUser.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
                throw new InvalidPasswordException("Incorrect password", email, password);

            if (rememberMe.Value)
                await _userService.SetRememberMeStatus(storedUser.Id);

            await _userService.AddLoginToHistory(storedUser.Id);

            return storedUser;
        }

        private bool IsValidEmail(string email)
        {
            if (email is null)
                return false;

            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public async Task<RegistrationResult> Register(string email, string password, string confirmPassword, string name, string surname, string gender)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (string.IsNullOrEmpty(email) is true || 
                string.IsNullOrEmpty(password) is true || 
                string.IsNullOrEmpty(name) is true || 
                string.IsNullOrEmpty(surname) is true ||
                string.IsNullOrEmpty(gender) is true) result = RegistrationResult.EmptyFields;

            if (IsValidEmail(email) is false)
                result = RegistrationResult.InvalidEmail;

            User emailUser = await _userService.GetByEmailAsync(email);
            if (emailUser is not null)
                result = RegistrationResult.EmailAlreadyExists;

            if (password != confirmPassword)
                result = RegistrationResult.PasswordsDoNotMatch;

            if (result is RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Email = email,
                    PasswordHash = hashedPassword,
                    Name = name,
                    Surname = surname,
                    Gender = gender,
                    RoleId = 3
                };

                await _userService.AddAsync(user);
            }

            return result;
        }
    }
}
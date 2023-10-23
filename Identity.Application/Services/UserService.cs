using Identity.Application.Configurations.Interfaces;
using Identity.Application.Dtos.User;
using Identity.Common.Exceptions;
using Identity.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Identity.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserLoginResponse> LoginAsync(UserLoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentException("Password is required!");
            }

            ApplicationUser loginUser = await _userManager.FindByEmailAsync(request.UserName) ?? throw new NotFoundException(nameof(request.UserName));

            var isPasswordMatched = await _userManager.CheckPasswordAsync(loginUser, request.Password);

            if (isPasswordMatched)
            {
                return new UserLoginResponse
                {
                    User = loginUser.Adapt<UserDto>()
                };
            }

            throw new ArgumentException($"Invalid Credential");
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email is required");
            }

            string emailPatern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3}+)$";

            if (Regex.IsMatch(email, emailPatern))
            {
                throw new ArgumentException("Invalid email");
            }
        }
    }
}
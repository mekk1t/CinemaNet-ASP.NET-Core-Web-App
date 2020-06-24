using Microsoft.AspNetCore.Identity;
using OasisWebApp.DTOs;
using OasisWebApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OasisWebApp.Services.AccountService
{
    public class AccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountService(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public async Task<UserModel> CheckUserAsync(UserDto userDto)
        {
            bool passwordIsCorrect = false;
            var userResult = await userManager.FindByNameAsync(userDto.Username);
            if (userResult != null)
            {
                passwordIsCorrect = await userManager.CheckPasswordAsync(userResult, userDto.Password);
            }
            if (userResult != null && passwordIsCorrect)
            {
                return new UserModel()
                {
                    User = userResult,
                    HasCorrectPassword = passwordIsCorrect
                };
            }
            return new UserModel()
            {
                User = userResult,
                HasCorrectPassword = passwordIsCorrect
            };
        }

        public async Task<bool> Login(UserDto userDto)
        {
            var user = await CheckUserAsync(userDto);
            if (user.HasCorrectPassword && user.User != null)
            {
               await signInManager.SignInAsync(user.User, false);
               return true;
            }
            return false;
        }

        public async Task SignOutUser()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<bool> Register (UserDto userDto)
        {
            var password = userDto.Password;
            var user = new IdentityUser()
            {
                UserName = userDto.Username
            };
            var registration = await userManager.CreateAsync(user, password);
            if (registration.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}

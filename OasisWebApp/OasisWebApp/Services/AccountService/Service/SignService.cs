using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OasisWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Services.AccountService.Service
{
    public class SignService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;

        public SignService(
            SignInManager<IdentityUser> signInManager,
            IMapper mapper)
        {
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        public async Task SignInAsync(
            UserDto userDto,
            string password,
            bool IsPersistent = false,
            bool LockOut = false)
        {
            var user = mapper.Map<IdentityUser>(userDto);
            await signInManager.PasswordSignInAsync(
                user, password,
                IsPersistent, LockOut);
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }

    }
}

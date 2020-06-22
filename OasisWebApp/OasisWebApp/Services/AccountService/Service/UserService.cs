using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OasisWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisWebApp.Services.AccountService.Service
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public UserService(
            UserManager<IdentityUser> userManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> CreateUserAsync(
            UserDto userDto)
        {
            var password = userDto.Password;
            var user = mapper.Map<IdentityUser>(userDto);
            var result = await userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<UserDto> FindUserAsync(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }


    }
}

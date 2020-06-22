using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.DTOs;
using OasisWebApp.Services.AccountService.Service;
using System.Threading.Tasks;

namespace OasisWebApp.Services.AccountService.Controller
{
    public class AccountController : CustomController
    { 
        private readonly UserService userService;
        private readonly SignService signService;

        public AccountController(
            UserService userService,
            SignService signService)
        {
            this.userService = userService;
            this.signService = signService;
        }

        [Route("")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(
            [FromForm] UserDto userDto)
        {
            var user = await userService.FindUserAsync(userDto.Username);
            if (user != null)
            {
                await signService.SignInAsync(userDto, userDto.Password);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(
            [FromForm] UserDto user)
        {
            var result = await userService.CreateUserAsync(user);

            if (result.Succeeded)
            {
                await signService.SignInAsync(user, user.Password);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Successful");
        }

        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await signService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

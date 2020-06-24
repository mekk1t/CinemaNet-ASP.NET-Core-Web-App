using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.DTOs;
using System.Threading.Tasks;

namespace OasisWebApp.Services.AccountService.Controller
{
    // TODO: избавиться от переадресации на ORderController? И просто обращаться к OrderService + TicketService
    public class AccountController : CustomController
    {
        private readonly AccountService accountService;
        public AccountController(
            AccountService accountService)
        {
            this.accountService = accountService;
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
            var loginSuccessful = await accountService.Login(userDto);
            if (loginSuccessful)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Home", "Home");
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
            await accountService.Register(user);
            return RedirectToAction("Index");
        }

        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await accountService.SignOutUser();
            return RedirectToAction("Home", "Home");
        }

        [Route("IsAdmin")]
        [Authorize(Roles = "Admin")]
        public IActionResult IsAdmin()
        {
            return Ok("Is admin");
        }

        [Route("Orders")]
        [Authorize]
        public IActionResult Orders()
        {
            return RedirectToAction("Orders", "Order");
        }



    }
}

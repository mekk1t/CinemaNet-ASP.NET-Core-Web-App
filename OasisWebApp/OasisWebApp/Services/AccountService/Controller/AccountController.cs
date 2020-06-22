using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OasisWebApp.Controllers.Custom;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OasisWebApp.Services.AccountService.Controller
{
    public class AccountController : CustomController
    { 
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
            [FromForm] string username, 
            [FromForm] string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user != null)
            {
                var signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Successful");
                }
            }


            return RedirectToAction("Index");
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(
            [FromForm] string username,
            [FromForm] string password)
        {
            var user = new IdentityUser()
            {
                UserName = username
            };

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await signInManager.PasswordSignInAsync(user, password, false, false);
            }


            return RedirectToAction("Successful");
        }

        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Successful");
        }

        [Route("Successful")]
        public IActionResult Successful()
        {
            var message = "Успех!";
            return Ok(message);
        }
    }
}

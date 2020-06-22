using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.Models;

namespace OasisWebApp.Controllers
{
    [Route("OasisWebApp")]
    public class HomeController : CustomController
    {      
        [Route("Home")]
        public IActionResult Home()
        {
            return View();
        }
        [Route("Privacy")]
        public IActionResult Privacy()
        { 
            ViewData["Title"] = "Privacy, madafakaaaa";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using test8.Models;

namespace test8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
           
            

            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); ;
                ViewBag.UserId = loggedInUserId;

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
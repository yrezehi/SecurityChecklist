using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> Logger;

        public HomeController(ILogger<HomeController> logger) =>
            Logger = logger;

        public IActionResult Index() =>
            View();
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
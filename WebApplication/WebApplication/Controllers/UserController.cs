using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> Logger;

        public UserController(ILogger<UserController> logger) =>
            Logger = logger;

        [HttpGet("[action]")]
        public IActionResult Login() =>
            View();

        [HttpPost("[action]")]
        public IActionResult Authenticate()
        {

            return View();
        }
    }
}

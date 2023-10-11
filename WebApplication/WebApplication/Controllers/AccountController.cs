using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> Logger;

        public AccountController(ILogger<AccountController> logger) =>
            Logger = logger;

        [HttpGet("[action]")]
        public IActionResult Login() =>
            View();
    }
}

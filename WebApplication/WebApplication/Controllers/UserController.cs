using Application.Models.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> Logger;
        private readonly UserService UserService;

        public UserController(ILogger<UserController> logger, UserService userService) =>
            (Logger, UserService) = (logger, userService);

        [HttpGet("[action]")]
        public IActionResult Login() =>
            View();

        [HttpPost("[action]")]
        public async Task<IActionResult> Authenticate(AuthenticationDTO authenticationDTO) {

            await UserService.Authenticate(authenticationDTO);

            return RedirectToAction("Index", "Home");
        }
    }
}

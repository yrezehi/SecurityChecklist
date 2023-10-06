using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Application.Services
{
    public class AuthenticationService
    {
        private readonly IHttpContextAccessor HttpContextAccessor;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor) {
            HttpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated()
        {
            return false;
        }

        public async Task SignIn()
        {
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Email"),
                new Claim("FullName", "Full Name"),
                new Claim(ClaimTypes.Role, "Administrator"),
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IssuedUtc = DateTimeOffset.Now,
                //RedirectUri = <string> // TODO: try it out
            };

            HttpContext? httpContext = HttpContextAccessor.HttpContext;

            if (httpContext == null)
                throw new ArgumentException("Http context is null!");

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
        }
    }
}

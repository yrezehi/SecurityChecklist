using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Application.Models;

namespace Application.Services
{
    public class AuthenticationService
    {
        private readonly IHttpContextAccessor HttpContextAccessor;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated()
        {
            return true;
        }

        public async Task SignIn()
        {
            HttpContext? httpContext = HttpContextAccessor.HttpContext;

            if (httpContext == null)
                throw new ArgumentException("Http context is null!");

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                GetClaimsPrincipal(null),
                GetProperties()
            );
        }

        private AuthenticationProperties GetProperties() => new AuthenticationProperties
        {
            AllowRefresh = true,
            IssuedUtc = DateTimeOffset.Now,
            //RedirectUri = <string> // TODO: try it out
        };

        private ClaimsPrincipal GetClaimsPrincipal(User user) =>
            new ClaimsPrincipal(
                new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Administrator"),
                }, CookieAuthenticationDefaults.AuthenticationScheme)
            );

    }
}

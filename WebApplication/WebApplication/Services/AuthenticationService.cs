using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Application.Models;
using Application.Models.DTO;

namespace Application.Services
{
    public class AuthenticationService
    {
        private readonly IHttpContextAccessor HttpContextAccessor;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated(AuthenticationDTO authenticationDTO, User user) =>
            authenticationDTO.Password.Equals(user.Password);

        public async Task SignIn(User user)
        {
            HttpContext? httpContext = HttpContextAccessor.HttpContext;

            if (httpContext == null)
                throw new ArgumentException("Http context is null!");

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                GetClaimsPrincipal(user),
                AuthenticationProperties
            );
        }

        private AuthenticationProperties AuthenticationProperties => new()
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

using Microsoft.AspNetCore.Authentication.Cookies;

namespace Application.Extensions
{
    public static class RegisterSecurityExtensions
    {
        public static void RegisterSecurityLayer(this WebApplicationBuilder application)
        {
            application.RegisterCookieAuthentication();
        }

        private static void RegisterCookieAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.Cookie.HttpOnly = true; // OWASP-A01
                options.ExpireTimeSpan = TimeSpan.FromHours(60); // OWASP-A01
                options.SlidingExpiration = false; // OWASP-A01
            });
        }
    }
}

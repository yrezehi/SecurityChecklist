using Application.Events.Handlers;
using Application.Extensions;
using Application.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Application.Events
{
    public class CookieAuthenticationEvent : CookieAuthenticationEvents
    {
        private readonly TerminateSessionEventHandler TerminateSessionEventHandler;
        private readonly UserService UserService;

        public CookieAuthenticationEvent(TerminateSessionEventHandler terminateSessionEventHandler, UserService userService) =>
            (TerminateSessionEventHandler, UserService) = (terminateSessionEventHandler, userService);

        public override Task SigningIn(CookieSigningInContext context)
        {
            if (TerminateSessionEventHandler.IsTerminated(context.HttpContext))
            {
                throw new ArgumentException("Nice attempt.");
            }

            return base.SigningIn(context);
        }

        public async override Task SignedIn(CookieSignedInContext context)
        {
            await UserService.RefreshLastSignin(context.HttpContext.GetCalimValue(ClaimTypes.Email));

            await base.SignedIn(context);
        }

        public override Task SigningOut(CookieSigningOutContext context)
        {
            TerminateSessionEventHandler.Terminate(context.HttpContext);

            return base.SigningOut(context);
        }
    }
}

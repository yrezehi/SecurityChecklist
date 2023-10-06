using Application.Events.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Application.Events
{
    public class CookieAuthenticationEvent : CookieAuthenticationEvents
    {
        private readonly TerminateSessionEventHandler TerminateSessionEventHandler;

        public CookieAuthenticationEvent(TerminateSessionEventHandler terminateSessionEventHandler) =>
            TerminateSessionEventHandler = terminateSessionEventHandler;

        public override Task SigningIn(CookieSigningInContext context)
        {
            if (TerminateSessionEventHandler.IsTerminated(context.HttpContext))
            {
                throw new ArgumentException("Nice attempt.");
            }

            return base.SigningIn(context);
        }

        public override Task SignedIn(CookieSignedInContext context)
        {
            // TODO: update user context
            return base.SignedIn(context);
        }

        public override Task SigningOut(CookieSigningOutContext context)
        {
            TerminateSessionEventHandler.Terminate(context.HttpContext);

            return base.SigningOut(context);
        }
    }
}

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Events
{
    public class RateLimitEventHandler : IMiddleware
    {
        private static string PAGE_LIMIT_URI = "/GOTOCD";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (IsRateLimitExceeded(context))
            {
                SetRedirectToException(context);
            } else
            {
                await next(context);
            }
        }

        private bool IsRateLimitExceeded(HttpContext context) =>
            true;

        private void SetRedirectToException(HttpContext context) =>
            context.Response.Redirect(PAGE_LIMIT_URI);
        
    }
}

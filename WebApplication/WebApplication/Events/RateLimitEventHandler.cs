namespace Application.Events
{
    public class RateLimitEventHandler : IMiddleware
    {
        private static string RATE_LIMIT_EXCEPTION_PAGE = "/GOTOCD";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (IsRateLimitExceeded(context))
            {
                RedirectToException(context);
            } else
            {
                await next(context);
            }
        }

        private bool IsRateLimitExceeded(HttpContext context) =>
            true;

        private void RedirectToException(HttpContext context) =>
            context.Response.Redirect(RATE_LIMIT_EXCEPTION_PAGE);
        
    }
}

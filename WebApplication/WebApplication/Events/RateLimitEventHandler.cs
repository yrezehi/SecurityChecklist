using Application.Cache;
using Application.Extensions;

namespace Application.Events
{
    public class RateLimitEventHandler : IMiddleware
    {
        private readonly CacheManager CacheManager;

        private static string CACHE_NAME = "RATE_LIMIT";
        private static string RATE_LIMIT_EXCEPTION_PAGE = "/GOTOCD";

        private static int RATE_LIMIT = 500;

        public RateLimitEventHandler(CacheManager cacheManager)
        {
            CacheManager = cacheManager;
            CacheManager.CreateCache(CACHE_NAME);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var clientIdentifier = context.GetIP();

            if (clientIdentifier == null)
            {
                await next(context);
            }
            else
            {
                if (this.IsRateLimitExceeded(clientIdentifier))
                {
                    this.RedirectToException(context);
                }
                else
                {
                    await next(context);
                }
            }
        }

        private bool IsRateLimitExceeded(string identifier) =>
            CacheManager.Get<int>(CACHE_NAME, identifier) >= RATE_LIMIT;

        private void RedirectToException(HttpContext context) =>
            context.Response.Redirect(RATE_LIMIT_EXCEPTION_PAGE);
        
    }
}

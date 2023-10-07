using Application.Cache;
using Application.Extensions;

namespace Application.Events.Handlers
{
    public class TerminateSessionEventHandler
    {
        private readonly CacheManager CacheManager;

        private static string CACHE_NAME = "TERMINATED_SESSIONS";

        public TerminateSessionEventHandler(CacheManager cacheManager)
        {
            CacheManager = cacheManager;
            CacheManager.CreateCache(CACHE_NAME);
        }

        public void Terminate(HttpContext httpContext)
        {
            if(httpContext.Request.Cookies.Count > 0)
            {
                var requestCookie = httpContext.GetCookieValue(".AspNetCore.");

                if (requestCookie != null)
                {
                    CacheManager.Set(CACHE_NAME, requestCookie, DateTime.Now);
                }
            }
        }

        public bool IsTerminated(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies.Count > 0)
            {
                var requestCookie = httpContext.GetCookieValue(".AspNetCore.");

                if(requestCookie != null)
                {
                    return CacheManager.Contains(CACHE_NAME, requestCookie);
                }
            }

            return false;
        }
    }
}

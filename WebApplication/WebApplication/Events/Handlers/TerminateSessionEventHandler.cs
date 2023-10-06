using Application.Cache;
using System.Collections.Concurrent;

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
                var requestCookie = httpContext.Request.Cookies.FirstOrDefault(cookie => cookie.Key.Contains(".AspNetCore."));
                CacheManager.Set(CACHE_NAME, requestCookie.Value, DateTime.Now);
            }
        }

        public bool IsTerminated(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies.Count > 0)
            {
                var requestCookie = httpContext.Request.Cookies.FirstOrDefault(cookie => cookie.Key.Contains(".AspNetCore."));
                return CacheManager.Contains(CACHE_NAME, requestCookie.Value);
            }
            return false;
        }
    }
}

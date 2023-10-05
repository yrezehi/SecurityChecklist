using Application.Cache;
using System.Collections.Concurrent;

namespace Application.Events.Handlers
{
    public class TerminateSessionEventHandler
    {
        private readonly ConcurrentDictionary <string, DateTime> TerminatedSessions;
        private readonly CacheManager CacheManager;

        private static string CACHE_KEY = "TERMINATED_SESSIONS";

        public TerminateSessionEventHandler(CacheManager cacheManager)
        {
            CacheManager = cacheManager;
            TerminatedSessions = new();

            CacheManager.CreateCache(CACHE_KEY);
        }

        public void Terminate(HttpContext httpContext)
        {
            if(httpContext.Request.Cookies.Count > 0)
            {
                var requestCookie = httpContext.Request.Cookies.FirstOrDefault(cookie => cookie.Key.Contains(".AspNetCore."));

                TerminatedSessions.TryAdd(requestCookie.Value, DateTime.Now);
            }
        }

        public bool IsSessionTerminated(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies.Count > 0)
            {
                var requestCookie = httpContext.Request.Cookies.FirstOrDefault(cookie => cookie.Key.Contains(".AspNetCore."));

                return TerminatedSessions.ContainsKey(requestCookie.Value);
            }

            return false;
        }
    }
}

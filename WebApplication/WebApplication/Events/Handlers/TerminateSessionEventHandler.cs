using System.Collections.Concurrent;

namespace Application.Events.Handlers
{
    public class TerminateSessionEventHandler
    {
        public ConcurrentDictionary <string, DateTime> TerminatedSessions;

        public TerminateSessionEventHandler() =>
            TerminatedSessions = new();

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

using System.Collections.Concurrent;

namespace Application.Events.Handlers
{
    public class TerminateSessionEventHandler
    {
        public ConcurrentBag<string> TerminatedSessions;

        public TerminateSessionEventHandler() =>
            TerminatedSessions = new ConcurrentBag<string>();

        public void Terminate(HttpContext httpContext)
        {
            if(httpContext.Request.Cookies.Count > 0)
            {
                var requestCookie = httpContext.Request.Cookies.FirstOrDefault(cookie => cookie.Key.Contains(".AspNetCore."));

                TerminatedSessions.Add(requestCookie.Value);
            }
        }
    }
}

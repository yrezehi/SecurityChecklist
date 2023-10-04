using System.Collections.Concurrent;

namespace Application.Events.Handlers
{
    public class FailedAttemptsEventHandler
    {
        public ConcurrentDictionary<string, int> FailedAttempts;
        private static int ALLOWED_FAILED_ATTEMPTS = 5;

        
        public FailedAttemptsEventHandler()
        {
            FailedAttempts = new ConcurrentDictionary<string, int>();
        }

        public bool ShouldLockout(string ip)
        {
            if (FailedAttempts.ContainsKey(ip))
            {
                return FailedAttempts[ip] >= ALLOWED_FAILED_ATTEMPTS;
            }

            return false;
        }
    }
}

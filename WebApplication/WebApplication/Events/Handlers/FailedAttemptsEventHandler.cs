using System.Collections.Concurrent;

namespace Application.Events.Handlers
{
    public class FailedAttemptsEventHandler
    {
        public ConcurrentDictionary<string, int> FailedAttempts;
        private static int ALLOWED_FAILED_ATTEMPTS = 5;
        
        public FailedAttemptsEventHandler() =>
            FailedAttempts = new ConcurrentDictionary<string, int>();

        public void ResetFailedAttempts(string ip) =>
            FailedAttempts.Remove(ip, out _);

        public bool ShouldLockout(string ip)
        {
            if (FailedAttempts.ContainsKey(ip))
            {
                return FailedAttempts[ip] >= ALLOWED_FAILED_ATTEMPTS;
            }

            return false;
        }

        public int FailedAttempt(string ip)
        {
            if (FailedAttempts.ContainsKey(ip))
            {
                var failedAttemptsCount = FailedAttempts[ip];

                FailedAttempts.TryUpdate(ip, failedAttemptsCount + 1, failedAttemptsCount++);

                return failedAttemptsCount;
            }

            FailedAttempts.TryAdd(ip, 1);

            return 1;
        }
    }
}

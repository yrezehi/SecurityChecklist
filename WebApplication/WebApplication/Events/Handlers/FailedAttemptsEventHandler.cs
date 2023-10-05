using Application.Cache;
using System.Collections.Concurrent;

namespace Application.Events.Handlers
{
    public class FailedAttemptsEventHandler
    {
        private readonly ConcurrentDictionary<string, int> FailedAttempts;
        private readonly CacheManager CacheManager;

        private static string CACHE_KEY = "FAILED_ATTEMPTS";
        private static int ALLOWED_FAILED_ATTEMPTS = 5;

        public FailedAttemptsEventHandler(CacheManager cacheManager)
        {
            CacheManager = cacheManager;
            FailedAttempts = new();

            CacheManager.CreateCache(CACHE_KEY);
        }

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

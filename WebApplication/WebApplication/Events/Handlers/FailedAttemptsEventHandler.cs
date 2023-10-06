using Application.Cache;

namespace Application.Events.Handlers
{
    public class FailedAttemptsEventHandler
    {
        private readonly CacheManager CacheManager;

        private static string CACHE_KEY = "FAILED_ATTEMPTS";
        private static int ALLOWED_FAILED_ATTEMPTS = 5;

        public FailedAttemptsEventHandler(CacheManager cacheManager)
        {
            CacheManager = cacheManager;
            CacheManager.CreateCache(CACHE_KEY);
        }

        public void ResetFailedAttempts(string ip) =>
            CacheManager.Remove(CACHE_KEY, ip);

        public bool ShouldLockout(string ip)
        {
            if (CacheManager.Contains(CACHE_KEY, ip))
            {
                return CacheManager.Get<int>(CACHE_KEY, ip) >= ALLOWED_FAILED_ATTEMPTS;
            }
            return false;
        }

        public int FailedAttempt(string ip)
        {
            if (CacheManager.Contains(CACHE_KEY, ip))
            {
                var failedAttemptsCount = CacheManager.Get<int>(CACHE_KEY, ip);
                CacheManager.Increment(CACHE_KEY, ip);
                return failedAttemptsCount;
            }
            CacheManager.Set(CACHE_KEY, ip, 1);
            return 1;
        }
    }
}

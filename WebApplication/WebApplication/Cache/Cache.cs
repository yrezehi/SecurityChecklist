using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace Application.Cache
{
    public class Cache
    {
        private readonly ConcurrentDictionary<string, MemoryCache> Caches;

        public Cache() =>
            Caches = new ConcurrentDictionary<string, MemoryCache>();
        
        public MemoryCache GetCache(string name)
        {
            if (Caches.ContainsKey(name))
            {
                return Caches[name];
            }

            throw new ArgumentException($"{name} is not initialized.");
        }

    }
}

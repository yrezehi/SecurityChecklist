using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Application.Cache
{
    public class CacheManager
    {
        private readonly ConcurrentDictionary<string, MemoryCache> Caches;

        public CacheManager() =>
            Caches = new ConcurrentDictionary<string, MemoryCache>();
        
        public MemoryCache GetCache(string name)
        {
            if (Caches.ContainsKey(name))
            {
                return Caches[name];
            }

            throw new ArgumentException($"{name} is not initialized.");
        }

        public void CreateCache(string name)
        {
            if(!Caches.TryAdd(name, CreateMemeoryCacheInstance()))
                throw new ArgumentException($"Was not able to create a cache instance for {name}");
        }

        private MemoryCache CreateMemeoryCacheInstance() =>
            new MemoryCache(new MemoryCacheOptions());

    }
}

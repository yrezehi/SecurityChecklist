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

        private MemoryCache CreateMemeoryCacheInstance() =>
            new MemoryCache(new MemoryCacheOptions());

        public MemoryCache GetCache(string name)
        {
            if (Caches.ContainsKey(name))
                return Caches[name];

            throw new ArgumentException($"{name} is not initialized.");
        }

        public void CreateCache(string name)
        {
            if(!Caches.TryAdd(name, CreateMemeoryCacheInstance()))
                throw new ArgumentException($"Was not able to create a cache instance for {name}");
        }

        public bool Contains(string name, string key) =>
            this.GetCache(name).TryGetValue(key, out _);

        public void Remove(string name, string key) =>
            this.GetCache(name).Remove(key);

        public void Set<T>(string name, string key, T value) =>
            this.GetCache(name).Set(key, value);

        public T? Get<T>(string name, string key) =>
            this.GetCache(name).TryGetValue(key, out T? value) ? value : default;
    }
}

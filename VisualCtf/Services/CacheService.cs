using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using VisualCtf.ViewModels;

namespace VisualCtf.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;
        private const string _cachePrefix = "state_";

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void CacheAppState(AppState appState)
        {
            _cache.Set(_cachePrefix + appState.ApiKey, appState,
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1)));
        }

        public AppState GetAppState(string apiKey)
        {
            _cache.TryGetValue(_cachePrefix + apiKey, out AppState appState);
            return appState;
        }
    }
}

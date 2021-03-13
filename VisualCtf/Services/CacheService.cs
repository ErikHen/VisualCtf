using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using VisualCtf.Services.CtfDelivery;
using VisualCtf.ViewModels;

namespace VisualCtf.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;
        private const string _statePrefix = "state_";
        private const string _pagePrefix = "pages_";

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void CacheAppState(AppState appState)
        {
            _cache.Set(_statePrefix + appState.ApiKey, appState,
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1)));
        }

        public AppState GetAppState(string apiKey)
        {
            _cache.TryGetValue(_statePrefix + apiKey, out AppState appState);
            return appState;
        }

        public void CachePages(IEnumerable<Page> pages)
        {
            _cache.Set(_pagePrefix, pages, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1)));
        }

        public IEnumerable<Page> GetPages()
        {
            _cache.TryGetValue(_pagePrefix, out IEnumerable<Page> pages);
            return pages;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Contentful.Core;
using Contentful.Core.Configuration;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Contentful.Core.Search;

namespace VisualCtf.Services.CtfDelivery
{
    /// <summary>
    /// The CtfDeliveryService and the accompanying POCO classes are used to fetch content only.
    /// It has nothing to do with the actual functionality of this tool.
    /// </summary>
    public class CtfDeliveryService
    {
        private ContentfulClient CtfClient { get; set; }
        private readonly CacheService _cacheService;

        public CtfDeliveryService(IConfiguration configuration, CacheService cacheService)
        {
            _cacheService = cacheService;
            CtfClient = new ContentfulClient(new HttpClient(), new ContentfulOptions { DeliveryApiKey = configuration["DeliveryApiKey"], SpaceId = configuration["DeliverySpaceId"]})
            {
                ResolveEntriesSelectively = true
            };
        }

        public async Task<Page> GetPage(string slug)
        {
            return (await GetPages()).FirstOrDefault(p => p.Slug == slug);
        }

        private async Task<IEnumerable<Page>> GetPages()
        {
            var pages = _cacheService.GetPages();
            if (pages == null)
            {
                var qb = new QueryBuilder<Page>();
                pages = (await CtfClient.GetEntriesByType("pageStandardPage", qb)).Items;
                _cacheService.CachePages(pages);
            }

            return pages;
        }

    }
}

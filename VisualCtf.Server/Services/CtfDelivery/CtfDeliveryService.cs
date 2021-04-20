using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Microsoft.Extensions.Configuration;
using VisualCtf.Shared.Models.CtfDelivery;
using VisualCtf.Shared.Services;

namespace VisualCtf.Server.Services.CtfDelivery
{
    /// <summary>
    /// The CtfDeliveryService and the accompanying POCO classes are used to fetch content only.
    /// It has nothing to do with the actual functionality of this tool.
    /// </summary>
    public class CtfDeliveryService : ICtfDeliveryService
    {
        private ContentfulClient CtfClient { get; set; }
        private readonly CacheService _cacheService;
        private readonly HtmlRenderer _htmlRenderer;

        public CtfDeliveryService(IConfiguration configuration, CacheService cacheService)
        {
            _cacheService = cacheService;
            CtfClient = new ContentfulClient(new HttpClient(), new ContentfulOptions { DeliveryApiKey = configuration["DeliveryApiKey"], SpaceId = configuration["DeliverySpaceId"]})
            {
                ResolveEntriesSelectively = true
            };
            _htmlRenderer = new HtmlRenderer();
            _htmlRenderer.AddRenderer(new LinkContentRenderer {Order = 10});
        }

        public async Task<PageContent> GetPage(string slug)
        {
            var asdf = (await GetPages()).FirstOrDefault(p => p.Slug == slug);
            return asdf;
        }

        private async Task<IEnumerable<PageContent>> GetPages()
        {
            var pages = _cacheService.GetPages();
            if (pages == null)
            {
                var qb = new QueryBuilder<PageEntry>();
                pages = (await CtfClient.GetEntriesByType("pageStandardPage", qb)).Items
                    .Select(x =>
                    {
                        x.MainTextHtml = _htmlRenderer.ToHtml(x.MainText).Result;
                        return x;
                    });
                _cacheService.CachePages(pages);
            }

            return pages;
        }



    }
}

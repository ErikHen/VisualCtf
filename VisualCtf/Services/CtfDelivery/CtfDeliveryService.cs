using Contentful.Core;
using Contentful.Core.Configuration;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace VisualCtf.Services.CtfDelivery
{
    /// <summary>
    /// The CtfDeliveryService and the accompanying POCO classes are used to fetch content only.
    /// It has nothing to do with the actual functionality of this tool.
    /// </summary>
    public class CtfDeliveryService
    {
        private readonly IConfiguration _configuration;

        public CtfDeliveryService(IConfiguration configuration)
        {
            _configuration = configuration;
            CtfClient = new ContentfulClient(new HttpClient(), new ContentfulOptions { DeliveryApiKey = _configuration["DeliveryApiKey"], SpaceId = _configuration["DeliverySpaceId"] });
        }

        public ContentfulClient CtfClient { get; set; }

    }
}

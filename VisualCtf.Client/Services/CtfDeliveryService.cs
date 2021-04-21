using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;
using VisualCtf.Shared.Models.CtfDelivery;
using VisualCtf.Shared.Services;

namespace VisualCtf.Client.Services
{
    public class CtfDeliveryService : ICtfDeliveryService
    {
        private readonly HttpClient _httpClient;

        public CtfDeliveryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PageContent> GetPage(string slug)
        {
            return await _httpClient.GetFromJsonAsync<PageContent>($"api/ctfdelivery/page/{WebUtility.UrlEncode(slug)}");
        }
    }
}

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VisualCtf.Shared.Models.CtfDelivery;
using VisualCtf.Shared.Services;

namespace VisualCtf.Client.Services
{
    public class CtfDeliveryService : ICtfDeliveryService
    {
        private readonly HttpClient _httpClient;
        private readonly IWebAssemblyHostEnvironment _hostEnvironment;

        public CtfDeliveryService(HttpClient httpClient, IWebAssemblyHostEnvironment hostEnvironment)
        {
            _httpClient = httpClient;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<PageContent> GetPage(string slug)
        {
            var encodedSlug = WebUtility.UrlEncode(slug);
            if (!_hostEnvironment.IsDevelopment())
            {
                encodedSlug = WebUtility.UrlEncode(encodedSlug); //double url encoding needed when hosted in Azure web app
            }
            return await _httpClient.GetFromJsonAsync<PageContent>($"api/ctfdelivery/page/{encodedSlug}");
        }
    }
}

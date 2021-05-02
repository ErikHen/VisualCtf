using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;
using VisualCtf.Shared.Services;

namespace VisualCtf.Client.Services
{
    public class CtfService : CtfServiceBase, ICtfService
    {
        private readonly HttpClient _httpClient;

        public CtfService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<VisualSpace>> GetSpaces(string key)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<VisualSpace>>($"api/ctf/spaces/{key}");
        }

        public async Task<IEnumerable<VisualTypeGroup>> GetTypes(string key, string spaceId, string separator)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<VisualTypeGroup>>($"api/ctf/types/{key}/{spaceId}/{separator}");
        }

    }
}

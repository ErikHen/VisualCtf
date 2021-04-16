using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;
using VisualCtf.Shared.Services;

namespace VisualCtf.Client.Services
{
    public class CtfService : ICtfService
    {
        private readonly HttpClient _httpClient;

        public CtfService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetUser(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VisualSpace>> GetSpaces(string key)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<VisualSpace>>($"api/ctf/spaces/{key}");
        }

    }
}

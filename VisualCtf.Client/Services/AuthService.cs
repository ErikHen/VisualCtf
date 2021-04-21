using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;
using VisualCtf.Shared.Services;

namespace VisualCtf.Client.Services
{
    public class AuthService : IAuthService
    {
        private User _user;
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<User> CurrentUser()
        {
            _user ??= await _httpClient.GetFromJsonAsync<User>("account/getuser");
            return _user;
        }

    }
}

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

        //todo: this should be in base class
        public IEnumerable<VisualTypeGroup> GroupTypes(IEnumerable<VisualType> visualTypes, string groupNameSeparator)
        {
            var typeGroups = new List<VisualTypeGroup>();
            foreach (var type in visualTypes)
            {
                var groupName = GetGroupName(type.Name, groupNameSeparator);
                var typeGroup = typeGroups.FirstOrDefault(t => t.Name == groupName);
                if (typeGroup == null)
                {
                    typeGroup = new VisualTypeGroup(groupName);
                    typeGroups.Add(typeGroup);
                }
                typeGroup.Types.Add(type);
            }

            return typeGroups.OrderBy(t => t.Name);
        }
        private static string GetGroupName(string ctfTypeName, string groupNameSeparator)
        {
            var position = ctfTypeName.LastIndexOf(groupNameSeparator, StringComparison.InvariantCulture);
            return position == -1 ? "Other" : ctfTypeName.Substring(0, position);
        }

        public async Task<IEnumerable<VisualTypeGroup>> GetTypes(string key, string spaceId, string separator)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<VisualTypeGroup>>($"api/ctf/types/{key}/{spaceId}/{separator}");
        }

    }
}

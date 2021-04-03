using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Models.Management;
using VisualCtf.ViewModels;

namespace VisualCtf.Server.Services
{
    public class CtfService
    {
        private readonly HttpClient _httpClient;

        public CtfService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<User> GetUser(string key)
        {
            var ctfClient = new ContentfulManagementClient(_httpClient, new ContentfulOptions { ManagementApiKey = key });
            var user = await ctfClient.GetCurrentUser(); 
            return user;
        }

        private IEnumerable<VisualTypeGroup> GetTypeGroups(IEnumerable<VisualType> visualTypes, string groupNameSeparator)
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

        //public async Task GetTypes(AppState appState)
        //{
        //    var ctfClient = new ContentfulManagementClient(_httpClient, new ContentfulOptions { ManagementApiKey = appState.ApiKey, SpaceId = appState.CurrentSpaceId });
        //    var ctfTypes = (await ctfClient.GetContentTypes()).OrderBy(c => c.Name).ToList();
        //    appState.TypeGroups = GetTypeGroups(ctfTypes.Select(c => new VisualType(c)), appState.GroupNameSeparator);
        //    appState.TypeNameMapping = new Dictionary<string, string>();
        //    foreach (var type in ctfTypes)
        //    {
        //        appState.TypeNameMapping.Add(type.SystemProperties.Id, type.Name);
        //    }
            
        //}

        public async Task<IEnumerable<Space>> GetSpaces(string key)
        {
            var ctfClient = new ContentfulManagementClient(_httpClient, new ContentfulOptions { ManagementApiKey = key });
            var ctfSpaces = await ctfClient.GetSpaces();
            return ctfSpaces;
        }

        //public async Task RevokeToken(string key)
        //{
        //    var ctfClient = new ContentfulManagementClient(_httpClient, new ContentfulOptions { ManagementApiKey = key });
        //    var token = (await ctfClient.GetAllManagementTokens()).Where(t => t.Name != "qwe");
        //    var ctfSpaces = await ctfClient.GetUser("qwe"); // .RevokeManagementToken(key);
        //}

        private static string GetGroupName(string ctfTypeName, string groupNameSeparator)
        {
            var position = ctfTypeName.LastIndexOf(groupNameSeparator, StringComparison.InvariantCulture);
            return position == -1 ? "Other" : ctfTypeName.Substring(0, position);
        }
    }
}

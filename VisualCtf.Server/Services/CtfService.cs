using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Configuration;
using VisualCtf.Server.Factories;
using VisualCtf.Shared.Models;
using VisualCtf.Shared.Services;

namespace VisualCtf.Server.Services
{
    public class CtfService : CtfServiceBase, ICtfService
    {
        private readonly HttpClient _httpClient;

        public CtfService()
        {
            _httpClient = new HttpClient();
        }

        public override async Task<User> GetUser(string key)
        {
            
            var ctfClient = new ContentfulManagementClient(_httpClient, new ContentfulOptions { ManagementApiKey = key });
            var ctfUser = await ctfClient.GetCurrentUser(); 
            return new User
            {
                Name = ctfUser.FirstName, 
                Token = key
            };
        }

        public async Task<IEnumerable<VisualTypeGroup>> GetTypes(string key, string spaceId, string groupNameSeparator )
        {
            var ctfClient = new ContentfulManagementClient(_httpClient, new ContentfulOptions { ManagementApiKey = key, SpaceId = spaceId });
            var ctfTypes = (await ctfClient.GetContentTypes()).OrderBy(c => c.Name).ToList();
            return GroupTypes(ctfTypes.Select(VisualTypeFactory.CreateType), groupNameSeparator);
        }

        public async Task<IEnumerable<VisualSpace>> GetSpaces(string key)
        {
            var ctfClient = new ContentfulManagementClient(_httpClient, new ContentfulOptions { ManagementApiKey = key });
            var ctfSpaces = await ctfClient.GetSpaces();
            return ctfSpaces.Select(VisualSpaceFactory.CreateSpace);
        }

        //public async Task RevokeToken(string key)
        //{
        //    var ctfClient = new ContentfulManagementClient(_httpClient, new ContentfulOptions { ManagementApiKey = key });
        //    var token = (await ctfClient.GetAllManagementTokens()).Where(t => t.Name != "qwe");
        //    var ctfSpaces = await ctfClient.GetUser("qwe"); // .RevokeManagementToken(key);
        //}
    }
}

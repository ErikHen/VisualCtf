using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;

namespace VisualCtf.Shared.Services
{
    public abstract class CtfServiceBase
    {
        public virtual async Task<User> GetUser(string key)
        {
            throw new NotImplementedException();
        }

        public void FilterTypes(IEnumerable<VisualType> types, string searchTerm)
        {
            var st = searchTerm.ToLower();
            

            foreach (var visualType in types)
            {
                var nameAndId = visualType.Name.ToLower() + "|" + visualType.Id.ToLower();
                if (nameAndId.Contains(st) || visualType.Fields.Any(f => (f.Name.ToLower() + "|" + f.Id.ToLower()).Contains(searchTerm)) || searchTerm == string.Empty)
                {
                    visualType.IsHidden = false;
                }
                else
                {
                    visualType.IsHidden = true;
                }
            }
        }

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

    }
}

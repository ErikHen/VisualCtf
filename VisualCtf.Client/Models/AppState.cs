using System.Collections.Generic;
using System.Linq;
using VisualCtf.ViewModels;

namespace VisualCtf.Client.Models
{
    public class AppState
    {
        public string CtfToken { get; }

        public IEnumerable<VisualType> Types => TypeGroups.SelectMany(g => g.Types).OrderBy(t => t.Name);

        public IEnumerable<VisualTypeGroup> TypeGroups { get; set; }
        /// <summary>
        /// Mapping type id to type name
        /// </summary>
        public Dictionary<string, string> TypeNameMapping { get; set; }
        public string CurrentSpaceId { get; set; }
        public bool DoGrouping { get; set; }
        public string SortGroupBy { get; set; }
        public string GroupNameSeparator { get; set; }

        public AppState(string ctfToken)
        {
            CtfToken = ctfToken;
            DoGrouping = true;
            SortGroupBy = "name";
            GroupNameSeparator = " > ";
        }
    }
}

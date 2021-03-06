using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core.Models;

namespace VisualCtf.ViewModels
{
    public class AppState
    {
        public string ApiKey { get; set; }

        public IEnumerable<VisualType> Types => TypeGroups.SelectMany(g => g.Types).OrderBy(t => t.Name);

        public IEnumerable<VisualTypeGroup> TypeGroups { get; set; }
        /// <summary>
        /// Mapping type id to type name
        /// </summary>
        public Dictionary<string, string> TypeNameMapping { get; set; }
        public IEnumerable<Space> Spaces { get; set; }
        public string CurrentSpaceId { get; set; }
        public bool DoGrouping { get; set; }
        public string GroupBy { get; set; } = "name";

        public AppState()
        {
           DoGrouping = true;
        }
    }
}

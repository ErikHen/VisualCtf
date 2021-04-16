using System.Collections.Generic;

namespace VisualCtf.Shared.Models
{
    public class VisualTypeGroup
    {
        public string Name { get; set; }
        public List<VisualType> Types { get; set; }

        public VisualTypeGroup(string name)
        {
            Name = name;
            Types = new List<VisualType>();
        }
    }
}

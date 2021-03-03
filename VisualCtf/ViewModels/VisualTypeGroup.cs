using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisualCtf.ViewModels
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

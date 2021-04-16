using System.Collections.Generic;
using VisualCtf.ViewModels;

namespace VisualCtf.Shared.Models
{
    public class VisualType : VisualBase
    {
        public string Description { get; set; }
        public string SpaceId { get; set; }
        public IEnumerable<VisualField> Fields { get; set; }
        public IEnumerable<FieldReference> FieldReferences { get; set; }
        public HighlightType Highlighted { get; set; }
        public bool IsExpanded { get; set; }
        public bool ShowDetails { get; set; }

        //public VisualType(ContentType ctfType)
        //{
            
        //}

        
    }

    public enum HighlightType
    {
        None, SelectedParent, Selected, SelectedChild
    }


}

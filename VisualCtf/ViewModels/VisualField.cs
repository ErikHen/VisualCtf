using Contentful.Core.Models;
using System.Collections.Generic;

namespace VisualCtf.ViewModels
{
    public class VisualField : VisualBase
    {
        public string Type { get; set; }
        public string ArrayType { get; set; }
        public string FriendlyTypeName { get; set; }
        //{
        //    get
        //    {
        //        if (!_friendlyTypeNames.TryGetValue(Type + ArrayType, out var friendlyName))
        //        {
        //            friendlyName = Type;
        //        }
        //        return friendlyName;
        //    }
        //}

        public VisualField(Field ctfField)
        {
            Id = ctfField.Id;
            Name = ctfField.Name;
            Type = ctfField.Type;
            ArrayType = ctfField.Items?.Type;
            FriendlyTypeName = _friendlyTypeNames.TryGetValue(Type + ArrayType, out var friendlyName) ? friendlyName : Type;
        }

        private readonly Dictionary<string, string> _friendlyTypeNames = new()
        {
            { "Link", "Reference (1)" },
            { "ArrayLink", "Reference (many)" },
            { "Symbol", "Text" }
        };

    }
}

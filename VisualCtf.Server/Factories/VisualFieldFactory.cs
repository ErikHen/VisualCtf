using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core.Models;
using VisualCtf.ViewModels;

namespace VisualCtf.Server.Factories
{
    public static class VisualFieldFactory
    {
        public static VisualField CreateVisualField(Field ctfField)
        {
            return new VisualField
            {
                Id = ctfField.Id,
                Name = ctfField.Name,
                Type = ctfField.Type,
                ArrayType = ctfField.Items?.Type,
                FriendlyTypeName = _friendlyTypeNames.TryGetValue(ctfField.Type + ctfField.Items?.Type, out var friendlyName) ? friendlyName : ctfField.Type
            };
        }

        private static readonly Dictionary<string, string> _friendlyTypeNames = new()
        {
            { "Link", "Reference (1)" },
            { "ArrayLink", "Reference (many)" },
            { "Symbol", "Text" }
        };
    }
}

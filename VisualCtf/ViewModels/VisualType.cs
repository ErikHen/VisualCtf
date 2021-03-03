using Contentful.Core.Models;
using Contentful.Core.Models.Management;
using System.Collections.Generic;
using System.Linq;

namespace VisualCtf.ViewModels
{
    public class VisualType
    {
        public ContentType CtfType { get; set; }
        public IEnumerable<FieldReference> FieldReferences { get; set; }
        public HighlightType Highlighted { get; set; }

        public VisualType(ContentType ctfType)
        {
            CtfType = ctfType;
            FieldReferences = GetReferences(ctfType);
            Highlighted = HighlightType.None;
        }

        private IEnumerable<FieldReference> GetReferences(ContentType ctfType)
        {
            var refFields = CtfType.Fields.Where(f => f.LinkType == "Entry" && f.Validations.Any(v => v is LinkContentTypeValidator))
                .Select(f => new FieldReference
                {
                    fieldName = f.Name,
                    referenceTypes = f.Validations.Where(v => v is LinkContentTypeValidator).SelectMany(v => ((LinkContentTypeValidator)v).ContentTypeIds)
                });

            var arrayRefFields = CtfType.Fields.Where(f => f.Type == "Array" && f.Items.LinkType == "Entry" && f.Items.Validations.Any(v => v is LinkContentTypeValidator))
                .Select(f => new FieldReference
                {
                    fieldName = f.Name,
                    referenceTypes = f.Items.Validations.Where(v => v is LinkContentTypeValidator).SelectMany(v => ((LinkContentTypeValidator)v).ContentTypeIds)
                });

            return refFields.Concat(arrayRefFields);
        }
    }

    public enum HighlightType
    {
        None, SelectedParent, Selected, SelectedChild
    }


}

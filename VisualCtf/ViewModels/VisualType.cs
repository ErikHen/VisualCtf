using System;
using Contentful.Core.Models;
using Contentful.Core.Models.Management;
using System.Collections.Generic;
using System.Linq;

namespace VisualCtf.ViewModels
{
    public class VisualType : VisualBase
    {
        public string Description { get; set; }
        public string SpaceId { get; set; }
        public IEnumerable<VisualField> Fields { get; set; }
        public IEnumerable<FieldReference> FieldReferences { get; set; }
        public HighlightType Highlighted { get; set; }
        public bool IsExpanded { get; set; }

        public VisualType(ContentType ctfType)
        {
            Id = ctfType.SystemProperties.Id;
            Name = ctfType.Name;
            Description = ctfType.Description;
            SpaceId = ctfType.SystemProperties.Space.SystemProperties.Id;
            Fields = ctfType.Fields.Select(f => new VisualField(f));
            FieldReferences = GetReferences(ctfType);
            Highlighted = HighlightType.None;
        }

        private IEnumerable<FieldReference> GetReferences(ContentType ctfType)
        {
            

            var refFields = ctfType.Fields.Where(f => f.LinkType == "Entry" && f.Validations.Any(v => v is LinkContentTypeValidator))
                .Select(f => new FieldReference
                {
                    fieldName = f.Name,
                    referenceTypes = f.Validations.Where(v => v is LinkContentTypeValidator).SelectMany(v => ((LinkContentTypeValidator)v).ContentTypeIds)
                });

            var arrayRefFields = ctfType.Fields.Where(f => f.Type == "Array" && f.Items.LinkType == "Entry" && f.Items.Validations.Any(v => v is LinkContentTypeValidator))
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

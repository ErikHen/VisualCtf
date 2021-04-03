using Contentful.Core.Models;
using Contentful.Core.Models.Management;
using System.Collections.Generic;
using System.Linq;
using VisualCtf.ViewModels;

namespace VisualCtf.Server.Factories
{
    public static class VisualTypeFactory
    {
        public static VisualType CreateType(ContentType ctfType)
        {
            return new VisualType
            {
                Id = ctfType.SystemProperties.Id,
                Name = ctfType.Name,
                Description = ctfType.Description,
                SpaceId = ctfType.SystemProperties.Space.SystemProperties.Id,
                Fields = ctfType.Fields.Select(VisualFieldFactory.CreateVisualField),
                FieldReferences = GetReferences(ctfType),
                Highlighted = HighlightType.None
            };
        }

        private static IEnumerable<FieldReference> GetReferences(ContentType ctfType)
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
}

using System.Collections.Generic;

namespace VisualCtf.Shared.Models
{
    public class FieldReference
    {
        public string fieldName { get; set; }
        public IEnumerable<string> referenceTypes { get; set; }
    }
}

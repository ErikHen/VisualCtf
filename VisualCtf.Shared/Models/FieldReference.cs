using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisualCtf.ViewModels
{
    public class FieldReference
    {
        public string fieldName { get; set; }
        public IEnumerable<string> referenceTypes { get; set; }
    }
}

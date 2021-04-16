using System.Collections.Generic;
using VisualCtf.Shared.Models;

namespace VisualCtf.ViewModels
{
    public class VisualField : VisualBase
    {
        public string Type { get; set; }
        public string ArrayType { get; set; }
        public string FriendlyTypeName { get; set; }
    }
}

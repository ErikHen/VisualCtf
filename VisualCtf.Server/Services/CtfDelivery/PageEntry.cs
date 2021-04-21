using System.Text.Json.Serialization;
using Contentful.Core.Models;
using VisualCtf.Shared.Models.CtfDelivery;

namespace VisualCtf.Server.Services.CtfDelivery
{
    public class PageEntry : PageContent
    {
        [JsonIgnore]
        public Document MainText { get; set; }
    }
}

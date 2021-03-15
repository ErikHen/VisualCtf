using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contentful.Core.Models;

namespace VisualCtf.Services.CtfDelivery
{

    public class LinkContentRenderer : IContentRenderer
    {
        public int Order { get; set; }

        public bool SupportsContent(IContent content)
        {
            return content is Hyperlink; 
        }

        public string Render(IContent content)
        {
            var link = (Hyperlink)content;
            var target = link.Data.Uri.StartsWith("http") ? "target=\"_blank\"" : string.Empty;
            return $"<a href=\"{link.Data.Uri}\" {target}>{((Text)link.Content[0]).Value}</a>";
        }

        public Task<string> RenderAsync(IContent content)
        {
            return Task.FromResult(Render(content));
        }
    }
}

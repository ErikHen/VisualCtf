using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core.Models;
using Newtonsoft.Json;

namespace VisualCtf.Services.CtfDelivery
{
   
    public class Page
    {
        public string PageName { get; set; }
        public string Slug { get; set; }
        public Document MainText { get; set; }
        public SeoInfo SeoInformation { get; set; }
    }
}

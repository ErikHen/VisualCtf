using Contentful.Core.Models;
using VisualCtf.Shared.Models;

namespace VisualCtf.Server.Factories
{
    public static class VisualSpaceFactory
    {
        public static VisualSpace CreateSpace(Space ctfSpace)
        {
            return new VisualSpace
            {
                Id = ctfSpace.SystemProperties.Id,
                Name = ctfSpace.Name,
              
            };
        }
    }
}

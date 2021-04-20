using System.Threading.Tasks;
using VisualCtf.Shared.Models.CtfDelivery;

namespace VisualCtf.Shared.Services
{
    public interface ICtfDeliveryService
    {
        Task<PageContent> GetPage(string slug);
    }
}

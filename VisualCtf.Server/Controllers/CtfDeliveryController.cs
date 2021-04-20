using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisualCtf.Shared.Services;

namespace VisualCtf.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CtfDeliveryController : ControllerBase
    {
        private readonly ICtfDeliveryService _ctfService;

        public CtfDeliveryController(ICtfDeliveryService ctfService)
        {
            _ctfService = ctfService;
        }

        [HttpGet]
        [Route("{slug}")]
        public async Task<IActionResult> Page(string slug)
        {
            return Ok(await _ctfService.GetPage(slug));
        }
    }
}

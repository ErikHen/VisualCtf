using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisualCtf.Shared.Services;

namespace VisualCtf.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CtfController : ControllerBase
    {
        private ICtfService _ctfService;

        public CtfController(ICtfService ctfService)
        {
            _ctfService = ctfService;
        }

        [HttpGet]
        [Route("{token}")]
        public async Task<IActionResult> Spaces(string token)
        {
            return Ok(await _ctfService.GetSpaces(token));
        }
    }
}

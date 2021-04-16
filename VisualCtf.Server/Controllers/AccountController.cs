using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using VisualCtf.Shared.Services;

namespace VisualCtf.Server.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        public static string CtfKeyClaimType => "CtfToken";
        private readonly ICtfService _ctfService;
        private readonly IAuthService _authService;


        public AccountController(ICtfService ctfService, IAuthService authService)
        {
            _ctfService = ctfService;
            _authService = authService;
        }

        [HttpGet]
        [Route("{token}")]
        public async Task<IActionResult> Login(string token)
        {
            
            var user = await _ctfService.GetUser(token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim(Shared.Models.User.CtfKeyClaimType, token));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Redirect("/");

        }

        public async Task<IActionResult> Logout()
        {
            //await _ctfService.RevokeToken(HttpContext.User.Claims.First(c => c.Type == "CtfToken").Value);
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _authService.CurrentUser());
        }
    }
}
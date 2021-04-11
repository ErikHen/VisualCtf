using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VisualCtf.Server.Services;
using VisualCtf.Shared.Services;

namespace VisualCtf.Server.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        public static string CtfKeyClaimType => "CtfToken";
        private readonly ICtfService _ctfService;
        private readonly IConfiguration _configuration;
        

        public AccountController(ICtfService ctfService, IConfiguration configuration)
        {
            _ctfService = ctfService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var host = HttpContext.Request.Host.ToString();
            var prefix = host.Contains("azurewebsite") ? "Azureweb" : "";
            var clientId = _configuration["OAuthClientId" + prefix];
            var authorizeUrl = $"https://be.contentful.com/oauth/authorize?response_type=token&client_id={clientId}&redirect_uri=https://{host}/signin/&scope=content_management_read";
            return Redirect(authorizeUrl);
        }

        [HttpGet]
        [Route("{token}")]
        public async Task<IActionResult> Login(string token)
        {
            var user = await _ctfService.GetUser(token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim(CtfKeyClaimType, token));
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
    }
}
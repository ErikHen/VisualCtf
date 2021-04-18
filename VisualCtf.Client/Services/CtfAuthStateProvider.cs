using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;
using VisualCtf.Shared.Services;

namespace VisualCtf.Client.Services
{
    public class CtfAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthService _authService;

        public CtfAuthStateProvider(IAuthService authService)
        {
            _authService = authService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await _authService.CurrentUser();

            var identity = new ClaimsIdentity();
            if (user?.Token != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("CtfToken", user.Token)
                };
                identity = new ClaimsIdentity(claims, "CtfAuth");
            }

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}

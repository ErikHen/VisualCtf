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
        private User _user;
        private readonly IAuthService _authService;

        public CtfAuthStateProvider(IAuthService authService)
        {
            _authService = authService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            _user ??= await _authService.CurrentUser();

            var identity = new ClaimsIdentity();
            if (_user?.Token != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, _user.Name),
                    new Claim("CtfToken", _user.Token)
                };
                identity = new ClaimsIdentity(claims, "CtfAuth");
            }

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}

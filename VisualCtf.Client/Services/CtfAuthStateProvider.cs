using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace VisualCtf.Client.Services
{
    public class CtfAuthStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            //var identity = IsAuthenticated
            //    ? new ClaimsIdentity(await userService.GetClaims(UserId))
            //    : new ClaimsIdentity();

            var identity = new ClaimsIdentity();

            var result = new AuthenticationState(new ClaimsPrincipal(identity));
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using VisualCtf.Client.Models;

namespace VisualCtf.Client.Services
{
    public class CtfAuthStateProvider : AuthenticationStateProvider
    {
      //  private readonly ILocalStorageService _localStorage;

        //public CtfAuthStateProvider(ILocalStorageService localStorage)
        //{
        //    _localStorage = localStorage;
        //}

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            //var appState = await _localStorage.GetItemAsync<AppState>("appstate");
            //if (!string.IsNullOrEmpty(appState?.CtfToken))
            //{
            //    var claims = new List<Claim>()
            //    {
            //        new Claim(ClaimTypes.Name, "TODO"),
            //        new Claim("CtfToken", appState.CtfToken)
            //    };
            //    identity = new ClaimsIdentity(claims);
            //}

            var result = new AuthenticationState(new ClaimsPrincipal(identity));
            return result;
        }

        
    }
}

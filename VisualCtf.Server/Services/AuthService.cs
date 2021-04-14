using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VisualCtf.Shared.Models;
using VisualCtf.Shared.Services;

namespace VisualCtf.Server.Services
{
    public class AuthService : IAuthService
    {
        public string CtfKeyClaimType => "CtfToken";

        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> CurrentUser()
        {
            var isAuthenticated = _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
            if (isAuthenticated)
            {
                return new User
                {
                    Name = _httpContextAccessor.HttpContext.User.Identity.Name,
                    Token = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == CtfKeyClaimType)?.Value
                };
            }

            return new User();
        }
    }
}

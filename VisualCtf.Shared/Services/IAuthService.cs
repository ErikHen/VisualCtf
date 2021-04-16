using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;

namespace VisualCtf.Shared.Services
{
    public interface IAuthService
    {
       // string CtfKeyClaimType => "";
        Task<User> CurrentUser();
    }
}

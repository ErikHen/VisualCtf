﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;
using VisualCtf.ViewModels;

namespace VisualCtf.Shared.Services
{
    public interface ICtfService
    {
        Task<User> GetUser(string key);
        Task<IEnumerable<VisualSpace>> GetSpaces(string key);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCtf.Shared.Models
{
    public class User
    {
        public static string CtfKeyClaimType => "CtfToken";

        public string Name { get; set; }
        public string Token { get; set; }
    }
}

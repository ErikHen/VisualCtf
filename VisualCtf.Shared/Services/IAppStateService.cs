﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;

namespace VisualCtf.Shared.Services
{
    public interface IAppStateService
    {
        event Action OnChange;
        AppState AppState { get; }
        void Set(AppState state);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisualCtf.Client.Models;

namespace VisualCtf.Client.Services
{
    public class AppStateService
    {
        public AppState AppState { get; private set; }

        public async Task Set(AppState state)
        {
            AppState = state;
        }
    }
}

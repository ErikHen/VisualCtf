using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;
using VisualCtf.Shared.Services;

namespace VisualCtf.Client.Services
{
    public class AppStateService : IAppStateService
    {
        public event Action OnChange;
        public AppState AppState { get; private set; }

        public async Task Set(AppState state)
        {
            AppState = state;
            OnChange?.Invoke();
        }
    }
}

using System;
using VisualCtf.Shared.Models;

namespace VisualCtf.Shared.Services
{
    public class AppStateService : IAppStateService
    {
        public event Action OnChange;
        public AppState AppState { get; private set; }

        public void Set(AppState state)
        {
            AppState = state;
            OnChange?.Invoke();
        }
    }
}

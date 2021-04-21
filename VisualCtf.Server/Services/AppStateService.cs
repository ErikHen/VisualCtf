using System;
using System.Threading.Tasks;
using VisualCtf.Shared.Models;
using VisualCtf.Shared.Services;

namespace VisualCtf.Server.Services
{
    public class AppStateService : IAppStateService
    {
        public AppState AppState { get; private set; }

        public async Task Set(AppState state)
        {
            throw new NotImplementedException();
        }

        public event Action OnChange;

        public bool IsServer => true;
    }
}

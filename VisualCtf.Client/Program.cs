using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using VisualCtf.Client.Services;
using VisualCtf.Shared.Services;

namespace VisualCtf.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
          //  builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICtfService, CtfService>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CtfAuthStateProvider>();
            builder.Services.AddSingleton<IAppStateService, AppStateService>();
            // builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddMudServices();



            await builder.Build().RunAsync();
        }
    }
}

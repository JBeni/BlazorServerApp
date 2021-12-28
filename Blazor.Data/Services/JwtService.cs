using Blazor.Data.Interfaces;
using Microsoft.JSInterop;

namespace Blazor.Data.Services
{
    public class JwtService : IJwtService
    {
        private readonly IJSRuntime jsRuntime;

        public JwtService(IJSRuntime _jsRuntime)
        {
            jsRuntime = _jsRuntime;
        }

        public async Task<string> GetTokenAsync()
        {
            return await jsRuntime.InvokeAsync<string>("Blazor.getToken");
        }

        public async Task<bool> SaveTokenAsync(string Token)
        {
            return await jsRuntime.InvokeAsync<bool>("Blazor.saveToken", Token);
        }

        public async Task<bool> DestroyTokenAsync()
        {
            return await jsRuntime.InvokeAsync<bool>("Blazor.destroyToken");
        }
    }
}

using Blazor.Data.Interfaces;
using Blazor.Data.Models;
using Blazor.Data.Responses;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace Blazor.Server
{
    public class AppState
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly IAccountService _accountService;
        public bool IsLoggedIn { get; private set; }

        public AppState(HttpClient httpClient, ILocalStorageService localStorage, IAccountService accountService)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _accountService = accountService;
        }

        public async Task Login(LoginCommand login)
        {
            var response = await _accountService.LoginAsync(login);

            if (response.Successful)
            {
                await SaveToken(response);
                await SetAuthorizationHeader();

                IsLoggedIn = true;
            }
        }

        public async Task Register(RegisterCommand register)
        {
            var response = await _accountService.RegisterAsync(register);

            if (response.Successful)
            {
                await SaveToken(response);
                await SetAuthorizationHeader();

                IsLoggedIn = true;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            IsLoggedIn = false;
        }

        public async Task<RequestResponse> GetLocalStorageToken()
        {
            var result = await _localStorage.GetItemAsync<string>("authToken");
            if (result == null) return new RequestResponse { Successful = false };

            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await _localStorage.GetItemAsync<string>("authToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                IsLoggedIn = true;
            }

            return new RequestResponse { Successful = true };
        }

        private async Task SaveToken(JwtTokenResponse response)
        {
            await _localStorage.SetItemAsync("authToken", response.Access_Token);
        }

        private async Task SetAuthorizationHeader()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await _localStorage.GetItemAsync<string>("authToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}

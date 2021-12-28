using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Blazor.Server.Filters
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        Claim _claim;

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "mrfibuli"),
            }, "Fake authentication type");

            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        //public ILocalStorageService _localStorageService { get; }
        //public IUserService _userService { get; set; }
        //private readonly HttpClient _httpClient;

        //public CustomAuthenticationStateProvider(ILocalStorageService localStorageService,
        //    IUserService userService,
        //    HttpClient httpClient)
        //{
        //    _localStorageService = localStorageService;
        //    _userService = userService;
        //    _httpClient = httpClient;
        //}

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //    var accessToken = await _localStorageService.GetItemAsync<string>("accessToken");

            //    ClaimsIdentity identity;

            //    if (accessToken != null && accessToken != string.Empty)
            //    {
            //        User user = await _userService.GetUserByAccessTokenAsync(accessToken);
            //        identity = GetClaimsIdentity(user);
            //    }
            //    else
            //    {
            //        identity = new ClaimsIdentity();
            //    }

            var claimsPrincipal = new ClaimsPrincipal();// = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        //public async Task MarkUserAsAuthenticated(User user)
        //{
        //    await _localStorageService.SetItemAsync("accessToken", user.AccessToken);
        //    await _localStorageService.SetItemAsync("refreshToken", user.RefreshToken);

        //    var identity = GetClaimsIdentity(user);

        //    var claimsPrincipal = new ClaimsPrincipal(identity);

        //    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        //}

        //public async Task MarkUserAsLoggedOut()
        //{
        //    await _localStorageService.RemoveItemAsync("refreshToken");
        //    await _localStorageService.RemoveItemAsync("accessToken");

        //    var identity = new ClaimsIdentity();

        //    var user = new ClaimsPrincipal(identity);

        //    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        //}

        //private ClaimsIdentity GetClaimsIdentity(User user)
        //{
        //    var claimsIdentity = new ClaimsIdentity();

        //    if (user.EmailAddress != null)
        //    {
        //        claimsIdentity = new ClaimsIdentity(new[]
        //                        {
        //                            new Claim(ClaimTypes.Name, user.EmailAddress),
        //                            new Claim(ClaimTypes.Role, user.Role.RoleDesc),
        //                            new Claim("IsUserEmployedBefore1990", IsUserEmployedBefore1990(user))
        //                        }, "apiauth_type");
        //    }

        //    return claimsIdentity;
        //}

        //private string IsUserEmployedBefore1990(User user)
        //{
        //    if (user.HireDate.Value.Year < 1990)
        //        return "true";
        //    else
        //        return "false";
        //}
    }
}

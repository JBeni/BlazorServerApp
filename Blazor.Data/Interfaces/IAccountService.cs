using Blazor.Data.Models;
using Blazor.Data.Responses;
using Blazor.Models.Identity;

namespace Blazor.Data.Interfaces
{
    public interface IAccountService
    {
        Task<JwtTokenResponse> GenerateToken(AppUser user);
        Task<JwtTokenResponse> LoginAsync(LoginCommand login);
        Task<JwtTokenResponse> RegisterAsync(RegisterCommand register);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
    }
}

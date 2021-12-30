namespace Blazor.Data.Interfaces
{
    public interface IAppRoleService
    {
        Task<List<string>> CheckUserRolesAsync(AppUser user);
        AppRoleResponse GetDefaultRole();

        Task<RequestResponse> SetUserRoleAsync(AppUser user, string role);
    }
}

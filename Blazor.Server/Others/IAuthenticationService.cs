namespace Blazor.Server.Others
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUserModel> Login(AuthenticationUserModel userForAuthenticatrion);
        Task Logout();
    }
}
namespace Blazor.Data.Interfaces
{
    public interface IJwtService
    {
        Task<string> GetTokenAsync();
        Task<bool> SaveTokenAsync(string Token);
        Task<bool> DestroyTokenAsync();
    }
}

namespace Blazor.Data.Interfaces
{
    public interface IApiService
    {
        void SetToken(string token);
        void ClearToken();
    }
}

namespace Blazor.Domain.Identity
{
    public class AppUserToken : IdentityUserToken<int>
    {
        public int Id { get; set; }
    }
}

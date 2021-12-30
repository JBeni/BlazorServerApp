namespace Blazor.Domain.Identity
{
    public class AppUserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }
}

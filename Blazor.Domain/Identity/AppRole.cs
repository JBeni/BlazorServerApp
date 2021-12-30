namespace Blazor.Domain.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUser>? Users { get; set; }
    }
}

namespace Blazor.Models.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUser>? Users { get; set; }
    }
}

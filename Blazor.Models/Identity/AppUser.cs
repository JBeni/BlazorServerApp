using Microsoft.AspNetCore.Identity;

namespace Blazor.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<AppRole>? Roles { get; set; }
    }
}

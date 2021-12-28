using Microsoft.AspNetCore.Identity;

namespace Blazor.Models.Identity
{
    public class AppUserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }
}

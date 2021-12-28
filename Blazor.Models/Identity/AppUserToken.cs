using Microsoft.AspNetCore.Identity;

namespace Blazor.Models.Identity
{
    public class AppUserToken : IdentityUserToken<int>
    {
        public int Id { get; set; }
    }
}

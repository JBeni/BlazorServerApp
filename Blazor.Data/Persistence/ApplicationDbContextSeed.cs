using Blazor.Data.Utils;
using Blazor.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Blazor.Data.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAdminUserAsync(
            RoleManager<AppRole> roleManager,
            SeedDataModel seedData)
        {
            var adminRole = new AppRole
            {
                Name = seedData.AdminRoleName,
                NormalizedName = seedData.AdminRoleNormalized
            };

            var defaultRole = new AppRole
            {
                Name = seedData.DefaultRoleName,
                NormalizedName = seedData.DefaultRoleNormalized
            };

            if (roleManager.Roles.All(r => r.Name != adminRole.Name))
            {
                await roleManager.CreateAsync(adminRole);
            }
            if (roleManager.Roles.All(r => r.Name != defaultRole.Name))
            {
                await roleManager.CreateAsync(defaultRole);
            }
        }
    }
}

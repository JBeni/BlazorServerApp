using Blazor.Models;
using Blazor.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Blazor.Data.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedRolesDataAsync(RoleManager<AppRole> roleManager)
        {
            var adminRole = new AppRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            var defaultRole = new AppRole
            {
                Name = "Default",
                NormalizedName = "DEFAULT"
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

        public static async Task SeedCityData(ApplicationDbContext context)
        {
            if (!context.Cities.Any())
            {
                context.Cities.Add(new City
                {
                    CityId = 1,
                    CityName = "London",
                });
                context.Cities.Add(new City
                {
                    CityId = 2,
                    CityName = "Madrid",
                });
                context.Cities.Add(new City
                {
                    CityId = 3,
                    CityName = "Berlin",
                });
                context.Cities.Add(new City
                {
                    CityId = 4,
                    CityName = "Rome",
                });
                context.Cities.Add(new City
                {
                    CityId = 5,
                    CityName = "San Diego",
                });
                await context.SaveChangesAsync();
            }
        }
    }
}

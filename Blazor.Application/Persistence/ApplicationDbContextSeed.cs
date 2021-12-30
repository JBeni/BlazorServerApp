namespace Blazor.Application.Persistence
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

        public static async Task SeedSizeData(ApplicationDbContext context)
        {
            if (!context.Sizes.Any())
            {
                context.Sizes.Add(new Size { Id = 1, Name = "Small" });
                context.Sizes.Add(new Size { Id = 2, Name = "Small Medium" });
                context.Sizes.Add(new Size { Id = 3, Name = "Medium" });
                context.Sizes.Add(new Size { Id = 4, Name = "Large" });
                context.Sizes.Add(new Size { Id = 5, Name = "Extra Large" });
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedColourData(ApplicationDbContext context)
        {
            if (!context.Colours.Any())
            {
                context.Colours.Add(new Colour { Id = 1, Name = "Red" });
                context.Colours.Add(new Colour { Id = 2, Name = "Green" });
                context.Colours.Add(new Colour { Id = 3, Name = "Pink" });
                context.Colours.Add(new Colour { Id = 4, Name = "Brown" });
                context.Colours.Add(new Colour { Id = 5, Name = "Yellow" });
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedCityData(ApplicationDbContext context)
        {
            if (!context.Cities.Any())
            {
                context.Cities.Add(new City { CityId = 1, CityName = "London" });
                context.Cities.Add(new City { CityId = 2, CityName = "Madrid" });
                context.Cities.Add(new City { CityId = 3, CityName = "Berlin" });
                context.Cities.Add(new City { CityId = 4, CityName = "Rome" });
                context.Cities.Add(new City { CityId = 5, CityName = "San Diego" });
                await context.SaveChangesAsync();
            }
        }
    }
}

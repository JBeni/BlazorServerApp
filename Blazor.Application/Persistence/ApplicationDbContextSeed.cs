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
                context.Sizes.Add(new Size { Name = "Small" });
                context.Sizes.Add(new Size { Name = "Small Medium" });
                context.Sizes.Add(new Size { Name = "Medium" });
                context.Sizes.Add(new Size { Name = "Large" });
                context.Sizes.Add(new Size { Name = "Extra Large" });
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedColourData(ApplicationDbContext context)
        {
            if (!context.Colours.Any())
            {
                context.Colours.Add(new Colour { Name = "Red" });
                context.Colours.Add(new Colour { Name = "Green" });
                context.Colours.Add(new Colour { Name = "Pink" });
                context.Colours.Add(new Colour { Name = "Brown" });
                context.Colours.Add(new Colour { Name = "Yellow" });
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedCityData(ApplicationDbContext context)
        {
            if (!context.Cities.Any())
            {
                context.Cities.Add(new City { CityName = "London" });
                context.Cities.Add(new City { CityName = "Madrid" });
                context.Cities.Add(new City { CityName = "Berlin" });
                context.Cities.Add(new City { CityName = "Rome" });
                context.Cities.Add(new City { CityName = "San Diego" });
                await context.SaveChangesAsync();
            }
        }
    }
}

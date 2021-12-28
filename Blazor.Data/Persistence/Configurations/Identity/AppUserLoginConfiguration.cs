using Blazor.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blazor.Data.Persistence.Configurations.Id
{
    public class AppUserLoginConfiguration : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            builder.ToTable("AppUserLogins");
        }
    }
}

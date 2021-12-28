using Blazor.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blazor.Data.Persistence.Configurations.Id
{
    public class AppRoleClaimConfiguration : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.ToTable("AppRoleClaims");
        }
    }
}

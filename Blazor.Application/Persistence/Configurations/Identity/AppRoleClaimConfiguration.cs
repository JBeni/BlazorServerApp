﻿namespace Blazor.Application.Persistence.Configurations.Id
{
    public class AppRoleClaimConfiguration : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.ToTable("AppRoleClaims");
        }
    }
}
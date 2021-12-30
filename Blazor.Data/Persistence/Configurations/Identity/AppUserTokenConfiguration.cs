namespace Blazor.Data.Persistence.Configurations.Id
{
    public class AppUserTokenConfiguration : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
            builder.ToTable("AppUserTokens");
        }
    }
}

namespace Blazor.Application.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(x => x.CityId);
            builder.Property(e => e.CityId).HasColumnName("CityID");
            builder.Property(e => e.CityName)
                .HasMaxLength(150)
                .IsUnicode(false);
        }
    }
}

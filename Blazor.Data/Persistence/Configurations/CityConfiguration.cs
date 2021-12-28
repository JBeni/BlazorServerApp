using Blazor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blazor.Data.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.Property(e => e.CityId).HasColumnName("CityID");
            builder.Property(e => e.CityName)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasData
            (
                new City
                {
                    CityId = 1,
                    CityName = "London",
                },
                new City
                {
                    CityId = 2,
                    CityName = "Madrid",
                },
                new City
                {
                    CityId = 3,
                    CityName = "Berlin",
                },
                new City
                {
                    CityId = 4,
                    CityName = "Rome",
                },
                new City
                {
                    CityId = 5,
                    CityName = "San Diego",
                }
            );
        }
    }
}

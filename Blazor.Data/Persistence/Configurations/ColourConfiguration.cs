using Blazor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blazor.Data.Persistence.Configurations
{
    public class ColourConfiguration : IEntityTypeConfiguration<Colour>
    {
        public void Configure(EntityTypeBuilder<Colour> builder)
        {
            builder.ToTable("Colours");

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        }
    }
}

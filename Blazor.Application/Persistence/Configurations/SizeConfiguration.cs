namespace Blazor.Application.Persistence.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Sizes");

            builder.HasKey(x => x.Id);
            //builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        }
    }
}

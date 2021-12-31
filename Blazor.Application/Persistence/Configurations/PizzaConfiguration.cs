namespace Blazor.Application.Persistence.Configurations
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable("Pizzas");

            builder.HasKey(x => x.Id);
            //builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

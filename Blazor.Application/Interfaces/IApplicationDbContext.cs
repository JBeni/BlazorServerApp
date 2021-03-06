namespace Blazor.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Todo> Todos { get; set; }
        DbSet<Colour> Colours { get; set; }
        DbSet<Size> Sizes { get; set; }
        DbSet<Pizza> Pizzas { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

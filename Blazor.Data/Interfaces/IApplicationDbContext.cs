using Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Data.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Employee> Employees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

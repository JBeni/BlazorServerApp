namespace Blazor.RepositoryPattern.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository Cities { get; }
        IColourRepository Colours { get; }
        IEmployeeRepository Employees { get; }
        IPizzaRepository Pizzas { get; }
        IProductRepository Products { get; }
        ISizeRepository Sizes { get; }
        ITodoRepository Todos { get; }

        int Complete();
    }
}

namespace Blazor.RepositoryPattern.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICityRepository Cities { get; }
        public IColourRepository Colours { get; }
        public IEmployeeRepository Employees { get; }
        public IPizzaRepository Pizzas { get; }
        public IProductRepository Products { get; }
        public ISizeRepository Sizes { get; }
        public ITodoRepository Todos { get; }

        public UnitOfWork(ApplicationDbContext appDbContext,
                          ICityRepository cityRepository,
                          IColourRepository colourRepository,
                          IEmployeeRepository employeeRepository,
                          IPizzaRepository pizzaRepository,
                          IProductRepository productRepository,
                          ISizeRepository sizeRepository,
                          ITodoRepository todoRepository)
        {
            _context = appDbContext;

            Cities = cityRepository;
            Colours = colourRepository;
            Employees = employeeRepository;
            Pizzas = pizzaRepository;
            Products = productRepository;
            Sizes = sizeRepository;
            Todos = todoRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}

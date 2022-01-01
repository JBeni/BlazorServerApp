namespace Blazor.RepositoryPattern.Repositories
{
    public class PizzaRepository : GenericRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

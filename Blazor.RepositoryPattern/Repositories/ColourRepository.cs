namespace Blazor.RepositoryPattern.Repositories
{
    public class ColourRepository : GenericRepository<Colour>, IColourRepository
    {
        public ColourRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

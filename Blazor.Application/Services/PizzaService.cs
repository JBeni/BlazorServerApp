namespace Blazor.Application.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PizzaService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<PizzaResponse> GetPizzas()
        {
            try
            {
                var result = _dbContext.Pizzas
                    .ProjectTo<PizzaResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddPizza(PizzaResponse pizza)
        {
            try
            {
                var entity = _dbContext.Pizzas.FirstOrDefault(x => x.Id == pizza.Id);
                if (entity != null) return;

                entity = new Pizza
                {
                    Name = pizza.Name,
                    Description = pizza.Description,
                    Price = pizza.Price,
                    ImagePath = pizza.ImagePath,
                    ImageName = pizza.ImageName,
                    Size = pizza.Size,
                };

                _dbContext.Pizzas.Add(entity);
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdatePizza(PizzaResponse pizza)
        {
            try
            {
                Pizza? entity = _dbContext.Pizzas.FirstOrDefault(x => x.Id == pizza.Id);
                if (entity == null) return;

                entity.Name = pizza.Name;
                entity.Description = pizza.Description;
                entity.Price = pizza.Price;
                entity.ImagePath = pizza.ImagePath;
                entity.ImageName = pizza.ImageName;
                entity.Size = pizza.Size;

                _dbContext.Pizzas.Update(entity);
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }
            catch
            {
                throw;
            }
        }

        public PizzaResponse GetPizza(int id)
        {
            try
            {
                var pizza = _dbContext.Pizzas.AsNoTracking()
                    .Where(x => x.Id == id)
                    .ProjectTo<PizzaResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                if (pizza != null)
                {
                    return pizza;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task DeletePizza(int id)
        {
            try
            {
                Pizza? pizza = _dbContext.Pizzas.Find(id);

                if (pizza != null)
                {
                    _dbContext.Pizzas.Remove(pizza);
                    await _dbContext.SaveChangesAsync(new CancellationToken());
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

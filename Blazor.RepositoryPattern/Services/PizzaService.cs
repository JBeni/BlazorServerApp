namespace Blazor.RepositoryPattern.Services
{
    public class PizzaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PizzaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<PizzaResponse> GetAllPizzas()
        {
            try
            {
                var result = _unitOfWork.Pizzas.GetAll();
                var pizzas = _mapper.Map<List<PizzaResponse>>(result);
                return pizzas;
            }
            catch
            {
                throw;
            }
        }

        public void AddPizza(PizzaResponse pizza)
        {
            try
            {
                var entity = _unitOfWork.Pizzas.Get(pizza.Id);
                if (entity != null) return;

                entity = new Pizza
                {
                    Name = pizza.Name,
                    Description = pizza.Description,
                    Size = pizza.Size,
                    Price = pizza.Price,
                    ImagePath = pizza.ImagePath,
                    ImageName = pizza.ImageName,
                };

                _unitOfWork.Pizzas.Add(entity);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public void UpdatePizza(PizzaResponse pizza)
        {
            try
            {
                var entity = _unitOfWork.Pizzas.Get(pizza.Id);
                if (entity == null) return;

                entity.Name = pizza.Name;
                entity.Description = pizza.Description;
                entity.Size = pizza.Size;
                entity.Price = pizza.Price;
                entity.ImagePath = pizza.ImagePath;
                entity.ImageName = pizza.ImageName;

                _unitOfWork.Pizzas.Update(entity);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public PizzaResponse GetPizzaData(int id)
        {
            try
            {
                var result = _unitOfWork.Pizzas.Get(id);
                var pizza = _mapper.Map<PizzaResponse>(result);

                return pizza == null ? throw new ArgumentNullException() : pizza;
            }
            catch
            {
                throw;
            }
        }

        public void DeletePizza(int id)
        {
            try
            {
                Pizza? pizza = _unitOfWork.Pizzas.Get(id);

                if (pizza == null) throw new ArgumentNullException();
                _unitOfWork.Pizzas.Delete(pizza);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }
    }
}

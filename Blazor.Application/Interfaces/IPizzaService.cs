namespace Blazor.Application.Interfaces
{
    public interface IPizzaService
    {
        public List<PizzaResponse> GetPizzas();
        public Task AddPizza(PizzaResponse pizza);
        public Task UpdatePizza(PizzaResponse pizza);
        public PizzaResponse GetPizza(int id);
        public Task DeletePizza(int id);
    }
}

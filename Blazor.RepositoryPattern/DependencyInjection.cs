namespace Blazor.RepositoryPattern
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            // Inject services
            services.AddSingleton<WeatherForecastService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IColourRepository, ColourRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISizeRepository, SizeRepository>();
            services.AddTransient<ITodoRepository, TodoRepository>();

            services.AddScoped<CityService>();
            services.AddScoped<ColourService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<PizzaService>();
            services.AddScoped<ProductService>();
            services.AddScoped<SizeService>();
            services.AddScoped<TodoService>();

            return services;
        }
    }
}

namespace Blazor.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(typeof(CityResponse).Assembly);
            services.AddAutoMapper(typeof(ColourResponse).Assembly);
            services.AddAutoMapper(typeof(EmployeeResponse).Assembly);
            services.AddAutoMapper(typeof(PizzaResponse).Assembly);
            services.AddAutoMapper(typeof(ProductResponse).Assembly);
            services.AddAutoMapper(typeof(SizeResponse).Assembly);
            services.AddAutoMapper(typeof(TodoResponse).Assembly);

            return services;
        }
    }
}

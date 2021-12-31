namespace Blazor.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Inject services
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAppRoleService, AppRoleService>();
            services.AddTransient<IAppUserService, AppUserService>();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<ProductService>();
            services.AddScoped<TodoService>();

            return services;
        }
    }
}

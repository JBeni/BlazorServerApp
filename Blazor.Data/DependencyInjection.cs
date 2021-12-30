namespace Blazor.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddAutoMapper(typeof(EmployeeResponse));

            // Inject services
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAppRoleService, AppRoleService>();
            services.AddTransient<IAppUserService, AppUserService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<TodoService>();

            return services;
        }
    }
}

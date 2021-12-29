using Blazor.Data.Interfaces;
using Blazor.Data.Persistence;
using Blazor.Data.Responses;
using Blazor.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blazor.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddAutoMapper(typeof(EmployeeResponse));
            //services.AddAutoMapper(typeof(AppRoleResponse));
            //services.AddAutoMapper(typeof(AppUserResponse));
            //services.AddAutoMapper(typeof(CityResponse));
            //services.AddAutoMapper(typeof(TodoResponse));

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

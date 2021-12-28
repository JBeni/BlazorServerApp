using Blazor.Server.Data;
using Blazor.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Blazor.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Blazor.Data.Interfaces;
using Blazor.Data.Services;
using System.Reflection;
using FluentValidation;
using Blazor.Server.Filters;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"],
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
));

var builderIdentity = builder.Services.AddIdentityCore<AppUser>(opt =>
{
    // configure password options & others
    /*
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequiredLength = 6;
    opt.Password.RequiredUniqueChars = 1;
    */
    opt.User.RequireUniqueEmail = true;
});
builderIdentity = new IdentityBuilder(builderIdentity.UserType, builderIdentity.RoleType, builder.Services);
builderIdentity.AddRoles<AppRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthorization();

builder.Services.AddScoped<CustomAuthStateProvider,  CustomAuthStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetService<CustomAuthStateProvider>());


//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


// Inject services
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAppRoleService, AppRoleService>();
builder.Services.AddTransient<IAppUserService, AppUserService>();

builder.Services.AddTransient<IEmployeeService, EmployeeDataAccessLayer>();
builder.Services.AddScoped<EmployeeService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

using Blazor.Server.Data;
using Blazor.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Blazor.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Blazor.Data.Interfaces;
using Blazor.Data.Services;
using System.Reflection;
using Blazor.Server.Filters;
using Microsoft.AspNetCore.Components.Authorization;
using Blazor.Data.Responses;
using Blazor.Server;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(EmployeeResponse));
builder.Services.AddAutoMapper(typeof(AppRoleResponse));
builder.Services.AddAutoMapper(typeof(AppUserResponse));
builder.Services.AddAutoMapper(typeof(CityResponse));
builder.Services.AddAutoMapper(typeof(TodoResponse));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"],
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
));

var builderIdentity = builder.Services.AddIdentityCore<AppUser>(opt =>
{
    // configure password options & others
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequiredLength = 6;
    opt.Password.RequiredUniqueChars = 1;
    opt.User.RequireUniqueEmail = true;
});
builderIdentity = new IdentityBuilder(builderIdentity.UserType, builderIdentity.RoleType, builder.Services);
builderIdentity.AddRoles<AppRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthorization(options => { });

// Add JWT TOKEN Settings
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["JwtToken:Issuer"];
    options.Audience = builder.Configuration["JwtToken:Audience"];
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ClockSkew = TimeSpan.FromMinutes(5),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:SecretKey"])),
        RequireSignedTokens = true,
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = builder.Configuration["JwtToken:Audience"],
        ValidIssuer = builder.Configuration["JwtToken:Issuer"]
    };
});

builder.Services.AddScoped<CustomAuthStateProvider,  CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetService<CustomAuthStateProvider>());


//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddScoped<AppState>();
builder.Services.AddHttpClient<AppState>();


// Inject services
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAppRoleService, AppRoleService>();
builder.Services.AddTransient<IAppUserService, AppUserService>();

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<TodoService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

    await ApplicationDbContextSeed.SeedRolesDataAsync(roleManager);
    await ApplicationDbContextSeed.SeedCityData(context);
}

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

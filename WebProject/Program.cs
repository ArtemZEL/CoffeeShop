using Microsoft.EntityFrameworkCore;
using WebProject.Controllers;
using WebProject.DBStuff;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Service;
using WebProject.Service.Permissions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddAuthentication(AuthController.AUTH_KEY)
    .AddCookie(AuthController.AUTH_KEY, o => 
    {
        o.LoginPath = "/Auth/Login";
        o.ForwardForbid = "/Auth/Forbid";

    });

builder.Services.AddDbContext<WebProjectContext>(
    x => x.UseNpgsql(connectionString)
);



builder.Services.AddScoped<ICoffeeRepository,CoffeeRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICoffeShopPermision, CoffeShopPermision>();
builder.Services.AddScoped<UserCommentsRepository>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

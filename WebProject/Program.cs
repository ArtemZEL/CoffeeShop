using Microsoft.EntityFrameworkCore;
using WebProject.Controllers;
using WebProject.CustomMidleware;
using WebProject.DBStuff;
using WebProject.DBStuff.Repositories;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Hubs;
using WebProject.Service;
using WebProject.Service.Flie;
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


builder.Services.AddSignalR();

builder.Services.AddScoped<ICoffeeRepository,CoffeeRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<ICoffeShopPermision, CoffeShopPermision>();
builder.Services.AddScoped<IProfileFileService, ProfileFileService>();
builder.Services.AddScoped<ISliderFileServices, SliderFileServices>();
builder.Services.AddScoped<UserCommentsRepository>();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WebProjectContext>();
    db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<CustomLocalizazationMidleware>();

app.MapHub<NotificationHub>("/hubs/notification");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using CooffeeApi;
using CooffeeApi.DbStuff;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 

builder.Services.AddDbContext<CoffeeDBContext>(
    x => x.UseNpgsql(connectionString)
);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<NameTest>();
builder.Services.AddScoped<CoffeeService>();
var app = builder.Build();


app.MapGet("/", () => "Hi this test API");

app.MapGet("/createcoffee/{name}/{url}/{category}", (string name, string url, string category, CoffeeService serv) => {
   var id = serv.CreateCoffee(name,url,category);
   return id;    
});


app.MapGet("/getallcoffee", (CoffeeService name) => {
    return name.GetAllCoffee();
});



app.UseSwagger();
app.UseSwaggerUI();


app.Run();

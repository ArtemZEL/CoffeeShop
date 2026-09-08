using CoffeeApi.Service;
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

builder.Services.AddScoped<CoffeeService>();
builder.Services.AddScoped<UserService>();

//add acces on connection 
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();
        p.SetIsOriginAllowed(x => true);
        p.AllowCredentials();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CoffeeDBContext>();
    db.Database.Migrate();
}

app.UseCors();

app.MapGet("/", () => "Hi this test API");


app.MapGet("/createcoffee/{name}/{url}/{category}", (string name, string url, string category, CoffeeService serv) => {
   var id = serv.CreateCoffee(name,url,category);
   return id;    
});

app.MapGet("/getallcoffee", (CoffeeService name) => {
    return name.GetAllCoffee();
});

app.MapGet("/getNamecoffee", (CoffeeDBContext dbCont) =>
{
    return dbCont.Coffees.ToList();
});

//app.MapPut("/updatecoffe/{id}") (int id,string name,string url, string category, CoffeeService serv)=>{
//
//}


app.MapGet("/createcomment/{name}/{img}/{comment}",(string name, string img, string comment, UserService serv)=>{
    var idComm = serv.CreateComments(name, img, comment);
    return idComm;
});

app.MapGet("/getallcomment", (UserService comment) => {
    return comment.GetAllCommentsOfUsers();
});

app.MapPut("/updatecomment/{id}", (int id,string name,string img,string comment,UserService service) =>
{
    var result = service.UpdateComment(id, name, img, comment);
    if (!result)
    {
        return Results.NotFound("Comment not foun");
    }
    return Results.Ok("Comments uppdate");

});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

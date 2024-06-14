using Dal.Models;
using Dal;
using Microsoft.EntityFrameworkCore;
using Dal.DalApi;
using Dal.DalImplementation;
using Bl;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        });
});
Dbactions actions = new Dbactions(builder.Configuration);
var connection = actions.GetConnectionString("NotnimYadDB");
builder.Services.AddScoped<BlManager>(b => new BlManager(connection));
var app = builder.Build();
app.UseCors("CORSPolicy");
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();

using Dal.Models;
using Dal;
using Microsoft.EntityFrameworkCore;
using Dal.DalApi;
using Dal.DalImplementation;
using Bl;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<BlManager>();
builder.Services.AddControllers();
Dbactions actions = new Dbactions(builder.Configuration);
var connection = actions.GetConnectionString("NotnimYadDB");
builder.Services.AddDbContext<NotnimYadContext>(options => options.UseSqlServer(connection));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();

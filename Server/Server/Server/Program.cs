using Dal;
using Microsoft.EntityFrameworkCore;
using Bl;
using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//})
//.AddCookie()
//.AddGoogle(options =>
//{
//    IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");

//    options.ClientId = googleAuthNSection["ClientId"];
//    options.ClientSecret = googleAuthNSection["ClientSecret"];
//    options.SaveTokens = true;
//});

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        policyBuilder =>
        {
            policyBuilder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        });
});

Dbactions actions = new Dbactions(builder.Configuration);
var connection = actions.GetConnectionString("NotnimYadDB");
builder.Services.AddScoped<BlManager>(b => new BlManager(connection /*builder.Configuration.GetSection("Authentication:Google")["ClientId"], builder.Configuration.GetSection("Authentication:Google")["ClientSecret"]*/));

var app = builder.Build();

app.UseCors("CORSPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();

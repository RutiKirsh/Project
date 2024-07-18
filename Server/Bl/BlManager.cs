using Bl.BlApi;
using Bl.BlImplementaion;
using Bl.Models;
using Dal;
using Dal.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl;

public class BlManager
{
    public DalManager dalManager { get; }
    public ChildService child { get; }
    public VolunteeringTaskService voluteeringTaskService { get; }
    public VolunteersService volunteersService { get; }
    public UserService userService { get; }
    public InfoService infoService { get; }
    //public GmailService gmailService { get; }
    public BlManager(string connection/* string clientId, string clientSecret*/)
    {
        ServiceCollection services = new ServiceCollection();
        services.AddScoped<DalManager>(d => new DalManager(connection));
        services.AddScoped</*IChildRepo, */ChildService>();
        services.AddScoped</*IVolunteeringTaskRepo, */VolunteeringTaskService>();
        services.AddScoped</*IVolunteersRepo, */VolunteersService>();
        services.AddScoped< UserService>();
        services.AddScoped< InfoService>();
        //services.AddScoped< GmailService>(g => new GmailService(clientId, clientSecret));
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        dalManager = serviceProvider.GetService<DalManager>();
        child = serviceProvider.GetService<ChildService>();
        voluteeringTaskService = serviceProvider.GetService<VolunteeringTaskService>();
        volunteersService = serviceProvider.GetService<VolunteersService>();
        userService = serviceProvider.GetService<UserService>();
        infoService = serviceProvider.GetService<InfoService>();
    }
}

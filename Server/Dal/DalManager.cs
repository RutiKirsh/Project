using Dal.DalApi;
using Dal.DalImplementation;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

public class DalManager
{
    public ChildRepo child { get; }
    //public VolunteeringTaskRepo volunteeringTask { get; }
    public VolunteerRepo volunteer { get; }
    public UserRepo user { get; }
    public InfoRepo info { get; }
    public DalManager(string connection)
    {
        ServiceCollection services = new ServiceCollection();
        services.AddDbContext<NotnimYadContext>(options => options.UseSqlServer(connection));
        services.AddScoped</*IRepositoryLess<Child>, */ChildRepo>();
        //services.AddScoped</*IRepository<VolunteeringTask>, */VolunteeringTaskRepo>();
        services.AddScoped</*IRepositoryLess<Volunteer>, */VolunteerRepo>();
        services.AddScoped<UserRepo>();
        services.AddScoped<InfoRepo>();
        ServiceProvider servicesProvider = services.BuildServiceProvider();
        child = servicesProvider.GetService<ChildRepo>();
        //volunteeringTask = servicesProvider.GetService<VolunteeringTaskRepo>();
        volunteer = servicesProvider.GetService<VolunteerRepo>();
        user = servicesProvider.GetService<UserRepo>();
        info = servicesProvider.GetService<InfoRepo>();
    }
}

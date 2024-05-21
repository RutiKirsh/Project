using Dal.DalApi;
using Dal.DalImplementation;
using Dal.Models;
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
    public VolunteeringTaskRepo volunteeringTask { get; }
    public VolunteerRepo volunteer { get; }
    public DalManager()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddDbContext<NotnimYadContext>();
        services.AddScoped</*IRepositoryLess<Child>, */ChildRepo>();
        services.AddScoped</*IRepository<VolunteeringTask>, */VolunteeringTaskRepo>();
        services.AddScoped</*IRepositoryLess<Volunteer>, */VolunteerRepo>();
        ServiceProvider servicesProvider = services.BuildServiceProvider();
        child = servicesProvider.GetService<ChildRepo>();
        volunteeringTask = servicesProvider.GetService<VolunteeringTaskRepo>();
        volunteer = servicesProvider.GetService<VolunteerRepo>();
    }
}

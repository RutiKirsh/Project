using Bl.BlApi;
using Bl.BlImplementaion;
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
    public BlManager()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddScoped<DalManager>();
        services.AddScoped<IRepo<Child>, ChildService>();
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        dalManager = serviceProvider.GetService<DalManager>();
        child = serviceProvider.GetService<ChildService>();
    }
}

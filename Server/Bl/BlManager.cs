using Dal;
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
    public BlManager()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddScoped<DalManager>();
        ServiceProvider serviceProvider = services.BuildServiceProvider();
    }
}

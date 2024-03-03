using Dal.DalApi;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalImplementation;

public class VolunteeringTaskRepo : IVolunteeringTaskRepo
{
    NotnimYadContext notnimYadContext;
    public VolunteeringTaskRepo(NotnimYadContext notnimYadContext)
    {
        this.notnimYadContext = notnimYadContext;
    }
    public async Task<List<VolunteeringTask>> GetAllAsync()
    {
        return await notnimYadContext.VolunteeringTasks.ToListAsync();
    }

    public async Task<VolunteeringTask> GetSingleAsync(int id)
    {
        return await notnimYadContext.VolunteeringTasks.FirstOrDefaultAsync(task => task.Id == id);
    }
}

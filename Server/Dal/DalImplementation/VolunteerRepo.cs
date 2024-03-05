using Dal.DalApi;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalImplementation;

public class VolunteerRepo : IRepositoryLess<Volunteer>
{
    NotnimYadContext notnimYadContext;
    public VolunteerRepo(NotnimYadContext notnimYadContext)
    {
        this.notnimYadContext = notnimYadContext;
    }
    public async Task<List<Volunteer>> GetAllAsync()
    {
        return await notnimYadContext.Volunteers.ToListAsync();
    }

    public async Task<Volunteer> GetSingleAsync(string id)
    {
        return await notnimYadContext.Volunteers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Volunteer> PostAsync(Volunteer entity)
    {
        notnimYadContext.Volunteers.Add(entity);
        notnimYadContext.SaveChanges();
        return entity;
    }

    public Task<Volunteer> PutAsync(int id, Volunteer item)
    {
        throw new NotImplementedException();
    }
}

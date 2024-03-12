using Common;
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
    public async Task<PagedList<Volunteer>> GetAllAsync(BaseQueryParams queryParams)
    {
        var query = notnimYadContext.Volunteers.Include(volunteer => volunteer.Address).AsQueryable();
        return await PagedList<Volunteer>.ToPagedListAsync(query.OrderBy(volunteer => volunteer.Id), queryParams.PageNumber, queryParams.PageSize);
    }

    public async Task<Volunteer> GetSingleAsync(string id)
    {
        return await notnimYadContext.Volunteers.Include(volunteer => volunteer.Address).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Volunteer> PostAsync(Volunteer entity)
    {
        notnimYadContext.Volunteers.Add(entity);
        await notnimYadContext.SaveChangesAsync();
        return entity;
    }

    public Task<Volunteer> PutAsync(int id, Volunteer item)
    {
        throw new NotImplementedException();
    }
}

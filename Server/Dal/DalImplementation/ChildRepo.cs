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

public class ChildRepo : IRepositoryLess<Child>
{
    NotnimYadContext notnimYadContext;
    public ChildRepo(NotnimYadContext notnimYadContext)
    {
        this.notnimYadContext = notnimYadContext;
    }
    public async Task<PagedList<Child>> GetAllAsync(BaseQueryParams queryParams)
    {
        var query = notnimYadContext.Children.Include(child => child.Address).AsQueryable();
        return await PagedList<Child>.ToPagedListAsync(query.OrderBy(child => child.Id), queryParams.PageNumber, queryParams.PageSize);
    }

    public async Task<Child> GetSingleAsync(string id)
    {
        return await notnimYadContext.Children.Include(child => child.Address).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Child> PostAsync(Child entity)
    {
        notnimYadContext.Children.Add(entity);
        await notnimYadContext.SaveChangesAsync();
        return entity;
    }

    public Task<Child> PutAsync(Child item)
    {
        throw new NotImplementedException();
    }

}

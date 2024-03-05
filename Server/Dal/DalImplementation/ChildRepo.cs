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
    public async Task<List<Child>> GetAllAsync()
    {
        return await notnimYadContext.Children.ToListAsync();
    }

    public async Task<Child> GetSingleAsync(string id)
    {
        return await notnimYadContext.Children.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Child> PostAsync(Child entity)
    {
        notnimYadContext.Children.Add(entity);
        notnimYadContext.SaveChanges();
        return entity;
    }

    public Task<Child> PutAsync(int id, Child item)
    {
        throw new NotImplementedException();
    }
    
}

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

public class VolunteeringTaskRepo : IRepository<VolunteeringTask>
{
    NotnimYadContext notnimYadContext;
    public VolunteeringTaskRepo(NotnimYadContext notnimYadContext)
    {
        this.notnimYadContext = notnimYadContext;
    }

    public async Task<PagedList<VolunteeringTask>> GetAllAsync(BaseQueryParams queryParams, string childId)
    {
        IQueryable<VolunteeringTask> query;
        if (childId == null)
        {
            query = notnimYadContext.VolunteeringTasks.Where(task => task.Done != true).Include(task => task.Child).ThenInclude(child => child.Address).AsQueryable();
        }
        else
        {
            query = notnimYadContext.VolunteeringTasks.Where(task => task.ChildId == childId).Include(task => task.Child).ThenInclude(child => child.Address).Include(v => v.Volunteer).ThenInclude(a => a.Address).AsQueryable();
        }
        return await PagedList<VolunteeringTask>.ToPagedListAsync(query.OrderBy(task => task.Date), queryParams.PageNumber, queryParams.PageSize);
    }

    public async Task<VolunteeringTask> GetSingleAsync(int id)
    {
        return await notnimYadContext.VolunteeringTasks.Include(task => task.Child).ThenInclude(c => c.Address).FirstOrDefaultAsync(task => task.Id == id);
    }

    public async Task<VolunteeringTask> PostAsync(VolunteeringTask entity)
    {
        notnimYadContext.VolunteeringTasks.Add(entity);
        await notnimYadContext.SaveChangesAsync();
        return entity;
    }
    public async Task<VolunteeringTask> PutAsync(VolunteeringTask item)
    {
        var volunteeringTask = notnimYadContext.VolunteeringTasks.FirstOrDefaultAsync(v => v.Id == item.Id);
        if (volunteeringTask == null)
        {
            throw new Exception("can't find item");
        }
        volunteeringTask.Result.Date = item.Date;
        volunteeringTask.Result.End = item.End;
        volunteeringTask.Result.Done = item.Done;
        volunteeringTask.Result.VolunteerId = item.VolunteerId;
        volunteeringTask.Result.Comments = item.Comments;
        volunteeringTask.Result.Type = item.Type;
        await notnimYadContext.SaveChangesAsync();
        return await GetSingleAsync(volunteeringTask.Result.Id);
    }
    //דרוש תיקון!!!

    public async Task<VolunteeringTask> DeleteAsync(int id)
    {
        Task<VolunteeringTask> volunteeringTask = notnimYadContext.VolunteeringTasks.FirstOrDefaultAsync(x => x.Id == id);
        if (volunteeringTask != null)
        {
            notnimYadContext.VolunteeringTasks.Remove(await volunteeringTask);
        }
        await notnimYadContext.SaveChangesAsync();
        return await volunteeringTask;
    }

}

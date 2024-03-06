﻿using Common;
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
    
    public async Task<PagedList<VolunteeringTask>> GetAllAsync(BaseQueryParams queryParams)
    {
        var query = notnimYadContext.VolunteeringTasks.AsQueryable();
        return await PagedList<VolunteeringTask>.ToPagedListAsync(query, queryParams.PageNumber, queryParams.PageSize);
    }

    public async Task<VolunteeringTask> GetSingleAsync(int id)
    {
        return await notnimYadContext.VolunteeringTasks.FirstOrDefaultAsync(task => task.Id == id);
    }

    public async Task<VolunteeringTask> PostAsync(VolunteeringTask entity)
    {
        notnimYadContext.VolunteeringTasks.Add(entity);
        notnimYadContext.SaveChanges();
        return entity;
    }
    //דרוש תיקון!!!
    public Task<VolunteeringTask> PutAsync(int id, VolunteeringTask item)
    {
        Task<VolunteeringTask> volunteeringTask = notnimYadContext.VolunteeringTasks.FirstOrDefaultAsync(v => v.Id == id);
       /* if(volunteeringTask == null)
        {
            volunteeringTask = item.Comments;
        }*/
        return volunteeringTask;
    }
    //דרוש תיקון!!!

    public async Task<VolunteeringTask> DeleteAsync(int id)
    {
        Task<VolunteeringTask> volunteeringTask = notnimYadContext.VolunteeringTasks.FirstOrDefaultAsync(x => x.Id == id);
        /*if(volunteeringTask != null)
        {
            notnimYadContext.VolunteeringTasks.Remove(volunteeringTask);
        }
        notnimYadContext.SaveChanges();*/
        return await volunteeringTask;
    }

}

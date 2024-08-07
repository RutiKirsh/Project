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

public class UserRepo : IUserRepo
{
    NotnimYadContext notnimYadContext;
    public UserRepo(NotnimYadContext notnimYadContext)
    {
        this.notnimYadContext = notnimYadContext;
    }

    public async Task<bool> EmailExist(string email)
    {
        return await notnimYadContext.Users.AnyAsync(x => x.Email.Equals(email));
    }

    public async Task<PagedList<User>> GetAllAsync(BaseQueryParams queryParams)
    {
        var query = notnimYadContext.Users.AsQueryable();
        return await PagedList<User>.ToPagedListAsync(query.OrderBy(user => user.Id), queryParams.PageNumber, queryParams.PageSize);
    }

    public async Task<User> GetSingleAsync(string email)
    {
        return await notnimYadContext.Users.Include(c => c.Child).ThenInclude(a => a.Address).Include(u => u.Volunteer).ThenInclude(a => a.Address).FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> PostAsync(User entity)
    {
        notnimYadContext.Users.Add(entity);
        await notnimYadContext.SaveChangesAsync();
        return entity;
    }
}

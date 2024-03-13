using Bl.BlApi;
using Bl.Models;
using Common;
using Dal;
using Dal.DalApi;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplementaion;

public class ChildService : IRepo<Child>
{
    private IRepositoryLess<Child> _children;
    public ChildService(DalManager manager)
    {
        this._children = manager.child;
    }
    public Task<PagedList<Child>> GetAllAsync(BaseQueryParams queryParams)
    {
        if ((queryParams as UserQueryParams).user.Type != TypeEnum.ADMIN)
        {
            throw new Exception("You do not have access permission.");
        }
        return _children.GetAllAsync(queryParams);
    }


    public Task<Child> GetSingleAsync(string id, BlUser user)
    {
        if(user.ChildId != id)
        {
            throw new Exception("You do not have access permission.");
        }
        return this._children.GetSingleAsync(id);
    }

    public Task<Child> PostAsync(Child entity)
    {
        return this._children.PostAsync(entity);
    }


    public Task<Child> PutAsync(Child item, BlUser user)
    {
        if (user.ChildId != item.Id)
        {
            throw new Exception("You do not have access permission.");
        }
        return this._children.PutAsync(item);
    }
}

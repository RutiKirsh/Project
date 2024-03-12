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

public class ChildService : IRepositoryLess<Child>
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
            throw new Exception("You do not have access permission");
        }
        return _children.GetAllAsync(queryParams);
    }

    public Task<Child> GetSingleAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Child> PostAsync(Child entity)
    {
        throw new NotImplementedException();
    }

    public Task<Child> PutAsync(int id, Child item)
    {
        throw new NotImplementedException();
    }
}

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

public class ChildService : IChildRepo
{
    private IRepositoryLess<Child> _children;
    public ChildService(DalManager manager)
    {
        this._children = manager.child;
    }

    public async Task<BlChild> GetSingleAsync(string id, BlUser user)
    {
        if(user.ChildId != id)
        {
            throw new Exception("You do not have access permission.");
        }
        var child = this._children.GetSingleAsync(id);
        return new BlChild((await child).Id, (await child).FirstName, (await child).LastName, (await child).Phone, (await child).Challenge, (await child).BirthDate, (await child).Image, (await child).Comments, (await child).Address);
    }

    public Task<BlChild> PostAsync(BlChild entity)
    {
        var child = new Child();

        return this._children.PostAsync(child);
    }


    public Task<BlChild> PutAsync(BlChild item, BlUser user)
    {
        if (user.ChildId != item.Id)
        {
            throw new Exception("You do not have access permission.");
        }
        return this._children.PutAsync(item);
    }
}

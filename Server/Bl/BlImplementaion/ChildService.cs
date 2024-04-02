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

    public async Task<BlChild> PostAsync(BlChild entity)
    {
        var child = new Child();
        child.Id = entity.Id;
        child.FirstName = entity.FirstName;
        child.LastName = entity.LastName;
        child.Phone = entity.Phone;
        child.Challenge = entity.Challenge;
        child.BirthDate = entity.BirthDate;
        child.Image = entity.Image;
        child.Comments = entity.Comments;
        child.Address = entity.Address;

        var res = _children.PostAsync(child);
        var blChild = new BlChild((await res).Id, (await res).FirstName, (await res).LastName, (await res).Phone, (await res).Challenge, (await res).BirthDate, (await res).Image, (await res).Comments, (await res).Address);
        return blChild;
    }


    public Task<BlChild> PutAsync(BlChild item, BlUser user)
    {
        //if (user.ChildId != item.Id)
        //{
            throw new Exception("You do not have access permission.");
        //}
        //return this._children.PutAsync(item);
    }
}

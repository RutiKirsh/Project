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

public class ChildService : IChildService
{
    private IRepositoryLess<Child> _children;
    private IUserRepo _users;
    public ChildService(DalManager manager)
    {
        this._children = manager.child;
        this._users = manager.user;
    }

    public async Task<BlChild> GetSingleAsync(string id, string email, string pass)
    {
        var user = await _users.GetSingleAsync(email);
        if(user == null || user.Password != pass || user.ChildId != id)
        {
            throw new Exception("You do not have access permission.");
        }
        var child = this._children.GetSingleAsync(id);
        return new BlChild((await child).Id, (await child).FirstName, (await child).LastName, (await child).Phone, (await child).Challenge, (await child).BirthDate, (await child).Image, (await child).Comments, (await child).Address);
    }

    public async Task<BlChild> PostAsync(PostChild entity)
    {
        if (entity.Image == null || entity.Image.Length == 0)
        {
            throw new Exception("No file uploaded");
        }
        string folderPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "client", "public", "Uploads");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var filePath = Path.Combine(folderPath, entity.Image.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await entity.Image.CopyToAsync(stream);
        }

        var child = new Child();
        child.Id = entity.Id;
        child.FirstName = entity.FirstName;
        child.LastName = entity.LastName;
        child.Phone = entity.Phone;
        child.Challenge = entity.Challenge;
        child.BirthDate = entity.BirthDate;
        child.Image = entity.Image.FileName;
        child.Comments = entity.Comments;
        child.Address = new Address {City = entity.City, Street = entity.Street, Building = entity.Building};

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

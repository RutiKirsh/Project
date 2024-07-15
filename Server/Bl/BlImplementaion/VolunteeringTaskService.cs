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

public class VolunteeringTaskService : IVolunteeringTaskService
{
    private IRepository<VolunteeringTask> _volunteeringTask;
    private IUserRepo _userRepo;
    public VolunteeringTaskService(DalManager manager)
    {
        this._volunteeringTask = manager.volunteeringTask;
        this._userRepo = manager.user;
    }

    public Task<BlVolunteeringTask> DeleteAsync(int id, BlUser user)
    {
        throw new NotImplementedException();
    }

    // לכולם יש הרשאה לראות את המשימות
    public async Task<PagedList<TaskList>> GetAllAsync(BaseQueryParams queryParams)
    {
        var tasks = _volunteeringTask.GetAllAsync(queryParams);
        var result = new PagedList<TaskList>((await tasks).TotalItems, (await tasks).CurrentPage, (await tasks).PageSize, new List<TaskList>());
        foreach (var task in await tasks) {
            result.Add(new TaskList(task.Id, task.Date, task.Type, task.Child.Address.City, task.End));
        }
        return result;
    }

    public async Task<BlVolunteeringTask> GetSingleAsync(int id, string email, string password)
    {
        var user = await _userRepo.GetSingleAsync(email);
        if (user == null || user.Password != password) {
            throw new Exception("You do not have access permission");
        }
        var task = await _volunteeringTask.GetSingleAsync(id);
        if (user.Type.Equals("child") && user.Child.Id != task.ChildId)
        {
            throw new Exception("You do not have access permission.");
        }
        if (user.Type.Equals("volunteer"))
        {
            return new TaskForVolunteer(task.Id, task.Date, task.Child.FirstName, task.Child.Image, task.Child.Address.City, task.Child.Comments, task.End, task.Comments);
        }
        return new ExtendsVolunteeringTask(task.Id,
            task.Date,
            new BlChild(task.Child.Id, task.Child.FirstName, task.Child.LastName, task.Child.Phone, task.Child.Challenge, task.Child.BirthDate, task.Child.Image, task.Child.Comments, task.Child.Address),
            task.Volunteer, task.Done, task.End, task.Comments);
    }
    //לתקן כשמרוכזים!!!

    public async Task<BlVolunteeringTask> PostAsync(PostTask entity, string email, string password)
    {
        var user = await _userRepo.GetSingleAsync(email);
        if (user == null || user.Password != password || !user.Type.Equals("child"))
        {
            throw new Exception("You do not have access permission");
        }
        var volunteeringTask = new VolunteeringTask();
        volunteeringTask.Date = entity.Date;
        volunteeringTask.Type = entity.Place;
        volunteeringTask.ChildId = user.Child.Id;
        volunteeringTask.VolunteerId = user.VolunteerId;
        volunteeringTask.End = entity.End;
        volunteeringTask.Done = false;
        volunteeringTask.Comments = entity.Comments;
        var res = _volunteeringTask.PostAsync(volunteeringTask);
        var blVolunteeringTask = new BlVolunteeringTask((await res).Id, (await res).Date,(await res).End, (await res).Comments);
        return blVolunteeringTask;
    }

    public Task<BlVolunteeringTask> PutAsync(BlVolunteeringTask item, BlUser user)
    {
        return null;
    }

  
}

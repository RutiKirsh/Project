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

public class VolunteeringTaskService : IVolunteeringTaskRepo
{
    private IRepository<VolunteeringTask> _volunteeringTask;
    public VolunteeringTaskService(DalManager manager)
    {
        this._volunteeringTask = manager.volunteeringTask;  
    }

    // לכולם יש הרשאה לראות את המשימות
    public async Task<PagedList<TaskList>> GetAllAsync(BaseQueryParams queryParams)
    {
        var tasks = _volunteeringTask.GetAllAsync(queryParams);
        var result = new PagedList<TaskList>((await tasks).TotalItems, (await tasks).CurrentPage, (await tasks).PageSize, new List<TaskList>());
        foreach (var task in await tasks) {
            result.Add(new TaskList(task.Id, task.Date, task.Type, task.Comments, task.Done, task.End));
        }
        return result;
    }

    public async Task<BlVolunteeringTask> GetSingleAsync(int id, BlUser user)
    {
        var task = _volunteeringTask.GetSingleAsync(id);
        if (user.ChildId != task.Result.ChildId || user.Type != TypeEnum.VOLUNTEER)
        {
            throw new Exception("You do not have access permission.");
        }
        BlVolunteeringTask res = new((await task).Id, (await task).Date, (await task).Type, (await task).ChildId, (await task).VolunteerId, (await task).End, (await task).Done, (await task).Comments);
        return res;
    }
    //לתקן כשמרוכזים!!!

    public async Task<BlVolunteeringTask> PostAsync(BlVolunteeringTask entity)
    {
        var volunteeringTask = new VolunteeringTask();
        volunteeringTask.Id = entity.Id;
        volunteeringTask.Date = entity.Date;
        volunteeringTask.Type = entity.Type;
        volunteeringTask.ChildId = entity.ChildId;
        volunteeringTask.VolunteerId = entity.VolunteerId;
        volunteeringTask.End = entity.End;
        volunteeringTask.Done = entity.Done;
        volunteeringTask.Comments = entity.Comments;
        var res = _volunteeringTask.PostAsync(volunteeringTask);
        var blVolunteeringTask = new BlVolunteeringTask((await res).Id, (await res).Date, (await res).Type, (await res).ChildId, (await res).VolunteerId, (await res).End, (await res).Done, (await res).Comments);
        return blVolunteeringTask;
    }

    public Task<BlVolunteeringTask> PutAsync(BlVolunteeringTask item, BlUser user)
    {
        return null;
    }

  
}

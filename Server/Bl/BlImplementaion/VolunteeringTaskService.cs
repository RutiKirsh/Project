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

    public async Task<VolunteeringTask> GetSingleAsync(int id, BlUser user)
    {
        Task<VolunteeringTask> task = _volunteeringTask.GetSingleAsync(id);
        if (user.ChildId != task.Result.ChildId)
        {
            throw new Exception("You do not have access permission.");
        }
        return await task;
    }
    //לתקן כשמרוכזים!!!

}

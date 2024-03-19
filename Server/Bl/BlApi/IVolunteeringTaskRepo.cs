using Bl.Models;
using Common;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi;

public interface IVolunteeringTaskRepo
{
    Task<PagedList<TaskList>> GetAllAsync(BaseQueryParams queryParams);
    Task GetSingleAsync(int id, BlUser user);
    Task PostAsync(BlVolunteeringTask entity);
    Task PutAsync(BlVolunteeringTask item, BlUser user);
}

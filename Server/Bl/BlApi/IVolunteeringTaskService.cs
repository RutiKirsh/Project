using Bl.Models;
using Common;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi;

public interface IVolunteeringTaskService
{
    public Task<PagedList<TaskList>> GetAllAsync(BaseQueryParams queryParams);
    public Task<BlVolunteeringTask> GetSingleAsync(int id, string email, string password);
    public Task<BlVolunteeringTask> PostAsync(PostTask entity, string email, string password);
    public Task<BlVolunteeringTask> PutAsync(BlVolunteeringTask item, BlUser user);
    public Task<BlVolunteeringTask> DeleteAsync(int id, BlUser user);
}

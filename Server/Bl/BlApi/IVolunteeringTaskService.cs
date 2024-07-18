using Bl.Models;
using Common;

namespace Bl.BlApi;

public interface IVolunteeringTaskService
{
    public Task<PagedList<BlVolunteeringTask>> GetAllAsync(BaseQueryParams queryParams);
    public Task<PagedList<ExtendsVolunteeringTask>> GetAllAsync(BaseQueryParams queryParams, string email, string password);
    public Task<BlVolunteeringTask> GetSingleAsync(int id, string email, string password);
    public Task<BlVolunteeringTask> PostAsync(PostTask entity, string email, string password);
    public Task<BlVolunteeringTask> PutAsync(BlVolunteeringTask item, BlUser user);
    public Task<BlVolunteeringTask> DoTaskAsync(int id, string email, string password);
    public Task<BlVolunteeringTask> DeleteAsync(int id, string email, string password);
}

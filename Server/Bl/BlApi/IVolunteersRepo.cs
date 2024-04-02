using Bl.Models;
using Common;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi;

public interface IVolunteersRepo
{
    Task<PagedList<BlVolunteer>> GetAllAsync(BaseQueryParams queryParams);
    Task<BlVolunteer> GetSingleAsync(string id, BlUser user);
    Task<BlVolunteer> PostAsync(BlVolunteer entity);
    Task<BlVolunteer> PutAsync(BlVolunteer item, BlUser user);
}

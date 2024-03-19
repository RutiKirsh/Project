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
    Task GetSingleAsync(int id, BlUser user);
    Task PostAsync(BlVolunteer entity);
    Task PutAsync(BlVolunteer item, BlUser user);
}

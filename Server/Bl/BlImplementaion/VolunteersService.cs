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

public class VolunteersService : IVolunteersRepo
{
    private IRepositoryLess<Volunteer> _volunteer;
    public VolunteersService(DalManager manager)
    {
        _volunteer = manager.volunteer;
    }
    public async Task<PagedList<BlVolunteer>> GetAllAsync(BaseQueryParams queryParams)
    {
        var volunteers = _volunteer.GetAllAsync(queryParams);
        var result = new PagedList<BlVolunteer>((await volunteers).TotalItems, (await volunteers).CurrentPage, (await volunteers).PageSize, new List<BlVolunteer>());
        foreach (var volunteer in await volunteers)
        {
            result.Add(new BlVolunteer(volunteer.Id, volunteer.FirstName, volunteer.LastName, volunteer.Phone, volunteer.BirthDate, volunteer.Comments, volunteer.Address));
        }
        return result;
    }

    public async Task<BlVolunteer> GetSingleAsync(string id, BlUser user)
    {
        if(user.Type != TypeEnum.VOLUNTEER)
        {
            throw new Exception("You do not have access permission.");
        }
        var volunteer = _volunteer.GetSingleAsync(id);
        if(user.VolunteerId != id)
        {
            throw new Exception("You do not have access permission.");
        }
        BlVolunteer res = new((await volunteer).Id, (await volunteer).FirstName, (await volunteer).LastName, (await volunteer).Phone, (await volunteer).BirthDate, (await volunteer).Comments, (await volunteer).Address);
        return res;
    }

    public async Task<BlVolunteer> PostAsync(BlVolunteer entity)
    {
        var volunteer = new Volunteer();
        volunteer.Id = entity.Id;
        volunteer.FirstName = entity.FirstName;
        volunteer.LastName = entity.LastName;
        volunteer.Phone = entity.Phone;
        volunteer.BirthDate = entity.BirthDate;
        volunteer.Comments = entity.Comments;
        volunteer.Address = entity.Address;
        var res = _volunteer.PostAsync(volunteer);
        var blVolunteer = new BlVolunteer((await res).Id, (await res).FirstName, (await res).LastName, (await res).Phone, (await res).BirthDate, (await res).Comments, (await res).Address);
        return blVolunteer;
    }

    public Task<BlVolunteer> PutAsync(BlVolunteer item, BlUser user)
    {
        return null;
    }
}

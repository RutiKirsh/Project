using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models;

public class ExtendsVolunteeringTask: BlVolunteeringTask
{
    public bool? Done { get; set; } = false;
    public BlChild Child { get; set; }
    public BlVolunteer Volunteer { get; set; }
    public ExtendsVolunteeringTask(int id, DateTime date, string place, BlChild child, Volunteer volunteer, bool? done, DateTime? end, string? comments):
        base(id, date, place, end, comments)
    {
        Child = child;
        if (volunteer != null)
        {
            Volunteer = new BlVolunteer(volunteer.Id, volunteer.FirstName, volunteer.LastName, volunteer.Phone, volunteer.BirthDate, volunteer.Comments, volunteer.Address);

        }
        if (done != null)
        {
            Done = done;
        }
    }

}

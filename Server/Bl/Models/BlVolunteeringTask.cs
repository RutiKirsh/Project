using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models;

public class BlVolunteeringTask
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public DateTime? End { get; set; } = null;

    public string ChildId { get; set; }

    public bool? Done { get; set; } = false;

    public string VolunteerId { get; set; } = null;

    public string Type { get; set; } = null;

    public string Comments { get; set; } = null;
    public BlVolunteeringTask(int id, DateTime date, string type, string childId, string volunteerId, DateTime? end, bool? done, string comments)
    {
        Id = id;
        Date = date;
        Type = type;
        ChildId = childId;
        VolunteerId = volunteerId;
        End = end;
        Done = done;
        Comments = comments;    
    }
}

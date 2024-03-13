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

    public DateTime? End { get; set; }

    public string ChildId { get; set; }

    public bool? Done { get; set; }

    public string VolunteerId { get; set; }

    public string Type { get; set; }

    public string Comments { get; set; }
}

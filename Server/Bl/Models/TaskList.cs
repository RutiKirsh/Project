using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models;

public class TaskList : BlVolunteeringTask
{
    public string City { get; set; }
    public TaskList(int id,DateTime date, string place, string city, DateTime? end):
        base(id, date, place, end)
    {
        this.Id = id;
        this.Date = date;
        this.End = end;
        this.Place = place;
        this.City = city;
    }
}

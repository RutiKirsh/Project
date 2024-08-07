﻿using Dal.Models;
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

    public string Place { get; set; }

    public BlVolunteeringTask(int id, DateTime date, string place, DateTime? end)
    {
        Id = id;
        Date = date;
        Place = place;
        End = end;    
    }
}

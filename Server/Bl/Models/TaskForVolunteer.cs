using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models;

public class TaskForVolunteer: BlVolunteeringTask
{
    public string ChildName { get; set; }

    public string ChildComments { get; set; } = null;

    public string Image { get; set; }

    public string City { get; set; }

    public string Comments { get; set; } = null;

    public TaskForVolunteer(int id, DateTime date, string place, string childName, string image, string city, string childComments, DateTime? end, string comments):
        base(id, date, place, end)
    {
        ChildName = childName;
        Image = image;
        City = city;
        ChildComments = childComments;
        Comments = comments;
    }
}

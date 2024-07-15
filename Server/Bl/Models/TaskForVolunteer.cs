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

    public TaskForVolunteer(int id, DateTime date, string childName, string image, string city, string? childComments, DateTime? end, string? comments):
        base(id, date, end, comments)
    {
        ChildName = childName;
        Image = image;
        City = city;
        ChildComments = comments;
    }
}

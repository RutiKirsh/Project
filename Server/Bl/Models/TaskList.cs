using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models;

public class TaskList
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime? End { get; set; }
    public bool? Done { get; set; }
    public string Type { get; set; }
    public string Comments { get; set; }
    public TaskList(int id, DateTime date, string type, string comments, bool? done, DateTime? end)
    {
        this.Id = id;
        this.Date = date;
        this.End = end;
        this.Done = done;
        this.Type = type;
        this.Comments = comments;
    }

    public TaskList(int id, DateTime date, string type, string comments, bool? done, DateTime? end)
    {
        Id = id;
        Date = date;
        Type = type;
        Comments = comments;
        Done = done;
        End = end;
    }
}

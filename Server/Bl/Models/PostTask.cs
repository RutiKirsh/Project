using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models;

public class PostTask
{
    public DateTime Date { get; set; }
    public DateTime? End { get; set; }
    public string Place { get; set; }
    public string Comments { get; set; }
}

using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalImplementation;

public class InfoRepo
{
    NotnimYadContext notnimYadContext;
    public InfoRepo(NotnimYadContext notnimYadContext)
    {
        this.notnimYadContext = notnimYadContext;
    }
    public List<Child> GetChallenges()
    {
        return notnimYadContext.Children.GroupBy(c => c.Challenge).Select(g => g.First()).ToList();
    }
}

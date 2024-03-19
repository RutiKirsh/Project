using Bl.Models;
using Common;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi;

public interface IChildRepo
{
    Task GetSingleAsync(string id, BlUser user);
    Task PostAsync(BlChild entity);
    Task PutAsync(BlChild item, BlUser user);
}

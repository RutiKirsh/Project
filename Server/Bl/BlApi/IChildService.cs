using Bl.Models;
using Common;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi;

public interface IChildService
{
    Task<BlChild> GetSingleAsync(string id, BlUser user);
    Task<BlChild> PostAsync(PostChild entity);
    Task<BlChild> PutAsync(BlChild item, BlUser user);
}

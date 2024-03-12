using Bl.Models;
using Common;
using Dal.DalApi;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl;

public class UserQueryParams : BaseQueryParams
{
    public BlUser user { get; set; }
}

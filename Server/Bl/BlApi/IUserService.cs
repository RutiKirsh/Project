using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface IUserService
    {
        public Task<bool> EmailExist(string email);
    }
}

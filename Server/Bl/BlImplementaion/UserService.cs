using Bl.BlApi;
using Common;
using Dal;
using Dal.DalApi;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplementaion
{
    public class UserService : Bl.BlApi.IUserRepo
    {
        private Dal.DalApi.IUserRepo _userRepo;
        public UserService(DalManager dalManager) {
            this._userRepo = dalManager.user;
        }
        public async Task<bool> EmailExist(string email)
        {
            return await _userRepo.EmailExist(email);
        }
    }
}

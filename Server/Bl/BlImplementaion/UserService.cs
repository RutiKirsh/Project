using Bl.BlApi;
using Bl.Models;
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
    public class UserService : IUserService
    {
        private Dal.DalApi.IUserRepo _userRepo;
        public UserService(DalManager dalManager)
        {
            this._userRepo = dalManager.user;
        }
        public async Task<bool> EmailExist(string email)
        {
            return await _userRepo.EmailExist(email);
        }

        public async Task<BlUser> GetUser(string email, string password)
        {
            var user = await _userRepo.GetSingleAsync(email);
            if (user == null || !user.Password.Equals(password))
            {
                throw new Exception("user doesn't valid");
            }
            if (user.Child != null) {
                return new BlUser(user.Email, user.Password, user.Type, new BlChild(user.Child.Id, user.Child.FirstName,
                    user.Child.LastName,
                    user.Child.Phone,
                    user.Child.Challenge,
                    user.Child.BirthDate,
                    user.Child.Image,
                    user.Child.Comments,
                    user.Child.Address), null);
            }
            if (user.Volunteer != null) {
                return new BlUser(user.Email, user.Password, user.Type, null,
                        new BlVolunteer(
                        user.Volunteer.Id,
                        user.Volunteer.FirstName,
                        user.Volunteer.LastName,
                        user.Volunteer.Phone,
                        user.Volunteer.BirthDate,
                        user.Volunteer.Comments,
                        user.Volunteer.Address
                        ));
            }
            return new BlUser(user.Email, user.Password, user.Type, null, null);

        }
    }
}

using Common;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi;

public interface IUserRepo
{
    public Task<bool> EmailExist(string email);
    Task<PagedList<User>> GetAllAsync(BaseQueryParams queryParams);
    Task<User> GetSingleAsync(string email);
    Task<User> PostAsync(User entity);
}

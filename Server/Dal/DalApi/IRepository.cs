using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetSingleAsync(int id);
}

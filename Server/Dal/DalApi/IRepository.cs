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
    Task<T> PostAsync(int id, T entity);
    Task<T> PutAsync(T item);
    Task<T> DeleteAsync(int id);

}

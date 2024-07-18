using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi;

public interface IRepository<T>
{
    Task<PagedList<T>> GetAllAsync(BaseQueryParams queryParams, string childId);
    Task<T> GetSingleAsync(int id);
    Task<T> PostAsync(T entity);
    Task<T> PutAsync(T item);
    Task<T> DeleteAsync(int id);

}

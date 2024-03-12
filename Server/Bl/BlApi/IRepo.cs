using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi;

public interface IRepo<T> where T : class
{
    Task<PagedList<T>> GetAllAsync(BaseQueryParams queryParams);
    Task<T> GetSingleAsync(int id);
    Task<T> PostAsync(T entity);
    Task<T> PutAsync(int id, T item);
    Task<T> DeleteAsync(int id);
}

using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi;

public interface IRepositoryLess<T>
{
    Task<PagedList<T>> GetAllAsync(BaseQueryParams queryParams);
    Task<T> GetSingleAsync(string id);
    Task<T> PostAsync(T entity);
    Task<T> PutAsync(int id, T item);
}

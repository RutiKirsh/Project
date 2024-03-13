using Bl.Models;
using Common;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi;

public interface IRepo<T> where T : class
{
    Task<PagedList<T>> GetAllAsync(BaseQueryParams queryParams);
    Task<T> GetSingleAsync(string id, BlUser user);
    Task<T> PostAsync(T entity);
    Task<T> PutAsync(T item, BlUser user);
}

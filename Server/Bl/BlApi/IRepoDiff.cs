using Bl.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi;

public interface IRepoDiff<T> where T : class
{
    Task<PagedList<TaskList>> GetAllAsync(BaseQueryParams queryParams);
    Task<T> GetSingleAsync(int id, BlUser user);
    Task<T> PostAsync(T entity);
    Task<T> PutAsync(T item, BlUser user);
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi;

public interface IRepositoryLess<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetSingleAsync(string id);
    Task<T> PostAsync(T entity);
    Task<T> PutAsync(int id, T item);
}

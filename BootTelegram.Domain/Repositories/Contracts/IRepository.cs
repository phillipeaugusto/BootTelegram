using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootTelegram.Domain.Repositories.Contracts;

public interface IRepository<T>
{
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<T> GetById(Guid id);
    Task<List<T>> GetAll();
}
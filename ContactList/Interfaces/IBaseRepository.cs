using ContactList.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactList.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> FindAll();
        Task<T> Find(Guid id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(T obj);
    }
}

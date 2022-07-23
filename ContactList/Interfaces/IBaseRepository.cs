using ContactList.Entity;
using System;
using System.Threading.Tasks;

namespace ContactList.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Find(Guid id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(T obj);
    }
}

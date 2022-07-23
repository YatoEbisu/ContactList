using ContactList.Entity;
using System;
using System.Threading.Tasks;

namespace ContactList.Interfaces
{
    public interface IPersonService
    {
        Task<Person> Find(Guid id);
        Task Insert(Person obj);
        Task Update(Person obj);
        Task Delete(Guid id);
    }
}

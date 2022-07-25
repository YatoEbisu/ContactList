using ContactList.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactList.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAll();
        Task<Person> Find(Guid id);
        Task Insert(Person obj);
        Task Update(Person obj);
        Task Delete(Guid id);
    }
}

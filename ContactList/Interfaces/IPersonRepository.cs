using ContactList.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactList.Interfaces

{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<List<Person>> FindAll();
    }
}

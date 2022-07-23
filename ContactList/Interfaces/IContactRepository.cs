using ContactList.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactList.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<List<Contact>> Find();

    }
}

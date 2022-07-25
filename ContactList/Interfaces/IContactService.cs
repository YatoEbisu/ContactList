using ContactList.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactList.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> FindAll();
        Task<Contact> Find(Guid id);
        Task Insert(Contact obj);
        Task Update(Contact obj);
        Task Delete(Guid id);
    }
}

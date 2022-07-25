using ContactList.Entity;
using ContactList.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactList.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {   
            _contactRepository = contactRepository;
        }

        public Task<Contact> Find(Guid id)
        {
            return _contactRepository.Find(id);
        }

        public Task<List<Contact>> FindAll()
        {
            return _contactRepository.FindAll();
        }

        public async Task Insert(Contact contact)
        {
            contact.Id = Guid.NewGuid();
            await _contactRepository.Insert(contact);
        }

        public async Task Update(Contact contact)
        {
            await _contactRepository.Update(contact);
        }
        public async Task Delete(Guid id)
        {
            var person = await _contactRepository.Find(id);
            if (person != null)
                await _contactRepository.Delete(person);
        }
    }
}

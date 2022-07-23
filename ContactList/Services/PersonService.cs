using ContactList.Entity;
using ContactList.Interfaces;
using System;
using System.Threading.Tasks;

namespace ContactList.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IContactService _contactService;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Task<Person> Find(Guid id)
        {
            var person = _personRepository.Find(id);
            return person;
        }
        public async Task Insert(Person person)
        {
            person.Id = Guid.NewGuid();
            await _personRepository.Insert(person);
        }
        public async Task Update(Person person)
        {
            await _personRepository.Update(person);
        }
        public async Task Delete(Guid id)
        {
            var person = await _personRepository.Find(id);
            if(person != null)
                await _personRepository.Delete(person);
        }
    }
}

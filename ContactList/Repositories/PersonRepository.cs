using ContactList.Context;
using ContactList.Entity;
using ContactList.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;
        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Person> Find(Guid id)
        {
            try
            {
                var person = await _context.Persons
                    .Where(p => p.Id == id)
                    .Include(c => c.Contacts)
                    .FirstOrDefaultAsync();
                return person;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar pessoa. \n Exception: {ex.Message}");
            }
        }
        public async Task<List<Person>> FindAll()
        {
            try
            {
                var persons = await _context.Persons
                    .AsNoTracking()
                    .Include(c => c.Contacts)
                    .ToListAsync();
                return persons;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar pessoa. \n Exception: {ex.Message}");
            }
        }
        public async Task Insert(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao realizar cadastro de pessoa. \n Exception: {ex.Message}");
            }
        }
        public async Task Update(Person person)
        {
            try
            {
                _context.Persons.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao atualizar cadastro de pessoa. \n Exception: {ex.Message}");
            }

        }
        public async Task Delete(Person person)
        {
            try
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir cadastro de pessoa. \n Exception: {ex.Message}");
            }
        }

    }
}

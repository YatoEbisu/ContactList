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
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> Find(Guid id)
        {
            try
            {
                var person = await _context.Contacts
                    .AsNoTracking()
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
                return person;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar contato. \n Exception: {ex.Message}");
            }
        }

        public async Task Insert(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao realizar cadastro de contato. \n Exception: {ex.Message}");
            }
        }

        public async Task Update(Contact contact)
        {
            try
            {
                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao atualizar cadastro de contato. \n Exception: {ex.Message}");
            }
        }
        public async Task Delete(Contact contact)
        {
            try
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir cadastro de contato. \n Exception: {ex.Message}");
            }
        }
    }
}

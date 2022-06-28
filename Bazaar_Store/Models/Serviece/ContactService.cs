using Bazaar_Store.Data;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Service
{
    public class ContactService : IContact
    {
        private readonly BazaarDataBase _context;

        public ContactService(BazaarDataBase context)
        {
            _context = context;
        }

        public async Task<Contact> Create(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Added;
            await _context.SaveChangesAsync();
            Contact newContact = new Contact
            {
                Name = contact.Name,
                Email = contact.Email,
                Subject = contact.Subject,
                Message = contact.Message
            };

            return newContact;
        }
    }
}

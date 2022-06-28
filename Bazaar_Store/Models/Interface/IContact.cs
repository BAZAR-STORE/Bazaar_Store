using Bazaar_Store.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
    public interface  IContact
    {
        Task<Contact> Create(Contact contact);
    }
}

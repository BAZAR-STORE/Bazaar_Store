using Bazaar_Store.Data;
using Bazaar_Store.Models.Interface;
using Bazaar_Store.Pages.Accounts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class UsersService : IUser
    {
        private BazaarDataBase _context;

        public UsersService(BazaarDataBase bazaarDbcontext)
        {
            _context = bazaarDbcontext;
        }
        public async Task<User> Create(User user)
        {
            _context.Entry(user).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Register(RegisterModel.RegisterData Input, ModelStateDictionary modelstate)
        {
            throw new System.NotImplementedException();
        }
    }
}

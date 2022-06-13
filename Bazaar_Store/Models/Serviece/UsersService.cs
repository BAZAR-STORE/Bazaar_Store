using Bazaar_Store.Data;
using Bazaar_Store.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class UsersService : IUser
    {
        private BazaarDbcontext _context;

        public UsersService(BazaarDbcontext bazaarDbcontext)
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
    }
}
